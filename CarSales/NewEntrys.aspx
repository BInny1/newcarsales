<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewEntrys.aspx.cs" Inherits="NewEntrys" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: Car Sales System ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="css/core.css" rel="stylesheet" type="text/css" />
    <link href="css/core.theme.css" rel="stylesheet" type="text/css" />
    <link href="css/styleNew.css" rel="stylesheet" type="text/css" />
    <link href="css/menu1.css" rel="stylesheet" type="text/css" />
    <!-- 
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    -->

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <!-- 
    <script type="text/javascript" src="js/emulatetab.joelpurra.js"></script>

    <script type="text/javascript" src="js/plusastab.joelpurra.js"></script>

   
    <link href="css/css2.css" rel="stylesheet" type="text/css" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
   
    
    <script type='text/javascript' language="javascript" src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="Static/JS/calendar.js" type="text/javascript"></script>

    <link href="Static/Css/calender.css" rel="stylesheet" type="text/css" />

    
    
     -->

    <script type="text/javascript" language="javascript">window.history.forward(1);</script>

    <script type="text/javascript">
 function pageLoad()
   { 
      //InitializeTimer();   
      
      //date = new Date(parseInt(arr[2]), parseInt(arr[0])-1, parseInt(arr[1]) + 1);
        
        $('.arrowRight').click(function(){
             var arr = $('#txtStartDate').val().split('/')
            var date = new Date(parseInt(arr[2]), parseInt(arr[0])-1, parseInt(arr[1]) - 1);
            $('#txtStartDate').val((date.getMonth()+1)+'/'+date.getDate()+'/'+date.getFullYear()); 
        });
        
        $('.arrowLeft').click(function(){
            var arr = $('#txtStartDate').val().split('/')
            var date = new Date(parseInt(arr[2]), parseInt(arr[0])-1, parseInt(arr[1]) + 1);
            $('#txtStartDate').val((date.getMonth()+1)+'/'+date.getDate()+'/'+date.getFullYear());            
            
        });
         
   }
    <script type="text/javascript" language="javascript">
        //-------------------------- Agents Centers Info END ------------------------------------------
//    $(window).load(function(){
//        TransfersInfoBinding();
//    })
  function TransfersInfoBinding(){
        youfunction()
        $(window).load(function(){
            //alert('Ok')
            youfunction()
        });            
  }
  
    
    function youfunction(){
        //alert('ok')
           $('#feat input[type=radio]').each(function(){
            if($(this).is(':checked')){
                $(this).parent().next('span').addClass('featAct')  
            }    
            
        });
        
        
         $('#infoV input[type=radio]').each(function(){
            if($(this).is(':checked')){
                $(this).parent().next('span').addClass('featAct')  
            }  
        });
        
        
        
         $('#feat input[type=checkbox]').each(function(){              
                if($(this).is(':checked')){
                    $(this).parent().next('span').addClass('featAct')  
                }  
        });
        
        
          $('#feat input[type=checkbox]').each(function(){
            $(this).click(function(){
                if($(this).parent().hasClass('noLM')){
                    $(this).parent().next('span').toggleClass('featAct')
                }else{
                    $(this).next('span').toggleClass('featAct')
                }
                if($(this).is(':checked')){
                    $(this).parent().next('span').addClass('featAct')  
                }  
            })
        });
       
        
        
         $('#feat input[type=radio]').each(function(){
            $(this).click(function(){
              // var name = $(this).attr('name');
               $('#feat input[type=radio]').each(function(){
                    //if(name != $(this).attr('name')){
                        $(this).parent().next('span').removeClass('featAct')
                    //}
               });
               $(this).parent().next('span').addClass('featAct')             
               
            })
        });
        
        
         $('#infoV input[type=radio]').each(function(){
            $(this).click(function(){
               var name = $(this).attr('name');
               $('#infoV input[type=radio]').each(function(){
                    if(name == $(this).attr('name')){
                        $(this).parent().next('span').removeClass('featAct')
                    }
               })  
               $(this).parent().next('span').addClass('featAct')           
               
            })
        });
        $('.hid').click(function(){			
			if($(this).attr('id') == 'Vinfo'){
				var str = '';
				if($('#ddlMake option:selected').val() != 0){
					str += $('#ddlMake option:selected').text()+"-";				
				}
				else
				{
				    str += "Unspecified"+"-";
				}
				if($('#ddlModel option:selected').val() != 0){
					str += $('#ddlModel option:selected').text()+"-";				
				}
				else
				{
				    str += "Unspecified"+"-";
				}
				if($('#ddlYear option:selected').val() != 0){
					str += $('#ddlYear option:selected').text()+"-";
				}
				else
				{
				    str += "Unspecified"+"-";
				}
				if($('#txtAskingPrice').val().length>0){
					str += "<span class='price11'>"+$('#txtAskingPrice').val()+"</span>-";
				}
				else
				{
				    str += "Unspecified"+"-";
				}				
				if($('#txtMileage').val().length>1){
					str += $('#txtMileage').val();
				}
				else
				{
				   str += "Unspecified";
				}	
				if(($('#ddlMake option:selected').val() == 0) &&($('#ddlModel option:selected').val() == 0)&&($('#ddlYear option:selected').val() == 0)&&($('#txtAskingPrice').val().length<1)&&($('#txtMileage').val().length<1))			
				{
				   str = "";
				}				
				if($('#Vinfo').next('div.hidden').is(':visible')){				
					$('#Vinfo label').empty().append(str);	
					$('.price11').formatCurrency();
				}else{
					$('#Vinfo label').empty()
				}	
			}
			$(this).next('div.hidden').slideToggle();
		});		
        
        
        
            var result =[];
        //$('#grdTest').onload(function(){ alert('Ok') })
        console.log($('#grdTest tr').length);
        if($('#grdTest tr').length >0 ){
        for(i=0; i<$('#grdTest tr').length; i++){
            var cc = [];
            cc.push($.trim($('#grdTest tr:eq('+i+') td:eq(0) span').text()));
            cc.push($.trim($('#grdTest tr:eq('+i+') td:eq(1) span').text()));
            result.push(cc);
        }
        //console.log(result)
        
        
        var centers = [];
        var centersUniq = [];
        var agents = [];
        var finalArray2 = [];
        var finalArray = [];
        var menu = '';  
        
        for (i=0; i<result.length; i++){       
            centersUniq.push($.trim(result[i][1]));          
        }
         
        finalArray =  result;    
        centersUniq = unique1(centersUniq);
                
        for(i=0; i<centersUniq.length; i++){
            var cent = $.trim(centersUniq[i]);            
            var dum = [];
            var counter = 0;
            for(k=0; k<finalArray.length; k++){
                if(centersUniq[i] == $.trim(finalArray[k][1])){
                    var cn = [];
                    dum.push($.trim(finalArray[k][0])) ;             
                    counter++;
                }
            }            
            var dum2 = [];
            dum2.push(cent);
            dum2.push(dum);
            dum2.push(counter);            
            finalArray2.push(dum2);       
        }
        var text = $('#lblTransferAgentsCount').text(); 
        menu = '';
        menu += "<div id='smoothmenu1' class='ddsmoothmenu'><ul><li><a href='#'>"+text+"</a><ul>";
        for(i=0;i<finalArray2.length;i++){
            menu += '<li><a href="#" >'+finalArray2[i][0]+' ('+finalArray2[i][2]+')</a>';
            if(finalArray2[i][1].length > 0){                
                for(k=0;k<finalArray2[i][1].length;k++){
                    if(k==0){menu += '<ul>';}
                    menu += '<li><a href="#" >'+finalArray2[i][1][k]+'</a></li>';
                    if(k==(finalArray2[i][1].length-1)){menu += '</ul>';}
                }                
            }
            menu += '</li>';            
        } 
      
        menu += "</ul></li></ul></div>";  
        $('#lblTransferAgentsCount').empty().append(menu);        
        $('<a href="#"></a>').remove();
        
        ddsmoothmenu.init({
	        mainmenuid: "smoothmenu1", //menu DIV id
	        orientation: 'h', //Horizontal or vertical menu: Set to "h" or "v"
	        classname: 'ddsmoothmenu', //class added to menu's outer DIV
	        //customtheme: ["#1c5a80", "#18374a"],
	        contentsource: "markup" //"markup" or ["container_id", "path_to_menu_file"]
        });     
        }  
    }
    var ssTime,TimerID;
   function  InitializeTimer()
   {  
     WebService.sessionGet(onsuccessGet,onError);      
   }
     function onsuccessGet(result)
     {
      ssTime=result; 
      ssTime=parseInt(ssTime)*60000;
     
      TimerDec(ssTime);
     }
   
  
   
   function  TimerDec(ssTime)
   {
   
     ssTime=ssTime-1000;
   
    TimerID=setTimeout(function(){TimerDec(ssTime);},1000);
      
    if(ssTime==60000)
    {      
     SessionInc();     
    }
     
   }
  
    
    function SessionInc()//Increase the session time
    {
     debugger    
      ssTime=parseInt("<%= Session.Timeout %>");     
      WebService.sessionSet(ssTime,onsuccessInc,onError);//call webservice to set the session variable
       ssTime=(parseInt(ssTime)-2)*60000;       
       TimerDec(ssTime);     
    }
    
    function onsuccessInc(result)
    {
     
    }    

     function onError(exception, userContext, methodName)
     {
       try 
       {
        //window.location.href='error.aspx';
        strMessage = strMessage + 'ErrorType: ' + exception._exceptionType + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Message: ' + exception._message + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Stack Trace: ' + exception._stackTrace + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Status Code: ' + exception._statusCode + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Timed Out: ' + exception._timedOut;
        ///alert(strMessage);
      } catch (ex) {}
     return false;
   }
       

    </script>

    <script type="text/javascript" language="javascript">

	var currentID = 0;	
	var currentActiveIndex = 0;
	
	$(function(){
		currentID = $('.mainUL li.active').index();
		//sub1Act = $('.mainUL li.active li.act').index();
		sub2Act = $('.mainUL li.active li.act li.act').index();
		
		
		$('.mainUL .parent ul').hide(); // hide All Submenus
		$('.mainUL .parent a').click(function(){
			
			$('.mainUL .parent ul').hide(); // hide All Submenus
			
			
			$('.mainUL .parent a').each(function(){  // remove highlight for all anchor tags
				$(this).removeClass('act');
			});	
		    
		    
		    
		    
			
			$(this).closest('ul').closest('ul').show();		
			
			
			$(this).addClass('act'); //  highlight current clicked anchor tags
			
			$('.mainUL li').each(function(){ // remove active class for all list tags
				$(this).removeClass('active');
			});
			
			
			$(this).closest('li.parent').addClass('active'); //   highlight current clicked anchor tags parent list tag
			
			if($(this).next('ul')){ // if current clicked anchor tag has submenu it will show it
				$(this).next().show();
			}
			
			$('.mainUL li.parent:eq('+currentID+') li.act li:eq('+sub2Act+')').addClass('act');
			
		});
		
		
		$('.mainUL li.active a:eq(0)').click();
		
		$(document).mouseup(function(e) {  // on mouse click on the document exept menu, automatically all submenus will hide and reset
			var container = $('.mainUL');
			if (container.has(e.target).length === 0) {
				$('.mainUL .parent ul ').hide();
			
				$('.mainUL .parent a').each(function(){
					$(this).removeClass('act');
				});
				
				$('.mainUL').find('li.parent.active').removeClass('active');
				$('.mainUL li.parent:eq('+currentID+')').addClass('active');
				
				$('.mainUL li.active a:eq(0)').click();
				
			}
		});
		
		
	});
    </script>
    

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scrptmgr" runat="server" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/WebService.asmx" />
        </Services>
    </asp:ScriptManager>
    <!-- Main Wrapper Start  -->
    <div class="wrapper">
        <!-- Headder Start  -->
        <div class="head wid100p">
            <a href="#" class="logo"></a>
            <div class="headding">
                <h1>
                    Car Sales System<span></span></h1>
            </div>
            <div class="headright">
                <div class="loginDet">
                    &nbsp;<asp:Label ID="lblUserName" runat="server" CssClass="loginStat"></asp:Label>&nbsp;
                    |&nbsp;
                    <asp:LinkButton ID="lnkBtnLogout" runat="server" Text="Logout" OnClick="lnkBtnLogout_Click"
                        CssClass="loginStat"></asp:LinkButton>
                </div>
                <asp:LinkButton ID="lnkTicker" runat="server" CssClass="btn btn-xs btn-info floarR"
                    Text="Sales Ticker"></asp:LinkButton>
                <div class="menu1">
                    <ul class="mainUL">
                        <li class="parent"><a href="#">Leads <span class="cert"></span></a>
                            <ul class="sub1">
                                <li>
                                    <asp:LinkButton ID="LeadsUpload" runat="server" Text="Upload" Enabled="false" PostBackUrl="~/LeadsUpload.aspx"></asp:LinkButton></li><li>
                                <li>
                                    <asp:LinkButton ID="LeadsDownLoad" runat="server" Text="Download" Enabled="false"
                                        PostBackUrl="~/LeadDownLoad.aspx"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Abondoned" runat="server" Text="Abondon" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="FreePackage" runat="server" Text="Free Pkg" Enabled="false"></asp:LinkButton></li>
                            </ul>
                        </li>
                        <li class="parent active"><a href="#">Sales <span class="cert"></span></a>
                            <ul class="sub1">
                                <li>
                                    <asp:LinkButton ID="IntroMail" runat="server" Text="Intro Mial" Enabled="false"></asp:LinkButton></li>
                                <li class="act">
                                    <asp:LinkButton ID="NewEntry" runat="server" Text="New Entry" Enabled="false" PostBackUrl="~/NewEntrys.aspx"></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="Transferin" runat="server" Text="Transfer In" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="MyReport" runat="server" Text="My Report" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnkSetGrup" runat="server" Text="SetGroup" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnkGroupreport" runat="server" Text="Group Report" Enabled="false"></asp:LinkButton></li>
                            </ul>
                        </li>
                        <li class="parent"><a href="#">Process <span class="cert"></span></a>
                            <ul class="sub1">
                                <li>
                                    <asp:LinkButton ID="QC" runat="server" Text="QC" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Payments" runat="server" Text="Payments" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Publish" runat="server" Text="Publish" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnkMmyRep" runat="server" Text="My Report" Enabled="false"></asp:LinkButton></li>
                            </ul>
                        </li>
                        <li class="parent "><a href="#">Reports <span class="cert"></span></a>
                            <ul class="sub1">
                                <li>
                                    <asp:LinkButton ID="Leads" runat="server" Text="Leads" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Sales" runat="server" Text="Sales" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Process" runat="server" Text="Process" Enabled="false" PostBackUrl="~/ProcessRights.aspx"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Executive" runat="server" Text="Exceutive" Enabled="false"></asp:LinkButton></li>
                            </ul>
                        </li>
                        <li class="parent "><a href="#">Admin <span class="cert"></span></a>
                            <ul class="sub1">
                                <li><a href="#">Leads <span class="cert"></span></a>
                                    <ul class="sub2">
                                        <li>
                                            <asp:LinkButton ID="leadsRights" runat="server" Text="Leads User Rights" PostBackUrl="~/LeadsUserRights.aspx"></asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="LeadsList" runat="server" Text="Leads State Wise" PostBackUrl="~/StatewiseLeads.aspx"></asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="LeadsSatus" runat="server" Text="Leads Status" PostBackUrl="~/StateWiseLeadsStatus.aspx"></asp:LinkButton></li>
                                    </ul>
                                </li>
                                <li><a href="#">Sales <span class="cert"></span></a>
                                    <ul class="sub2">
                                        <li>
                                            <asp:LinkButton ID="SalesAdmin" runat="server" Text="User Rights" PostBackUrl="~/SalesUserRights.aspx"
                                                Enabled="false"></asp:LinkButton></li>
                                        <li class="last">
                                            <asp:LinkButton ID="lnkDefaRights" runat="server" Text="Default Rights" PostBackUrl="~/DefaultRights.aspx"></asp:LinkButton></li>
                                    </ul>
                                </li>
                                <li>
                                    <asp:LinkButton ID="ProcessAdmin" runat="server" Text="Process" PostBackUrl="~/ProcessRights.aspx"
                                        Enabled="false"></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="ExecutiveAdmin" runat="server" Text="Executive" Enabled="false"
                                        PostBackUrl="~/Executives.aspx"></asp:LinkButton></li>
                                <li><a href="#">Brands <span class="cert"></span></a>
                                    <ul class="sub2">
                                        <li>
                                            <asp:LinkButton ID="BrandsAdmin" runat="server" Text="Brands" PostBackUrl="~/Brands.aspx"
                                                Enabled="false"></asp:LinkButton></li>
                                        <li class="last">
                                        <li>
                                            <asp:LinkButton ID="BrnadsProducts" runat="server" Text="Products" PostBackUrl="~/Products.aspx"
                                                Enabled="true"></asp:LinkButton></li>
                                    </ul>
                                </li>
                                <li>
                                    <asp:LinkButton ID="CentersAdmin" runat="server" Text="Locations" PostBackUrl="~/Locations.aspx"
                                        Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="UsersLog" runat="server" Text="User Log" PostBackUrl="~/UserLog.aspx"
                                        Enabled="false"></asp:LinkButton></li>
                                <li class="last">
                                    <asp:LinkButton ID="EditLog" runat="server" Text="Edit Log" PostBackUrl="~/EditLogs.aspx"
                                        Enabled="false"></asp:LinkButton></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- Headder End  -->
        <!-- Content Start  -->
        <!-- Content Start  -->
        <div class="content wid1000">
            <div class="clear">
                &nbsp;</div>
            <div class="box1">
                <div class="inn">
                   
                    <table style="display: none" id="tblAgents" runat="server">
                        <tr>
                            <td>
                                <asp:GridView ID="grdTest" runat="server" ShowHeader="false" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGridAgnetName" runat="server" Text='<%# Eval("AgentUFirstName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGridAgentCenter" runat="server" Text='<%# Eval("AgentCenterCode")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td width="400px;">
                                <asp:Label ID="lblTransferAgentsCount" runat="server"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 48%">
                                <h4 class="field">
                                    <label class="left">
                                        <span class="star">*</span>Package:
                                    </label>
                                    <span class="left2">
                                        <asp:DropDownList ID="ddlPackage" runat="server" onchange="return OnchangeCheckDiscount()">
                                        </asp:DropDownList>
                                    </span>
                                </h4>
                            </td>
                            <td style="width: 40px;">
                                &nbsp;
                            </td>
                            <td style="text-align: right;">
                                <asp:UpdatePanel ID="updtpnlSave" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnTransfer" runat="server" CssClass="btn btn-warning btn-sm" Text="Transfer"
                                            OnClientClick="return ValidateDraftData();" OnClick="btnTransfer_Click" />
                                        &nbsp;
                                        <asp:Button ID="btnSale" runat="server" CssClass="btn btn-success btn-sm" Text="Sale"
                                            OnClientClick="return ValidateSavedData();" OnClick="btnSale_Click" />
                                        &nbsp;
                                        <asp:Button ID="btnSavedraft" runat="server" CssClass="btn btn-info btn-sm" Text="Save as draft"
                                            OnClick="btnSavedraft_Click" OnClientClick="return ValidateDraftData();" />
                                        &nbsp;
                                        <asp:Button ID="btnAbandon" runat="server" CssClass="btn btn-danger btn-sm" Text="Abandon"
                                            OnClick="btnAbandon_Click" OnClientClick="return ValidateAbandonData();" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td width="400px;">
                                <span id="discount"><span class="left2" style="display: none;">
                                    <label class="left">
                                        <span class="star">*</span>Discount:
                                    </label>
                                    <asp:DropDownList ID="ddlDiscount" runat="server" onchange="return OnchangeDropdown()">
                                    </asp:DropDownList>
                                </span></h4>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 20px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        Agent:
                                    </label>
                                    <span class="left2">
                                        <asp:DropDownList ID="ddlSaleAgent" runat="server" onchange="return OnchangeDropdown()">
                                        </asp:DropDownList>
                                    </span>
                                </h4>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        Verifier:
                                    </label>
                                    <span class="left2">
                                        <asp:DropDownList ID="ddlVerifier" runat="server" onchange="return OnchangeDropdown()">
                                        </asp:DropDownList>
                                    </span>
                                </h4>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="clear">
                &nbsp;</div>
            <!-- SELLER INFORMATION Start -->
            <div class=" box1 boxBlue">
                <h1 class="hed1 hed2">
                    SELLER INFORMATION</h1>
                <div class="inn">
                    <!-- Start  -->
                    <table class="table2">
                        <tr>
                            <td style="width: 49%;">
                                <h4 class="field">
                                    <label class="left">
                                        <span class="star">*</span>First name:</label>
                                    <span class="left2">
                                        <asp:TextBox ID="txtFirstName" runat="server" MaxLength="30"></asp:TextBox>
                                </h4>
                            </td>
                            <td style="width: 40px;">
                                &nbsp;
                            </td>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        <span class="star">*</span>Last name:</label>
                                    <span class="left2">
                                        <asp:TextBox ID="txtLastName" runat="server" MaxLength="30"></asp:TextBox>
                                </h4>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        <span class="star">*</span>Phone #:</label>
                                    <span class="left2">
                                        <asp:TextBox ID="txtPhone" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)"
                                            onblur="return PhoneOnblur();" onfocus="return PhoneOnfocus();"></asp:TextBox>
                                </h4>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        <span class="star">*</span>Email:</label>
                                    <span class="left2">
                                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="60" onblur="return EmailOnblur();"
                                            Style="width: 336px;"></asp:TextBox>
                                        <asp:CheckBox ID="chkbxEMailNA" runat="server" Text="NA" Font-Bold="true" onclick="return EmailNAClick();" />
                                    </span>
                                </h4>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        <span class="star">*</span>Address:</label>
                                    <span class="left2">
                                        <asp:TextBox ID="txtAddress" runat="server" MaxLength="40"></asp:TextBox>
                                </h4>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        <span class="star">*</span>City:</label>
                                    <span class="left2">
                                        <asp:TextBox ID="txtCity" runat="server" MaxLength="40" Style="width: 110px;"></asp:TextBox>
                                        &nbsp;
                                        <label>
                                            <span class="star">*</span>State:</label>
                                        <asp:DropDownList ID="ddlLocationState" runat="server" Style="width: 100px">
                                        </asp:DropDownList>
                                        &nbsp;
                                        <label>
                                            <span class="star">*</span>ZIP:</label>
                                        <asp:TextBox ID="txtZip" runat="server" Style="width: 74px" MaxLength="5" class="sample4"
                                            onkeypress="return isNumberKey(event)" onblur="return ZipOnblur();"></asp:TextBox>
                                    </span>
                                </h4>
                            </td>
                        </tr>
                    </table>
                    <!-- End  -->
                </div>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <!-- SELLER INFORMATION End -->
            <div class="clear">
                &nbsp;</div>
            <!-- VEHICLE INFORMATION Start -->
            <div class=" box1 boxBlue">
                <h1 class="hed1 hed2">
                    VEHICLE INFORMATION</h1>
                <div class="inn">
                    <!-- Start  -->
                    <table class="table2">
                        <tr>
                            <td style="width: 31%">
                                <h4 class="field">
                                    <label class="left">
                                        <span class="star">*</span>Make:</label>
                                    <span class="left2">
                                        <asp:UpdatePanel ID="updtMake" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlMake" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMake_SelectedIndexChanged"
                                                    onchange="ChangeValuesHidden()">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </span>
                                </h4>
                            </td>
                            <td style="width: 3%;">
                                &nbsp;
                            </td>
                            <td style="width: 31%">
                                <h4 class="field">
                                    <label class="left">
                                        <span class="star">*</span>Model:</label>
                                    <span class="left2">
                                        <asp:UpdatePanel ID="updtpnlModel" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlModel" runat="server" onchange="ChangeValuesHidden()">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </span>
                                </h4>
                            </td>
                            <td style="width: 3%;">
                                &nbsp;
                            </td>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        <span class="star">*</span>Year:</label>
                                    <span class="left2">
                                        <asp:DropDownList ID="ddlYear" runat="server">
                                        </asp:DropDownList>
                                    </span>
                                </h4>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        <span class="star">*</span>Price:</label>
                                    <span class="left2">
                                        <asp:TextBox ID="txtAskingPrice" runat="server" MaxLength="6" class="sample4" onkeypress="return isNumberKey(event);"></asp:TextBox></span>
                                </h4>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        Mileage:</label>
                                    <span class="left2">
                                        <asp:TextBox ID="txtMileage" runat="server" MaxLength="6" class="sample4" onkeypress="return isNumberKey(event);"></asp:TextBox></span>
                                </h4>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        Cylinders:</label>
                                    <span class="left2">
                                        <asp:DropDownList ID="ddlcylindars" runat="server">
                                        </asp:DropDownList>
                                    </span>
                                </h4>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        Body style:</label>
                                    <span class="left2">
                                        <asp:DropDownList ID="ddlBodyStyle" runat="server" onchange="ChangeValuesHidden()">
                                        </asp:DropDownList>
                                    </span>
                                </h4>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        Exterior color:</label>
                                    <span class="left2">
                                        <asp:DropDownList ID="ddlExteriorColor" runat="server">
                                        </asp:DropDownList>
                                    </span>
                                </h4>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        Interior color:</label>
                                    <span class="left2">
                                        <asp:DropDownList ID="ddlInteriorColor" runat="server">
                                        </asp:DropDownList>
                                    </span>
                                </h4>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        Transmission:</label>
                                    <span class="left2">
                                        <asp:DropDownList ID="ddltransm" runat="server">
                                        </asp:DropDownList>
                                    </span>
                                </h4>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        Doors:</label>
                                    <span class="left2">
                                        <asp:DropDownList ID="ddldoors" runat="server">
                                        </asp:DropDownList>
                                    </span>
                                </h4>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        Drive train:</label>
                                    <span class="left2">
                                        <asp:DropDownList ID="ddldrivetrain" runat="server">
                                        </asp:DropDownList>
                                    </span>
                                </h4>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        Fuel type:</label>
                                    <span class="left2">
                                        <asp:DropDownList ID="ddlfueltype" runat="server">
                                        </asp:DropDownList>
                                    </span>
                                </h4>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        Condition:</label>
                                    <span class="left2">
                                        <asp:DropDownList ID="ddlcondition" runat="server">
                                        </asp:DropDownList>
                                    </span>
                                </h4>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        VIN #:</label>
                                    <span class="left2">
                                        <asp:TextBox ID="txtVin" runat="server" Style="width: 409px" MaxLength="20"></asp:TextBox></span>
                                </h4>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <!-- VEHICLE INFORMATION End  -->
            <div class="clear">
                &nbsp;</div>
            <!-- VEHICLE FEATURES Start  -->
            <div class=" box1 boxBlue">
                <h1 class="hed1 hed2">
                    VEHICLE FEATURES</h1>
                <div class="inn">
                    <!-- Start  -->
                    <table class="table3">
                        <tr>
                            <td style="width: 120px;">
                                <label class="hed2">
                                    Comfort:</label>
                            </td>
                            <td class="chkLabel">
                                <label class="act">
                                    <asp:CheckBox ID="chkFeatures51" runat="server" class="noLM" />
                                    A/C</label>
                                <label class="act">
                                    <asp:CheckBox ID="chkFeatures1" runat="server" class="noLM" />
                                    A/C: Front</label>
                                <label class="act">
                                    <asp:CheckBox ID="chkFeatures2" runat="server" class="noLM" />
                                    A/C: Rear</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures3" runat="server" class="noLM" />
                                    Cruise control</label>
                                <label class="act">
                                    <asp:CheckBox ID="chkFeatures4" runat="server" class="noLM" />
                                    Navigation system</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures5" runat="server" class="noLM" />
                                    Power locks</label>
                                <label class="act">
                                    <asp:CheckBox ID="chkFeatures6" runat="server" class="noLM" />
                                    Power steering</label>
                                <label class="act">
                                    <asp:CheckBox ID="chkFeatures7" runat="server" class="noLM" />
                                    Remote keyless entry</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures8" runat="server" class="noLM" />
                                    TV/VCR
                                </label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures31" runat="server" class="noLM" />Remote start</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures33" runat="server" class="noLM" />Tilt
                                </label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures35" runat="server" class="noLM" />Rearview camera</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures36" runat="server" class="noLM" />Power mirrors</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="hed2">
                                    Seats:</label>
                            </td>
                            <td class="chkLabel">
                                <label>
                                    <asp:CheckBox ID="chkFeatures9" runat="server" class="noLM" />Bucket seats</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures11" runat="server" />Memory seats</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures12" runat="server" />Power seats</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures32" runat="server" />Heated seats
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="hed2">
                                    Interior:</label>
                            </td>
                            <td class="chkLabel">
                                <label>
                                    <asp:RadioButton ID="rdbtnLeather" runat="server" CssClass="noLM" GroupName="Seats"
                                        Text="" />Leather</label>
                                <label>
                                    <asp:RadioButton ID="rdbtnVinyl" runat="server" CssClass="noLM" GroupName="Seats"
                                        Text="" />Vinyl</label>
                                <label>
                                    <asp:RadioButton ID="rdbtnCloth" runat="server" CssClass="noLM" GroupName="Seats"
                                        Text="" /><span class="featNon">Cloth</label>
                                <label>
                                    <asp:RadioButton ID="rdbtnInteriorNA" runat="server" CssClass="noLM" GroupName="Seats"
                                        Text="" Checked="true" />NA</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="hed2">
                                    Safety:</label>
                            </td>
                            <td class="chkLabel">
                                <label>
                                    <asp:CheckBox ID="chkFeatures13" runat="server" class="noLM" />Airbag: Driver</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures14" runat="server" class="noLM" />Airbag: Passenger</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures15" runat="server" class="noLM" />Airbag: Side</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures16" runat="server" class="noLM" />Alarm</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures17" runat="server" class="noLM" />Anti-lock brakes</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures18" runat="server" class="noLM" />Fog lights</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures39" runat="server" class="noLM" />Power brakes</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="hed2">
                                    Sound System:</label>
                            </td>
                            <td class="chkLabel">
                                <label>
                                    <asp:CheckBox ID="chkFeatures19" runat="server" class="noLM" />Cassette radio</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures20" runat="server" class="noLM" />CD changer</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures21" runat="server" class="noLM" />CD player</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures22" runat="server" class="noLM" />Premium sound</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures34" runat="server" class="noLM" />AM/FM</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures40" runat="server" class="noLM" />DVD</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="hed2">
                                    New:</label>
                            </td>
                            <td class="chkLabel">
                                <label>
                                    <asp:CheckBox ID="chkFeatures44" runat="server" class="noLM" />Battery</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures45" runat="server" class="noLM" />Tires</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures52" runat="server" class="noLM" />Rotors</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures53" runat="server" class="noLM" />Brakes</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="hed2">
                                    Windows:</label>
                            </td>
                            <td class="chkLabel">
                                <label>
                                    <asp:CheckBox ID="chkFeatures23" runat="server" class="noLM" />Power windows</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures24" runat="server" class="noLM" />Rear window defroster</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures25" runat="server" class="noLM" />Rear window wiper</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures26" runat="server" class="noLM" />Tinted glass</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="hed2">
                                    Others:</label>
                            </td>
                            <td class="chkLabel">
                                <label>
                                    <asp:CheckBox ID="chkFeatures27" runat="server" class="noLM" />Alloy wheels</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures28" runat="server" class="noLM" />Sunroof</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures41" runat="server" class="noLM" />Panoramic roof</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures42" runat="server" class="noLM" />Moonroof</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures29" runat="server" class="noLM" />Third row seats</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures30" runat="server" class="noLM" />Tow package</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures43" runat="server" class="noLM" />Dashboard wood frame</label>
                            </td>
                        </tr>
                        <tr class="last">
                            <td>
                                <label class="hed2">
                                    Specials:</label>
                            </td>
                            <td class="chkLabel">
                                <label>
                                    <asp:CheckBox ID="chkFeatures46" runat="server" class="noLM" />Garage kept</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures47" runat="server" class="noLM" />Non smoking</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures48" runat="server" class="noLM" />Records/Receipts
                                    kept</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures49" runat="server" class="noLM" />Well maintained</label>
                                <label>
                                    <asp:CheckBox ID="chkFeatures50" runat="server" class="noLM" />Regular oil changes</label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <!-- VEHICLE FEATURES End  -->
            <div class="clear">
                &nbsp;</div>
            <!-- VEHICLE DESCRIPTION Start  -->
            <div class=" box1 boxBlue">
                <h1 class="hed1 hed2">
                    VEHICLE FEATURES</h1>
                <div class="inn">
                    <h4 class="field">
                        <span class="left2 noMrg">
                            <asp:TextBox ID="txtDescription" runat="server" MaxLength="1000" Style="width: 99%;
                                height: 75px; resize: none;" TextMode="MultiLine" CssClass="textAr" data-plus-as-tab="false"></asp:TextBox></textarea></span>
                    </h4>
                </div>
            </div>
            <!-- VEHICLE DESCRIPTION End  -->
            <!-- SALE NOTES Start  -->
            <div class=" box1 boxBlue">
                <h1 class="hed1 hed2">
                    SALE NOTES</h1>
                <div class="inn">
                    <table>
                        <tr>
                            <td style="vertical-align: top;">
                                <h4 class="field">
                                    <span class="left2 noMrg">
                                        <asp:TextBox ID="txtSaleNotes" runat="server" TextMode="MultiLine" MaxLength="1000"
                                            Style="width: 99%; height: 105px; resize: none;" CssClass="textAr" data-plus-as-tab="false"> </asp:TextBox></span>
                                </h4>
                            </td>
                            <td style="width: 40px;">
                                &nbsp;
                            </td>
                            <td style="width: 350px; vertical-align: text-bottom;">
                                <h4 class="field">
                                    <label class="left">
                                        Source of photos:</label>
                                    <span class="left2">
                                        <asp:DropDownList ID="ddlPhotosSource" runat="server" onchange="ChangeValuesHidden()">
                                        </asp:DropDownList>
                                    </span>
                                </h4>
                                <h4 class="field">
                                    <label class="left">
                                        Source of description:</label>
                                    <span class="left2">
                                        <asp:DropDownList ID="ddlDescriptionSource" runat="server">
                                        </asp:DropDownList>
                                    </span>
                                </h4>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <!-- SALE NOTES End  -->
            <!-- PAYMENT DETAILS Start  -->
            <div class=" box1 boxBlue">
                <h1 class="hed1 hed2">
                    PAYMENT DETAILS</h1>
                <div class="inn">
                    <table style="width: 350px;">
                        <tr>
                            <td>
                                <h4 class="field">
                                    <label class="left">
                                        Pay method:</label>
                                    <span class="left2">
                                        <asp:DropDownList ID="ddlpayme" runat="server">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Mastercard</asp:ListItem>
                                            <asp:ListItem Value="2">Discover</asp:ListItem>
                                            <asp:ListItem Value="3">Amex</asp:ListItem>
                                            <asp:ListItem Value="4">Paypal</asp:ListItem>
                                            <asp:ListItem Value="5">Check</asp:ListItem>
                                        </asp:DropDownList>
                                        <%--<asp:RadioButton ID="rdbtnPayVisa" CssClass="noLM" Text="Visa" Checked="true" GroupName="PayType"
                                            runat="server" OnCheckedChanged="rdbtnPayVisa_CheckedChanged" AutoPostBack="true" />
                                        <asp:RadioButton ID="rdbtnPayMasterCard" CssClass="noLM" Text="Mastercard" GroupName="PayType"
                                            runat="server" OnCheckedChanged="rdbtnPayMasterCard_CheckedChanged" AutoPostBack="true" />
                                        <asp:RadioButton ID="rdbtnPayDiscover" CssClass="noLM" Text="Discover" GroupName="PayType"
                                            runat="server" OnCheckedChanged="rdbtnPayDiscover_CheckedChanged" AutoPostBack="true" />
                                        <asp:RadioButton ID="rdbtnPayAmex" CssClass="noLM" Text="Amex" GroupName="PayType"
                                            runat="server" OnCheckedChanged="rdbtnPayAmex_CheckedChanged" AutoPostBack="true" />
                                        <asp:RadioButton ID="rdbtnPayPaypal" CssClass="noLM" Text="Paypal" GroupName="PayType"
                                            runat="server" OnCheckedChanged="rdbtnPayPaypal_CheckedChanged" AutoPostBack="true" />
                                        <asp:RadioButton ID="rdbtnPayCheck" CssClass="noLM" Text="Check" GroupName="PayType"
                                            runat="server" OnCheckedChanged="rdbtnPayCheck_CheckedChanged" AutoPostBack="true" /></span>--%>
                                </h4>
                            </td>
                        </tr>
                    </table>
                    <div class="clear">
                        &nbsp;</div>
                    <br />
                    <!-- Card Details Start -->
                    <fieldset class="filedSet">
                        <div id="divcard" runat="server">
                            <legend>Card Details <span>
                                <asp:LinkButton ID="lnkbtnCopySellerInfo" runat="server" Text="Copy name & address from Seller Information"
                                    OnClientClick="return CopySellerInfo();" Style="color: Blue; text-decoration: underline;"></asp:LinkButton>
                            </legend>
                            <div class="inn">
                                <table>
                                    <tr>
                                        <td>
                                            <h4 class="field">
                                                <label class="left">
                                                    <span class="star">*</span>Card Holder First Name:</label>
                                                <span class="left2">
                                                    <asp:HiddenField ID="CardType" runat="server" />
                                                    <asp:TextBox ID="txtCardholderName" runat="server" MaxLength="25" Style="width: 170px;" />
                                                    <label>
                                                        <span class="star">*</span>Last Name:</label>
                                                    <asp:TextBox ID="txtCardholderLastName" runat="server" MaxLength="25" Style="width: 110px" />
                                                </span>
                                            </h4>
                                        </td>
                                        <td style="width: 40px;">
                                            &nbsp;
                                        </td>
                                        <td style="width: 350px;">
                                            <h4 class="field">
                                                <label class="left">
                                                    <span class="star">*</span>Address:</label>
                                                <span class="left2">
                                                    <asp:TextBox ID="txtbillingaddress" runat="server" MaxLength="40"></asp:TextBox></span>
                                            </h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="field">
                                                <label class="left">
                                                    <span class="star">*</span>Credit Card:</label>
                                                <span class="left2">
                                                    <asp:TextBox runat="server" ID="CardNumber" MaxLength="16" onkeypress="return isNumberKey(event)"
                                                        onblur="return CreditCardOnblur();" /></span>
                                            </h4>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <h4 class="field">
                                                <label class="left">
                                                    <span class="star">*</span>City:</label>
                                                <span class="left2">
                                                    <asp:TextBox ID="txtbillingcity" runat="server" MaxLength="40"></asp:TextBox></span>
                                            </h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="field">
                                                <label class="left">
                                                    <span class="star">*</span>Expiry Date:</label>
                                                <span class="left2">
                                                    <asp:DropDownList ID="ExpMon" Style="width: 130px;" runat="server">
                                                        <asp:ListItem Value="0" Text="Select Month"></asp:ListItem>
                                                        <asp:ListItem Value="01" Text="01"></asp:ListItem>
                                                        <asp:ListItem Value="02" Text="02"></asp:ListItem>
                                                        <asp:ListItem Value="03" Text="03"></asp:ListItem>
                                                        <asp:ListItem Value="04" Text="04"></asp:ListItem>
                                                        <asp:ListItem Value="05" Text="05"></asp:ListItem>
                                                        <asp:ListItem Value="06" Text="06"></asp:ListItem>
                                                        <asp:ListItem Value="07" Text="07"></asp:ListItem>
                                                        <asp:ListItem Value="08" Text="08"></asp:ListItem>
                                                        <asp:ListItem Value="09" Text="09"></asp:ListItem>
                                                        <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                                        <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                                        <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    /
                                                    <asp:DropDownList ID="CCExpiresYear" Style="width: 120px" runat="server">
                                                    </asp:DropDownList>
                                                </span>
                                            </h4>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <h4 class="field">
                                                <label class="left">
                                                    <span class="star">*</span>State:</label>
                                                <span class="left2">
                                                    <asp:DropDownList ID="ddlbillingstate" runat="server" Style="width: 120px">
                                                    </asp:DropDownList>
                                                    <label>
                                                        <span class="star">*</span>ZIP:</label>&nbsp;
                                                    <asp:TextBox ID="txtbillingzip" runat="server" Style="width: 74px" MaxLength="5"
                                                        onkeypress="return isNumberKey(event)" onblur="return billingZipOnblur();"></asp:TextBox>
                                                </span>
                                            </h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h4" style="display: none;">
                                                <span class="star" style="color: Red">*</span><strong style="width: 40px">CVV#</strong>
                                                <asp:TextBox ID="cvv" MaxLength="4" runat="server" onkeypress="return isNumberKey(event)"
                                                    onblur="return CVVOnblur(); " />
                                            </h4>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <!-- Credit Card End  -->
                        <div class="clear">
                            &nbsp;</div>
                        <!-- check Start  -->
                        <div id="divcheck" runat="server" style="display: none;">
                            <table border="0" cellpadding="4" cellspacing="4" style="width: 98%; margin: 0;">
                                <tr>
                                    <td>
                                        <h5 style="display: inline-block; margin: 0; font-size: 15px;">
                                            Check Details</h5>
                                        <h5 style="font-size: 12px; font-weight: normal; margin: 0; display: inline-block">
                                            <asp:LinkButton ID="lnkbtnCopyCheckName" runat="server" Text="Copy name from Seller Information"
                                                OnClientClick="return CopySellerInfoForCheck();" Style="color: Blue; text-decoration: underline;"></asp:LinkButton>
                                        </h5>
                                        <table style="width: 80%;">
                                            <tr>
                                                <td>
                                                    <h4 class="h4">
                                                        <span class="star" style="color: Red">*</span><strong style="width: 125px">Account holder
                                                            name</strong>
                                                        <asp:TextBox ID="txtCustNameForCheck" runat="server" MaxLength="50"></asp:TextBox>
                                                    </h4>
                                                </td>
                                                <td>
                                                    <h4 class="h4">
                                                        <span class="star" style="color: Red">*</span><strong style="width: 60px">Account #</strong>
                                                        <asp:TextBox ID="txtAccNumberForCheck" runat="server" MaxLength="20"></asp:TextBox>
                                                    </h4>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <h4 class="h4">
                                                        <strong style="width: 67px">Bank name:</strong>
                                                        <asp:TextBox ID="txtBankNameForCheck" runat="server" MaxLength="50"></asp:TextBox>
                                                    </h4>
                                                </td>
                                                <td>
                                                    <h4 class="h4">
                                                        <span class="star" style="color: Red">*</span><strong style="width: 60px">Routing #</strong>
                                                        <asp:TextBox ID="txtRoutingNumberForCheck" runat="server" MaxLength="9"></asp:TextBox>
                                                    </h4>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <h4 class="h4">
                                                        <span class="star" style="color: Red">*</span><strong style="width: 76px">Account type</strong>
                                                        <asp:DropDownList ID="ddlAccType" runat="server">
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="1">CHECKING</asp:ListItem>
                                                            <asp:ListItem Value="2">SAVINGS</asp:ListItem>
                                                            <asp:ListItem Value="3">BUSINESSCHECKING</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </h4>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                        <div style="width: 45%; display: inline-block; float: left; margin-right: 10px;">
                                        </div>
                                        <div style="width: 45%; display: inline-block; float: left">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!-- check End  -->
                        <div class="clear">
                            &nbsp;</div>
                        <!-- paypal Start  -->
                        <div id="divpaypal" runat="server" style="display: none;">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <h5 style="display: inline-block; margin: 0; font-size: 15px;">
                                            Paypal Details</h5>
                                        <div id="Div1" runat="server" style="width: 80%;">
                                            <table>
                                                <%-- <tr>
                                                                            <td>
                                                                                <h4 class="h4">
                                                                                    <span class="star" style="color: Red">*</span><strong style="width: 90px">Payment date:</strong>
                                                                                  
                                                                                    <asp:DropDownList ID="ddlPaymentdate" runat="server" onchange="ChangeValuesHidden()"
                                                                                        Width="195px">
                                                                                    </asp:DropDownList>
                                                                                </h4>
                                                                            </td>
                                                                            <td>
                                                                                <h4 class="h4">
                                                                                    <span class="star" style="color: Red">*</span><strong style="width: 40px">Amount:</strong>
                                                                                  
                                                                                    <asp:TextBox ID="txtPayAmount" runat="server" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"
                                                                                        onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                                                </h4>
                                                                            </td>
                                                                        </tr>--%>
                                                <tr>
                                                    <td>
                                                        <h4 class="h4">
                                                            <span class="star" style="color: Red">*</span><strong style="width: 100px">Payment trans
                                                                ID:</strong>
                                                            <%-- <input type="text" style="width: 245px" />--%>
                                                            <asp:TextBox ID="txtPaytransID" runat="server" MaxLength="30"></asp:TextBox>
                                                        </h4>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <h4 class="h4">
                                                            <span class="star" style="color: Red">*</span><strong style="width: 140px">Paypal account
                                                                email:</strong>
                                                            <%-- <input type="text" style="width: 245px" />--%>
                                                            <asp:TextBox ID="txtpayPalEmailAccount" runat="server" onblur="return PaypalEmailblur();"></asp:TextBox>
                                                        </h4>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="clear">
                                            &nbsp;</div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!-- paypal End  -->
                        <div class="clear">
                            &nbsp;</div>
                        <!-- Post Date End  -->
                        <!-- Post Date End  -->
                        <div class="clear">
                            &nbsp;</div>
                    </fieldset>
                    <!-- Card Details End -->
                    <!-- Payment Schedule Start  -->
                    <fieldset class="filedSet">
                        <legend>Payment Schedule</legend>
                        <div class="inn">
                            <table style="width: 70%">
                                <tr>
                                    <td>
                                        <h4 class="field">
                                            <label class="left" style="width: 175px">
                                                Today's Payment Date:</label>
                                            <span class="left2">
                                                <asp:TextBox ID="txtPaymentDate" runat="server" Style="width: 120px;" ReadOnly="true"></asp:TextBox>
                                                <img src="images/Calender.gif" />
                                            </span>
                                        </h4>
                                    </td>
                                    <td style="width: 15px;">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <span class="star">*</span> <strong style="width: 55px">Amount $</strong>
                                        <asp:TextBox ID="txtPDAmountNow" runat="server" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"
                                            onkeyup="return ChangeValuesHidden()" Style="width: 76%; float: right;"></asp:TextBox>
                                        </h4>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h4 class="field">
                                            <label class="left" style="width: 175px">
                                                Post Dated Payment Date:</label>
                                            <span class="left2">
                                                <asp:CheckBox ID="chkboxlstPDsale" runat="server" CssClass="noLM" />
                                                <asp:DropDownList ID="ddlPDDate" runat="server" onchange="ChangeValuesHidden()" Width="120px"
                                                    ForeColor="Red">
                                                </asp:DropDownList>
                                                &nbsp;
                                                <img src="images/Calender.gif" />
                                            </span>
                                        </h4>
                                    </td>
                                    <td style="width: 15px;">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <h4 class="field">
                                            <span class="left2 noMrg"><strong style="width: 55px">Amount $</strong>
                                                <asp:TextBox ID="txtPDAmountLater" runat="server" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"
                                                    onkeyup="return ChangeValuesHidden()" Enabled="false" Style="width: 75%; float: right;"></asp:TextBox>
                                        </h4>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="width: 15px;">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <h4 class="field">
                                            <span class="left2 noMrg">
                                                <input type="text" value="Total $" style="width: 96%; float: right;" /></span>
                                        </h4>
                                    </td>
                                </tr>
                                <tr>
                                </tr>
                            </table>
                        </div>
                    </fieldset>
                    <!-- Payment Schedule End  -->
                    <div class="clear">
                    </div>
                    <!-- Voice file confirmation Start  -->
                    <table>
                        <tr>
                            <td style="width: 36%">
                                <h4 class="field">
                                    <label class="left">
                                        <span class="star">*</span>Voice file confirmation #:</label>
                                    <span class="left2">
                                        <asp:TextBox ID="txtVoicefileConfirmNo" runat="server" MaxLength="30"></asp:TextBox>
                                    </span>
                                </h4>
                            </td>
                            <td style="width: 3%;">
                                &nbsp;
                            </td>
                            <td style="width: 36%">
                                <h4 class="field">
                                    <label class="left">
                                        <span class="star">*</span>Voice file Location :</label>
                                    <span class="left2">
                                        <asp:DropDownList ID="ddlVoiceFileLocation" runat="server">
                                        </asp:DropDownList>
                                    </span>
                                </h4>
                            </td>
                            <td style="width: 3%;">
                                &nbsp;
                            </td>
                            <td style="padding-top: 14px;">
                                <asp:Button ID="btnProcess" runat="server" Text="Process" class="btn btn-sm btn-success"
                                    Visible="true" Enabled="false" />
                            </td>
                        </tr>
                    </table>
                    <!-- Voice file confirmation Emd -->
                    <div class="clear">
                        &nbsp;</div>
                    <br />
                </div>
            </div>
            <!-- PAYMENT DETAILS End  -->
            <div style="text-align: right; padding: 10px 0 20px 0">
                <asp:UpdatePanel ID="updatePnlSave2" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnTransfer2" runat="server" CssClass="btn btn-warning btn-sm" Text="Transfer"
                            OnClientClick="return ValidateDraftData();" OnClick="btnTransfer_Click" />
                        &nbsp;
                        <asp:Button ID="btnSale2" runat="server" CssClass="btn btn-success btn-sm" Text="Sale"
                            OnClientClick="return ValidateSavedData();" OnClick="btnSale_Click" />
                        &nbsp;
                        <asp:Button ID="btnSavedraft2" runat="server" CssClass="btn btn-info btn-sm" Text="Save as draft"
                            OnClick="btnSavedraft_Click" OnClientClick="return ValidateDraftData();" />
                        &nbsp
                        <asp:Button ID="btnAbandon2" runat="server" CssClass="btn btn-danger btn-sm" Text="Abandon"
                            OnClick="btnAbandon_Click" OnClientClick="return ValidateAbandonData();" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <!-- Content End  -->
        <!-- Content End  -->
        <div class="clear">
            &nbsp;</div>
    </div>
    <!-- Main Wrapper Emd  -->
    <!-- Footer Start  -->
    <div class="footer">
        United Car Exchange © 2013
    </div>
    <cc1:ModalPopupExtender ID="MPEUpdate" runat="server" PopupControlID="tblChangePW2"
        BackgroundCssClass="ModalPopupBG" TargetControlID="HiddenField1" CancelControlID="ImageButton1">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <div id="tblChangePW2" style="display: none; width: 450px;" class="popup">
        <h2>
            Phone Number
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images\close.png" CssClass="floarR" /></h2>
        <div class="content">
            <asp:UpdatePanel ID="updat" runat="server">
                <ContentTemplate>
                    <table width="100%" style="margin-top: 10px;">
                        <tr>
                            <td style="width: 100px;">
                                <b>Phone #:</b> &nbsp;
                            </td>
                            <td style="width: 200px;">
                                <asp:TextBox ID="txtLoadPhone" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="updtpnlBtns" runat="server">
                <ContentTemplate>
                    <table style="width: 100%;">
                        <tr align="center">
                            <td colspan="4" style="padding-top: 15px;">
                                <div style="width: 240px; margin: 0 auto;">
                                    <asp:Button ID="btnPhoneOk" runat="server" Text="Ok" CssClass="btn btn-warning"
                                        OnClientClick="return ValidatePhone();" OnClick="btnPhoneOk_Click" />
                                    <asp:Button ID="btnPhoneCancel" runat="server" Text="Cancel" CssClass="btn btn-default" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mdepDraftExistsShow" runat="server" PopupControlID="divDraftExistsShow"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnDraftExistsShow">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnDraftExistsShow" runat="server" />
    <div id="divDraftExistsShow" class="alert" style="display: none">
        <h4 id="H6">
            Alert
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblDraftExistsShow" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnDraftExistsShowNo" class="btn" runat="server" Text="No" OnClick="btnDraftExistsShowNo_Click" />&nbsp;
            <asp:Button ID="btnDraftExistsShowYes" class="btn" runat="server" Text="Yes" OnClick="btnDraftExistsShowYes_Click" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="MdepAddAnotherCarAlert" runat="server" PopupControlID="divAddAnotherCarAlert"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAddAnotherCarAlert">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAddAnotherCarAlert" runat="server" />
    <div id="divAddAnotherCarAlert" class="alert" style="display: none">
        <h4 id="H7">
            Alert
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblAddAnotherCarAlertError" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnAddAnotherCarNo" class="btn" runat="server" Text="No" OnClick="btnAddAnotherCarNo_Click" />&nbsp;
            <asp:Button ID="btnAddAnotherCarYes" class="btn" runat="server" Text="Yes" OnClick="btnAddAnotherCarYes_Click" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mdepAlertAfterSave" runat="server" PopupControlID="divAlertAfterSave"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertAfterSave">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertAfterSave" runat="server" />
    <div id="divAlertAfterSave" class="alert" style="display: none">
        <h4 id="H8">
            Alert
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblAlertAfterSave" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnAlertAfterSaveNo" class="btn" runat="server" Text="No" OnClick="btnAlertAfterSaveNo_Click" />&nbsp;
            <asp:Button ID="btnAlertAfterSaveYes" class="btn" runat="server" Text="Yes" OnClick="btnAlertAfterSaveYes_Click" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mdepExistsAlertShow" runat="server" PopupControlID="divExistsAlertShow"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnExistsAlertShow">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnExistsAlertShow" runat="server" />
    <div id="divExistsAlertShow" class="alert" style="display: none">
        <h4 id="H5">
            Alert
            <asp:Button ID="btnAlertExistTop" class="cls" runat="server" Text="" BorderWidth="0"
                OnClick="btnAlertExistShow_Click" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblExistsAlertShow" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnAlertExistShow" class="btn" runat="server" Text="Ok" OnClick="btnAlertExistShow_Click" />
        </div>
    </div>
    </form>
</body>
</html>
