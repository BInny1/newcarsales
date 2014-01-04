var strMessage;
// It will be executed when the webservice returns error message
function onError(exception, userContext, methodName) {
    //var strMessage = '';
    // window.location.href='error.aspx';
    try {

        //window.location.href='error.aspx';
        strMessage = strMessage + 'ErrorType: ' + exception._exceptionType + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Message: ' + exception._message + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Stack Trace: ' + exception._stackTrace + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Status Code: ' + exception._statusCode + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Timed Out: ' + exception._timedOut;

         ///alert(strMessage);
    }
    catch (ex)
	    { }
}

///Get All Makes

function GetMakes() 
{
    CarsService.GetMakes(OnSuccessGetMakes, onError);
}

function OnSuccessGetMakes(result, userContext, methodName) {
    try {
 
        //alert(result);
        //make = result;
        BindMakes(result);
    }
    catch (ex)
    { }
}


///Get All Models by id
function GetModelsInfo() {
    CarsService.GetModelsInfo(OnSuccessGetModelsInfo, onError);
}

function GetTransferAgentsLoginInfo() {
    TransfersWebService.GetAllLoginTransferAgentsDetailsService(OnSuccessGetTransfersInfo, onError);
}
function GetAgentsLoginInfo() {
    TransfersWebService.GetAllLoginAgentDetailsService(OnSuccessGetTransfersInfo, onError);
}


function OnSuccessGetTransfersInfo(result, userContext, methodName) {
    try {

        //var oMyObject = xml2Obj(result);
        var json =xmlToJson(result);
       //console.log(json["ArrayOfAnyType"]["anyType"])
       // alert(result);
      
       if (json["ArrayOfAnyType"]["anyType"]!=undefined)
                {
                        if (json["ArrayOfAnyType"]["anyType"].length!=undefined)
                        { 
                            TransfersInfoBinding(json["ArrayOfAnyType"]["anyType"]);
                        
                        }
                        
                }

       
       
       
    }
    catch (ex)
    { 
     //window.location.href='error.aspx';
        strMessage = strMessage + 'ErrorType: ' + ex._exceptionType + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Message: ' + ex._message + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Stack Trace: ' + ex._stackTrace + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Status Code: ' + ex._statusCode + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Timed Out: ' + ex._timedOut;

         //alert(strMessage);
    }
}


// Changes XML to JSON
function xmlToJson(xml) {
  
  // Create the return object
  var obj = {};

  if (xml.nodeType == 1) { // element
    // do attributes
    /*if (xml.attributes.length > 0) {
    obj["@attributes"] = {};
      for (var j = 0; j < xml.attributes.length; j++) {
        var attribute = xml.attributes.item(j);
        obj["@attributes"][attribute.nodeName] = attribute.nodeValue;
      }
    }*/
  } else if (xml.nodeType == 3) { // text
    obj = xml.nodeValue;
  }

  // do children
  if (xml.hasChildNodes()) {
    for(var i = 0; i < xml.childNodes.length; i++) {
      var item = xml.childNodes.item(i);
      var nodeName = item.nodeName;
      if (typeof(obj[nodeName]) == "undefined") {
        obj[nodeName] = xmlToJson(item);
      } else {
        if (typeof(obj[nodeName].length) == "undefined") {
          var old = obj[nodeName];
          obj[nodeName] = [];
          obj[nodeName].push(old);
        }
        obj[nodeName].push(xmlToJson(item));
      }
    }
  }
  return obj;
};


// XML to Array Structure 2
 function xmlToJson2(xmlFile){    
    var xmlData = new JKL.ParseXML( xmlFile );
    var data = xmlData.parse();
    return data;
    
}


function OnSuccessGetModelsInfo(result, userContext, methodName) {
    try {

        //var oMyObject = xml2Obj(result);
        var json =xmlToJson(result);

       // alert(result);
       if (json["ArrayOfModelsInfo"]["ModelsInfo"]!=undefined)
                {
                        if (json["ArrayOfModelsInfo"]["ModelsInfo"].length!=undefined)
                        { 
                            ModelsBinding(json["ArrayOfModelsInfo"]["ModelsInfo"]);
                        
                        }
                        
                }

       
       
       
    }
    catch (ex)
    { 
     //window.location.href='error.aspx';
        strMessage = strMessage + 'ErrorType: ' + ex._exceptionType + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Message: ' + ex._message + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Stack Trace: ' + ex._stackTrace + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Status Code: ' + ex._statusCode + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Timed Out: ' + ex._timedOut;

         //alert(strMessage);
    }
}

function CarsSearch(carMake, CarModal, ZipCode, WithinZip)
{
        window.location.href ='SearchCars.aspx?Make='+carMake+'&Model='+CarModal+'&ZipCode='+ZipCode+'&WithinZip='+ WithinZip+'';        
}



function CarsSearch2(carMakeid, CarModalId, ZipCode, WithinZip,pageNo, pageresultscount, orderby)
{
        CarsService.GetCarsSearch(carMakeid, CarModalId, ZipCode, WithinZip,pageNo, pageresultscount, orderby,OnSuccessCarsSearch, onError);
}
function OnSuccessCarsSearch(result, userContext, methodName) {
    try {
    
    
        
        //alert(result); 
        //SearchResults=result;

       // alert(result);
       //ModelsBinding(result);
       if(LoadingPage == 1 || LoadingPage == 3){
            window.location.href ="SearchCars.aspx?";
       }
       else
       {
                sFilterType = parseInt($('#filterSortBy option:selected').val());    
                startNum = 1;
                endNum = parseInt($('#resultsPerPage option:selected').val());
                page = 1;    
                
                var json =xmlToJson(result);      
        
                SearchResults = json["ArrayOfUsedCarsInfo"]["UsedCarsInfo"];
                
                if (SearchResults!=undefined)
                {
                        if (SearchResults.length==undefined)
                        { 

                        var SearchChange = [];

                        SearchChange[0]=SearchResults;
                        
                        SearchResults=SearchChange;
                        
                        SearchResultsDisplayFilter(SearchResults);                    
                        
                        NoOfPages(SearchResults);    
                        }else
                        {

                            SearchResultsDisplayFilter(SearchResults);
                            NoOfPages(SearchResults);    

                        }        
                }
                else 
                {
                    hideSpinner();        
                    $('#totalResultsFound').text('0');
		            $('#PaginationBlock').hide();
		            $('.searchResultsHolder').empty();
		            $('.searchResultsHolder').append("<h2 style='color:#FF9900; text-align:center; line-height:200px;'>No records found..!</h2>");                
                } 
       }        
       
       //NoOfPages(parseInt($('#resultsPerPage option:selected').val()));
       
       
    }
    catch (ex)
    { }
}
function CarsSearchPage(carMakeid, CarModalId, ZipCode, WithinZip,pageNo, pageresultscount, orderby)
{
        
      CarsService.GetCarsSearch(carMakeid, CarModalId, ZipCode, WithinZip,pageNo, pageresultscount, orderby,OnSuccessCarsSearchPage, onError);
        
}

function OnSuccessCarsSearchPage(result, userContext, methodName) {
    try {
            MultiSearch=false;
    
        
        //alert(result); 
        //SearchResults=result;

       // alert(result);
       //ModelsBinding(result);
      
                sFilterType = parseInt($('#filterSortBy option:selected').val());    
                startNum = 1;
                endNum = parseInt($('#resultsPerPage option:selected').val());
                page = 1;    
                
                var json =xmlToJson(result);      
        
                SearchResults = json["ArrayOfUsedCarsInfo"]["UsedCarsInfo"];
                
                if (SearchResults!=undefined)
                {
                        if (SearchResults.length==undefined)
                        { 
                            var SearchChange = [];
                            SearchChange[0]=SearchResults;
                            SearchResults=SearchChange;
                            SearchResultsDisplayFilter(SearchResults);                    
                            NoOfPages(SearchResults);    
                        }else
                        {

                            SearchResultsDisplayFilter(SearchResults);

                            NoOfPages(SearchResults);    

                        }        
                }
                else 
                {
                    hideSpinner();        
                     $('#totalResultsFound').text('0');
		             $('#PaginationBlock').hide();
		             $('.searchResultsHolder').empty();
		             $('.searchResultsHolder').append("<h2 style='color:#FF9900; text-align:center; line-height:200px;'>No records found..!</h2>");
                
                } 
       }        
       
    
       
       
    
    catch (ex)
    { }
}
function  GetCarsSearchPage()
{
    CarsService.GetCarsSearchPage(OnSuccessCarsSearchpage, onError);
}
function OnSuccessCarsSearchpage(result, userContext, methodName) {
    try {
    
       
      
         var json =xmlToJson(result);

      
          SearchResults = json["ArrayOfUsedCarsInfo"]["UsedCarsInfo"];
       
       if (SearchResults!=undefined)
       {
            if (SearchResults.length==undefined)
            { 
                
                var SearchChange = [];
                
                SearchChange[0]=SearchResults;
                SearchResults=SearchChange;
                SearchResultsDisplayFilter(SearchResults);                    
                NoOfPages(SearchResults); 
                if (PAGEFIRST != 0)
                { 
                filterChecked();        
                }
            }else
            {
                
                SearchResultsDisplayFilter(SearchResults);
                NoOfPages(SearchResults);    
                if (PAGEFIRST != 0)
                { 
                  filterChecked();  
                }
            
            }        
       }else
       {
            hideSpinner();            
            $('#totalResultsFound').text('0');
            $('#PaginationBlock').hide();
            $('.searchResultsHolder').empty();
            $('.searchResultsHolder').append("<h2 style='color:#FF9900; text-align:center; line-height:200px;'>No records found..!</h2>");
                
       }
       
       
        
        
       
       
       
    }
    catch (ex)
    { }
}
function  GetCarsFilter(arr,PageResultsCount)
{
    if (MultiSearch==false)
    {
            CarsService.GetCarsFilter(arr,PageResultsCount,OnSuccessGetCarsFilter, onError);
    }
    else if (MultiSearch==true)
    {
            CarsService.GetCarsFilterMulti(arr,PageResultsCount,OnSuccessGetCarsFilter, onError);
    }
}

function OnSuccessGetCarsFilter(result, userContext, methodName) {
    try {
        var json =xmlToJson(result);
      
       SearchResults = json["ArrayOfUsedCarsInfo"]["UsedCarsInfo"];
       if (SearchResults!=undefined)
       {
             if (SearchResults.length==undefined)
            { 
                
                var SearchChange = [];
                
                SearchChange[0]=SearchResults;
                SearchResults=SearchChange;
                SearchResultsDisplayFilter(SearchResults);        
                NoOfPages(SearchResults);
            }else
            {
                
                SearchResultsDisplayFilter(SearchResults);
                
                NoOfPages(SearchResults);    
            
            }        
       }
       else
       {
            hideSpinner();        
            $('#totalResultsFound').text('0');
            $('#PaginationBlock').hide();
            $('.searchResultsHolder').empty();
            $('.searchResultsHolder').append("<h2 style='color:#FF9900; text-align:center; line-height:200px;'>No records found..!</h2>");
                
       }
    
}
   catch (ex)
    { }
}

function  GetSearchCriteria()
{
    CarsService.GetSearchCriteria(OnSuccessGetSearchCriteria, onError);
}


function OnSuccessGetSearchCriteria(result, userContext, methodName) {
    try {
       
       SessionArray = result;
       //searchCri();
    
}
   catch (ex)
    { }
}

function  GetPageDecrement(PageSize, pageNo)
{
    
    if (MultiSearch==false)
    {
            CarsService.GetPageData(PageSize, pageNo,OnSuccessGetPageDecrement, onError);
    }
    else
    {
            CarsService.GetPageMultiData(PageSize, pageNo,OnSuccessGetPageDecrement, onError);
    }    
    
}
function OnSuccessGetPageDecrement(result, userContext, methodName) {
    try {
    
        var json =xmlToJson(result);
       
       SearchResults = json["ArrayOfUsedCarsInfo"]["UsedCarsInfo"];
       SearchResultsDisplayFilter(SearchResults);       
       
       
        
        if (page ==Pagecount-1)
        {
            startNum -=  resultsLength;
            endNum -= (endNum-(((Pagecount-1)*parseInt($('#resultsPerPage option:selected').val())) ));                 
        }
        else 
        {
                startNum -=  resultsLength;
                endNum-=parseInt($('#resultsPerPage option:selected').val()) ;
        }
        NoOfPages(SearchResults);
       
}
   catch (ex)
    { }
}




function  GetPageData(PageSize, pageNo)
{       
        if (MultiSearch==false)
        {
            CarsService.GetPageData(PageSize, pageNo,OnSuccessGetPageData, onError);
        }
        else
        {
            CarsService.GetPageMultiData(PageSize, pageNo,OnSuccessGetPageData, onError);
        }    
}
function OnSuccessGetPageData(result, userContext, methodName) {
    try {
    
        var json =xmlToJson(result);
    
       SearchResults = json["ArrayOfUsedCarsInfo"]["UsedCarsInfo"];
       SearchResultsDisplayFilter(SearchResults);        
        
        
        if(SearchResults.length < parseInt($('#resultsPerPage option:selected').val())){
            startNum += parseInt($('#resultsPerPage option:selected').val()); 
            endNum += SearchResults.length; 
        }else{
          startNum += resultsLength; 
            endNum += resultsLength;    
        }             
        
        
            
       
       NoOfPages(SearchResults);
       
       
}
   catch (ex)
    { }
}

function  NoOfPages(SearchResults)
{
  
    try {
    
    if (SearchResults!=undefined)
    { 
        Pagecount=SearchResults[0]['PageCount']['#text'];
        TotalRecords=SearchResults[0]['TotalRecords']['#text'];
         
         var result= [];
        
        result[0]=Pagecount;
        result[1]=TotalRecords;
        
        NoOfResultsandPagecount(result);
     }
    }
   catch (ex)
    { }
}
function  GetCarsMultiSearch(SearchArray)
{
    CarsService.GetCarsMultiSearch(SearchArray,OnSuccessGetCarsMultiSearch, onError);
}

function OnSuccessGetCarsMultiSearch(result, userContext, methodName) {
try {

            MultiSearch=true; 
            var json =xmlToJson(result);
            
            SearchResults = json["ArrayOfUsedCarsInfo"]["UsedCarsInfo"];
            startNum = 1;
            endNum = parseInt($('#resultsPerPage option:selected').val());
            page = 1;
            sFilterType = parseInt($('#filterSortBy option:selected').val());     
            
       if (SearchResults!=undefined)
       {
           
                if (SearchResults.length==undefined)
                {                 
                    var SearchChange = [];
                    
                    SearchChange[0]=SearchResults;
                    SearchResults=SearchChange;
                     
           
                    SearchResultsDisplayFilter(SearchResults);                    
                    NoOfPages(SearchResults);    
                }else
                {
                    
                    SearchResultsDisplayFilter(SearchResults);
                    
                    NoOfPages(SearchResults);    
                
                }        
       }else
       {    hideSpinner();        
            $('#totalResultsFound').text('0');
            $('#PaginationBlock').hide();
            $('.searchResultsHolder').empty();
            $('.searchResultsHolder').append("<h2 style='color:#FF9900; text-align:center; line-height:200px;'>No records found..!</h2>");
                
       }
            
        
//ONLY THESE REQUIRED 
//        PREVIOUSLY MODIFIED 
//        ///When Search Criteria Selected and apply sort order to the results and filter
//                if (totalCheckedID()<35)
//                {
//                        filterChecked();   
//                }               
//                else 
//                {       
//                        if(sFilterType != 0 && sFilterType != '0'){
//                           
//                            SortData(sFilterType, endNum);
//                        }
//                        else 
//                        {
//                            SearchResultsDisplayFilter(SearchResults);
//                            NoOfPages(parseInt($('#resultsPerPage option:selected').val()));    
//                        }
//    
//                }
//        
//        
       
}
   catch (ex)
    { }
}


function SortData(sFilterType, pageSize)
{
    if (MultiSearch==false)
     {        
        CarsService.SortData(sFilterType, pageSize, OnSuccessSortData, onError);
     }
     else
     {
        CarsService.SortMultiData(sFilterType, pageSize, OnSuccessSortData, onError);
     }
     
}

function OnSuccessSortData(result, userContext, methodName) {
    try {
        var json =xmlToJson(result);
              
       SearchResults = json["ArrayOfUsedCarsInfo"]["UsedCarsInfo"];
       
       SearchResultsDisplayFilter(SearchResults); 
       
       NoOfPages(SearchResults);
    
}
   catch (ex)
    { }
}


function FindCarID(sCarid){

    CarsService.FindCarID(sCarid, OnSuccessFindCarID, onError);
}

function OnSuccessFindCarID(result, userContext, methodName) {
try {
    var json = xmlToJson(result);
    carDetails = json["ArrayOfUsedCarsInfo"]["UsedCarsInfo"];
    // carDetails = json["ArrayOfUsedCarsInfo"]["UsedCarsInfo"];    
    carDetailsDisplay();
}

catch (ex)
{ }

}

function EncryptedCarID(sCarID,sMake,sModel,sZip,sWithinZip)
{
    
    var v='SearchCarDetails.aspx?Make='+sMake+'&Model='+sModel+'&ZipCode='+sZip+'&WithinZip='+sWithinZip+'&C='+randomString()+''+sCarID+'';    
    window.location.href=v;    
}
function randomString() {
	var chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghiklmnopqrstuvwxyz";
	var string_length = 8;
	var randomstring = '';
	for (var i=0; i<string_length; i++) {
		var rnum = Math.floor(Math.random() * chars.length);
		randomstring += chars.substring(rnum,rnum+1);
	}
	return randomstring;
}

function SearchedCar()
{
    CarsService.SearchedCar(OnSuccessSearchedCar, onError);
}

function OnSuccessSearchedCar(result, userContext, methodName) {
try {
    var json = xmlToJson(result);
    carDetails = json["ArrayOfUsedCarsInfo"]["UsedCarsInfo"];    
    carDetailsDisplay();
    
}

catch (ex)
{ }

}


function ChekZip(sZip) {

    CarsService.CheckZips(sZip,OnSuccessGetZips, onError);
}

function OnSuccessGetZips(result, userContext, methodName) {
try 
{

        if (result==true)
        {         
            CarsSearch($('#make option:selected').text(), $('#model option:selected').text(),$('#yourZip').val(), $('#within option:selected').val(), '1', '25', 'price'); 
            
            CarsService.SearchCriteriaSave($('#make option:selected').val(), $('#model option:selected').val(),$('#yourZip').val(), $('#within option:selected').val(),OnSuccessSearchCriteriaSave,onerror); 
        }
        else 
        {
            hideSpinner();
            //CarsSearch($('#make option:selected').val(), $('#model option:selected').val(),$('#yourZip').val(), $('#within option:selected').val(), '1', '25', 'price'); 
            alert('Oops! we could not locate the zip you entered. Please enter another zip code');
        }       
}

catch (ex)
{ }
}



function OnSuccessSearchCriteriaSave(result, userContext, methodName) {
    try 
    {

    }
    catch (ex)
    { 
    }
}

function ChekZip2(sZip) {

    CarsService.CheckZips(sZip,OnSuccessGetZips2, onError);
}

function OnSuccessGetZips2(result, userContext, methodName) {
try 
{

        if (result==true)
        {  
       
            
            $('.ZipVal-holder').hide();
            //CarsSearchPage(MakeID1,'All models',zip1,'5', '1', '25', 'price'); 
           
            CarsSearch(MakeIDName,'All models',zip1,'5', '1', '25', 'price');             
            CarsService.SearchCriteriaSave(MakeID1, '0',zip1, '5',OnSuccessSearchCriteriaSave,onerror); 
        }
        else 
        {
            hideSpinner();
            //CarsSearch($('#make option:selected').val(), $('#model option:selected').val(),$('#yourZip').val(), $('#within option:selected').val(), '1', '25', 'price'); 
            alert('Oops! we could not locate the zip you entered. Please enter another zip code');
        }       
}

catch (ex)
{ }
}

function  GetCarFeatures(sCarId)
{
    try
    {
        CarsService.GetCarFeatures(sCarId,OnSuccessGetCarFeatures, onError); 
    }
    catch (ex)
    { }

}

function OnSuccessGetCarFeatures(result, userContext, methodName) {
try 
{
          var json = result;
          //alert(json); 
          //carDetails = json["ArrayOfUsedCarsInfo"]["UsedCarsInfo"];    
          //carDetailsDisplay();
          carFretures(json);
}
    catch (ex)
    { }

}

function  GetCarsAds()
{
    try
    {
        CarsService.GetCarsAds(OnSuccessGetCarsAds, onError); 
    }
    catch (ex)
    { }

}

function OnSuccessGetCarsAds(result, userContext, methodName) {
try 
{
       
       json = xmlToJson(result);
          
       CarsAdDetails = json["ArrayOfUsedCarsInfo"]["UsedCarsInfo"];    
          
          
       if (CarsAdDetails!=undefined)
       {
           
                if (CarsAdDetails.length==undefined)
                {                 
                    var CarsAdDetailsChange = [];
                    
                    CarsAdDetailsChange[0]=CarsAdDetails;
                    CarsAdDetails=CarsAdDetailsChange;
                     
           
                    CarsAdDisplay(CarsAdDetails);
                    
                }else
                {
                    
                    CarsAdDisplay(CarsAdDetails);
                }        
       }
       
       
       
          
         
}
    catch (ex)
    { }

}




function  GetCarBannerAds()
{
    try
    {
        CarsService.GetCarBannerAds(OnSuccessGetCarBannerAds, onError); 
    }
    catch (ex)
    { 
    }

}

function OnSuccessGetCarBannerAds(result, userContext, methodName) {
try 
{
        json = xmlToJson(result);

        CarBannerAds = json["ArrayOfUsedCarsInfo"]["UsedCarsInfo"];    
          
          
       if (CarBannerAds!=undefined)
       {
           
                if (CarBannerAds.length==undefined)
                {                 
                    var CarsAdDetailsChange = [];
                    
                    CarsAdDetailsChange[0]=CarBannerAds;
                    CarBannerAds=CarsAdDetailsChange;
                     
           
                    CarBannerAdsDisplay(CarBannerAds);
                    
                }else
                {
                    
                    CarBannerAdsDisplay(CarBannerAds);
                }        
       }
 
}
    catch (ex)
    { }

}


function  GetRecentListings()
{
    try
    {
        CarsService.GetRecentListings(OnSuccessGetRecentListings, onError); 
    }
    catch (ex)
    { 
    }

}


function OnSuccessGetRecentListings(result, userContext, methodName) {
try 
{
        json = xmlToJson(result);

        latestPostedCars1 = json["ArrayOfUsedCarsInfo"]["UsedCarsInfo"];    
          
          
       if (latestPostedCars1!=undefined)
       {
           
                if (latestPostedCars1.length==undefined)
                {                 
                    var CarsAdDetailsChange = [];
                    
                    CarsAdDetailsChange[0]=latestPostedCars1;
                    latestPostedCars1=CarsAdDetailsChange;
                     
                    latestPostedCars(latestPostedCars1)
                    //CarBannerAdsDisplay(CarBannerAds);
                    
                }else
                {
                    latestPostedCars(latestPostedCars1)
                    //CarBannerAdsDisplay(CarBannerAds);
                }        
       }
 
}
    catch (ex)
    { }

}


