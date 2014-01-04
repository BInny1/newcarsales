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
    <asp:ScriptManager ID="SM" runat="server" EnablePageMethods="true">
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
                                    <asp:LinkButton ID="LeadsDownLoad"  runat="server"   Text="Download"  Enabled="false"    PostBackUrl="~/LeadDownLoad.aspx"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Abondoned" runat="server" Text="Abondon" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="FreePackage" runat="server" Text="Free Pkg" Enabled="false"></asp:LinkButton></li>
                            </ul>
                        </li>
                        <li class="parent "><a href="#">Sales <span class="cert"></span></a>
                            <ul class="sub1">
                                <li>
                                    <asp:LinkButton ID="IntroMail" runat="server" Text="Intro Mial" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="NewEntry" runat="server" Text="New Entry" Enabled="false"></asp:LinkButton>
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
                        <li class="parent active"><a href="#">Admin <span class="cert"></span></a>
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
                                <li class="act">
                                    <asp:LinkButton ID="UsersLog" runat="server" Text="User Log" PostBackUrl="~/UserLog.aspx"
                                        Enabled="false"></asp:LinkButton></li>
                                <li class="last">
                                    <asp:LinkButton ID="EditLog" runat="server" Text="Edit Log" PostBackUrl="~/EditLogs.aspx"  Enabled="false"></asp:LinkButton></li>
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
      <div class="clear">&nbsp;</div>
      
      
      	<div class="box1">
        	<div class="inn">
            <h5>Transfer agent(s) are not available</h5>
        	<table>
            	<tr>
                	<td style="width:48%">
                    	<h4 class="field">
                        	<label class="left"><span class="star">*</span>Package: </label>
                        	<span class="left2">
                             <asp:DropDownList ID="ddlPackage" runat="server" onchange="return OnchangeCheckDiscount()">
                        </asp:DropDownList>
                            </span>		
						</h4>
                    </td>
                    <td style="width:40px;">&nbsp;</td>
                    <td style="text-align:right;">
                    	<input type="button" value="Transfer" class="btn btn-warning btn-sm" />
                        <input type="button" value="Sale" class="btn btn-success btn-sm" />
                        <input type="button" value="Save as draft" class="btn btn-info btn-sm" />
                        <input type="button" value="Abandon" class="btn btn-danger btn-sm" />
                    </td>
                </tr>
                <tr>
                	<td colspan="3" style="height:20px;">&nbsp;</td>
                </tr>
                <tr>
                	<td>
                    	<h4 class="field">
                        	<label class="left">Agent: </label>
                        	<span class="left2">
                            <select class="input11" >
                              <option value="0">Select</option>                              
                            </select>		
                            </span>		
						</h4>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                    	<h4 class="field">
                        	<label class="left">Verifier: </label>
                        	<span class="left2">
                            <select class="input11" >
                              <option value="0">Select</option>                              
                            </select>		
                            </span>		
						</h4>
                    </td>
                </tr>
            </table>
        	</div>
        </div>
      
       <div class="clear">&nbsp;</div> 
		<!-- SELLER INFORMATION Start -->
        <div class=" box1 boxBlue">
            <h1 class="hed1 hed2">SELLER INFORMATION</h1>
            <div class="inn">
            	<!-- Start  -->
                <table class="table2">
                	<tr>
                    	<td style="width:49%;">
                        	<h4 class="field">
                                <label class="left"><span class="star">*</span>First name:</label>
                                <span class="left2"><input type="text" /></span>		
                            </h4>
                        </td>
                        <td style="width:40px;">&nbsp;</td>
                        <td>
                        	<h4 class="field">
                                <label class="left"><span class="star">*</span>Last name:</label>
                                <span class="left2"><input type="text" /></span>		
                            </h4>
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        	<h4 class="field">
                                <label class="left"><span class="star">*</span>Phone #:</label>
                                <span class="left2"><input type="text" /></span>		
                            </h4>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                        	<h4 class="field">
                                <label class="left"><span class="star">*</span>Email:</label>
                                <span class="left2"><input type="text" style="width:336px;" />
                                	<input type="checkbox" /> &nbsp;<label>N/A</label>
                                </span>		
                            </h4>
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        	<h4 class="field">
                                <label class="left"><span class="star">*</span>Address:</label>
                                <span class="left2"><input type="text" /></span>		
                            </h4>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                        	<h4 class="field">
                                <label class="left"><span class="star">*</span>City:</label>
                                <span class="left2"><input type="text" style="width:110px;" /> &nbsp; 
                                	<label><span class="star">*</span>State:</label> <select style="width:120px;"><option>Unspecified</option></select> &nbsp; <label><span class="star">*</span>ZIP:</label> <input type="text" style="width:70px" />
                                </span>		
                            </h4>
                        </td>
                    </tr>                    
                   
                </table>
                <!-- End  -->
            </div>
            <div class="clear">&nbsp;</div>
        </div>
        <!-- SELLER INFORMATION End -->
        
        <div class="clear">&nbsp;</div>
        <!-- VEHICLE INFORMATION Start -->
         <div class=" box1 boxBlue">
            <h1 class="hed1 hed2">VEHICLE INFORMATION</h1>
            <div class="inn">
            	<!-- Start  -->
                <table class="table2">
                	<tr>
                    	<td style="width:31%">
                        	<h4 class="field">
                                <label class="left"><span class="star">*</span>Make:</label>
                                <span class="left2"><select><option>Unspecified</option></select></span>		
                            </h4>
                        </td>
                        <td style="width:3%;">&nbsp;</td>
                        <td style="width:31%">
                        	<h4 class="field">
                                <label class="left"><span class="star">*</span>Model:</label>
                                <span class="left2"><select><option>Unspecified</option></select></span>		
                            </h4>
                        </td>
                        <td style="width:3%;">&nbsp;</td>
                        <td>
                        	<h4 class="field">
                                <label class="left"><span class="star">*</span>Year:</label>
                                <span class="left2"><select><option>Unspecified</option></select></span>		
                            </h4>
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        	<h4 class="field">
                                <label class="left"><span class="star">*</span>Price:</label>
                                <span class="left2"><input type="text" /></span>		
                            </h4>
                        </td>
                        <td >&nbsp;</td>
                        <td>
                        	<h4 class="field">
                                <label class="left">Mileage:</label>
                                <span class="left2"><input type="text" /></span>		
                            </h4>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                        	<h4 class="field">
                                <label class="left">Cylinders:</label>
                                <span class="left2"><select><option>Unspecified</option></select></span>		
                            </h4>
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        	<h4 class="field">
                                <label class="left">Body style:</label>
                                <span class="left2"><select><option>Unspecified</option></select></span>		
                            </h4>
                        </td>
                        <td >&nbsp;</td>
                        <td>
                        	<h4 class="field">
                                <label class="left">Exterior color:</label>
                                <span class="left2"><select><option>Unspecified</option></select></span>		
                            </h4>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                        	<h4 class="field">
                                <label class="left">Interior color:</label>
                                <span class="left2"><select><option>Unspecified</option></select></span>		
                            </h4>
                        </td>
                    </tr>
                	<tr>
                    	<td>
                        	<h4 class="field">
                                <label class="left">Transmission:</label>
                                <span class="left2"><select><option>Unspecified</option></select></span>		
                            </h4>
                        </td>
                        <td >&nbsp;</td>
                        <td>
                        	<h4 class="field">
                                <label class="left">Doors:</label>
                                <span class="left2"><select><option>Unspecified</option></select></span>		
                            </h4>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                        	<h4 class="field">
                                <label class="left">Drive train:</label>
                                <span class="left2"><select><option>Unspecified</option></select></span>		
                            </h4>
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        	<h4 class="field">
                                <label class="left">Fuel type:</label>
                                <span class="left2"><select><option>Unspecified</option></select></span>		
                            </h4>
                        </td>
                        <td >&nbsp;</td>
                        <td>
                        	<h4 class="field">
                                <label class="left">Condition:</label>
                                <span class="left2"><select><option>Unspecified</option></select></span>		
                            </h4>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                        	<h4 class="field">
                                <label class="left">VIN #:</label>
                                <span class="left2"><input type="text" /></span>		
                            </h4>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        
        <!-- VEHICLE INFORMATION End  -->
        <div class="clear">&nbsp;</div>
        
        
        
        <!-- VEHICLE FEATURES Start  -->
         <div class=" box1 boxBlue">
            <h1 class="hed1 hed2">VEHICLE FEATURES</h1>
            <div class="inn">
            	<!-- Start  -->
                <table class="table3"> 
                	<tr>
                    	<td style="width:120px;"><label class="hed2">Comfort:</label></td>
                        <td class="chkLabel">
                        	<label class="act"><input type="checkbox" checked="checked">
                       	  A/C</label>   
<label class="act"><input type="checkbox" checked="checked">
A/C: Front</label>   
<label class="act"><input type="checkbox" checked="checked">
A/C: Rear</label>   
<label><input type="checkbox">Cruise control</label>   
<label class="act"><input type="checkbox" checked="checked">
Navigation system</label>   
<label><input type="checkbox">Power locks</label>   
<label class="act"><input type="checkbox" checked="checked">Power steering</label> 
<label class="act"><input type="checkbox" checked="checked">Remote keyless entry</label>   
<label><input type="checkbox">TV/VCR </label>  
<label><input type="checkbox">Remote start</label>  
<label><input type="checkbox">Tilt </label>  
<label><input type="checkbox">Rearview camera</label>   
<label><input type="checkbox">Power mirrors</label>
                        </td>
                    </tr>
                    <tr>
                    	<td><label class="hed2">Seats:</label></td>
                        <td class="chkLabel"><label><input type="checkbox">Bucket seats</label>  
<label><input type="checkbox">Memory seats</label>  
<label><input type="checkbox">Power seats</label>  
<label><input type="checkbox">Heated seats </label> </td>
                    </tr>
                    <tr>
                    	<td><label class="hed2">Interior:</label></td>
                        <td class="chkLabel"><label><input type="checkbox">Leather</label>  
<label><input type="checkbox">Vinyl</label>  
<label><input type="checkbox">Cloth</label>  
<label><input type="checkbox">NA</label> </td>
                    </tr>
                    <tr>
                    	<td><label class="hed2">Safety:</label></td>
                        <td class="chkLabel"><label><input type="checkbox">Airbag: Driver</label>  
<label><input type="checkbox">Airbag: Passenger</label>  
<label><input type="checkbox">Airbag: Side</label>  
<label><input type="checkbox">Alarm</label>  
<label><input type="checkbox">Anti-lock brakes</label>  
<label><input type="checkbox">Fog lights</label>  
<label><input type="checkbox">Power brakes</label></td>
                    </tr>
                    <tr>
                    	<td><label class="hed2">Sound System:</label></td>
                        <td class="chkLabel"><label><input type="checkbox">Cassette radio</label>  
<label><input type="checkbox">CD changer</label>  
<label><input type="checkbox">CD player</label>  
<label><input type="checkbox">Premium sound</label>  
<label><input type="checkbox">AM/FM</label>  
<label><input type="checkbox">DVD</label> </td>
                    </tr>
                    <tr>
                    	<td><label class="hed2">New:</label></td>
                        <td class="chkLabel"><label><input type="checkbox">Battery</label>  
<label><input type="checkbox">Tires</label>  
<label><input type="checkbox">Rotors</label>  
<label><input type="checkbox">Brakes</label></td>
                    </tr>
                    <tr>
                    	<td><label class="hed2">Windows:</label></td>
                        <td class="chkLabel"><label><input type="checkbox">Power windows</label>  
<label><input type="checkbox">Rear window defroster</label>  
<label><input type="checkbox">Rear window wiper</label>  
<label><input type="checkbox">Tinted glass</label></td>
                    </tr>
                    <tr>
                    	<td><label class="hed2">Others:</label></td>
                        <td class="chkLabel"><label><input type="checkbox">Alloy wheels</label>  
<label><input type="checkbox">Sunroof</label>  
<label><input type="checkbox">Panoramic roof</label>  
<label><input type="checkbox">Moonroof</label>  
<label><input type="checkbox">Third row seats</label>  
<label><input type="checkbox">Tow package</label>  
<label><input type="checkbox">Dashboard wood frame</label></td>
                    </tr>
                    <tr class="last">
                    	<td><label class="hed2">Specials:</label></td>
                        <td class="chkLabel"><label><input type="checkbox">Garage kept</label>
<label><input type="checkbox">Non smoking</label>
<label><input type="checkbox">Records/Receipts kept</label>
<label><input type="checkbox">Well maintained</label>
<label><input type="checkbox">Regular oil changes</label></td>
                    </tr>
                   
                </table>
            </div>
        </div>
        
        <!-- VEHICLE FEATURES End  -->
        <div class="clear">&nbsp;</div>
        
        
        <!-- VEHICLE DESCRIPTION Start  -->
        <div class=" box1 boxBlue">
            <h1 class="hed1 hed2">VEHICLE FEATURES</h1>
            <div class="inn">
            	<h4 class="field">
                	<span class="left2 noMrg"><textarea style="height:90px;"></textarea></span>		
                </h4>
            </div>
        </div>
        <!-- VEHICLE DESCRIPTION End  -->
        
        
        <!-- SALE NOTES Start  -->
        <div class=" box1 boxBlue">
            <h1 class="hed1 hed2">SALE NOTES</h1>
            <div class="inn">
            	<table>
                	<tr>
                    	<td style="vertical-align:top;">
                        	<h4 class="field">
                                <span class="left2 noMrg"><textarea style="height:90px;"></textarea></span>		
                            </h4>
                        </td>
                        <td style="width:40px;">&nbsp;</td>
                        <td style="width:350px; vertical-align:text-bottom;">
                        	<h4 class="field">
                                <label class="left">Source of photos:</label>
                                <span class="left2"><select >
  <option selected="selected" value="1">Customer will upload</option>
  <option value="2">Get from craigslist</option>
  <option value="3">Use stock photos</option>
</select></span>		
                            </h4>
                            <h4 class="field">
                                <label class="left">Source of description:</label>
                                <span class="left2"><select >
  <option selected="selected" value="1">Customer will enter</option>
  <option value="2">Get from craigslist</option>
  <option value="3">Use stock description</option>
</select></span>		
                            </h4>
                            
                             
                        </td>
                    </tr>
                </table>
            	
            </div>
        </div>
        <!-- SALE NOTES End  -->
        
        
        
        <!-- PAYMENT DETAILS Start  -->
        <div class=" box1 boxBlue">
            <h1 class="hed1 hed2">PAYMENT DETAILS</h1>
            <div class="inn">
            	<table style="width:350px;">
                	<tr>
                    	<td>
                        	<h4 class="field">
                                <label class="left">Pay method:</label>
                                <span class="left2"><select><option>Visa</option><option>Mastercard</option><option>Discover</option></select></span>		
                            </h4>
                        </td>
                    </tr>
                </table>
                <div class="clear">&nbsp;</div>
                <br />
                
                <!-- Card Details Start --> 
                <fieldset class="filedSet">
                	<legend>Card Details <span><a href="#">Copy name & address from Seller Information</a></span></legend>
                    <div class="inn">
                    	<table>
                	<tr>
                   	  <td>
                        	<h4 class="field">
                                <label class="left"><span class="star">*</span>Card Holder First Name:</label>
                                <span class="left2"><input type="text" style="width:170px;" />&nbsp;
                                <label><span class="star">*</span>Last Name:</label> <input type="text" style="width:110px" />	
                                </span>		
                            </h4>
                        </td>
                        <td style="width:40px;">&nbsp;</td>
                        <td style="width:350px;">
                        	<h4 class="field">
                                <label class="left"><span class="star">*</span>Address:</label>
                                <span class="left2"><input type="text" /></span>		
                            </h4>
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        	 
                            <h4 class="field">
                                <label class="left"><span class="star">*</span>Credit Card:</label>
                                <span class="left2"><input type="text" /></span>		
                            </h4>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                        	<h4 class="field">
                                <label class="left"><span class="star">*</span>City:</label>
                                <span class="left2"><input type="text" /></span>		
                            </h4>
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        	<h4 class="field">
                                <label class="left"><span class="star">*</span>Expiry Date:</label>
                                <span class="left2">
                                	<select style="width:160px;"><option>Select Month</option></select>&nbsp;
                                	<label> / </label>
                                    <select style="width:160px;"><option>Select Year</option></select>
                                </span>		
                            </h4>
                        </td>
                        <td></td>
                        <td>
                        	<h4 class="field">
                                <label class="left"><span class="star">*</span>State:</label>
                                <span class="left2">
                                	<select style="width:170px;"><option>Unspecified</option></select>&nbsp;
                                	<label><span class="star">*</span>ZIP:</label>&nbsp;
                                    <input type="text" style="width:80px;" />
                                </span>		
                            </h4>
                        </td>
                    </tr>
                    <tr>
                    	<td></td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
                    </div>
                </fieldset>
                 <!-- Card Details End -->  	
                   
                <!-- Payment Schedule Start  -->   
                <fieldset class="filedSet">
                	<legend>Payment Schedule</legend>
                    <div class="inn">
                    	<table style="width:70%">
                        	<tr>
                            	<td>
                                	<h4 class="field">
                                        <label class="left" style="width:175px" >Today's Payment Date:</label>
                                        <span class="left2">
                                        	<input type="text" style=" width:120px;" value="12/03/2013" />&nbsp;
                                            <img src="images/Calender.gif" />
                                        </span>		
                                    </h4>
                                </td>  
                                <td style="width:15px;">&nbsp;</td>   
                                <td>
                                	<h4 class="field">
                                        <span class="left2 noMrg"><span class="star">*</span><input type="text" class="disable" value="Amount $" style="width:96%; float:right;" /></span>		
                                    </h4>
                                </td>                           
                            </tr>
                            
                            <tr>
                            	<td>
                                	<h4 class="field">
                                        <label class="left" style="width:175px" >Post Dated Payment Date:</label>
                                        <span class="left2">                                        	
                                            <select style=" width:120px;" class="alert">
                                            	<option>Select</option>
                                            </select>&nbsp;
                                            <img src="images/Calender.gif" />
                                        </span>		
                                    </h4>
                                </td>  
                                <td style="width:15px;">&nbsp;</td>   
                                <td>
                                	<h4 class="field">
                                        <span class="left2 noMrg"><input type="text" class="disable" value="Amount $" style="width:96%; float:right;" /></span>		
                                    </h4>
                                </td>                           
                            </tr>
                            <tr>
                            	<td></td>  
                                <td style="width:15px;">&nbsp;</td>   
                                <td>
                                	<h4 class="field">
                                        <span class="left2 noMrg"><input type="text"  value="Total $" style="width:96%; float:right;" /></span>		
                                    </h4>
                                </td>                           
                            </tr>
                            
                            <tr></tr>
                        </table>
                    </div>
                </fieldset>              
                <!-- Payment Schedule End  -->
                
               
               <div class="clear"></div>
               
               <!-- Voice file confirmation Start  -->
               <table>
               		<tr>
                    	<td style="width:36%">
                        	<h4 class="field">
                                <label class="left"  ><span class="star">*</span>Voice file confirmation #:</label>
                                <span class="left2">                                        	
                                   <input type="text" />
                                </span>		
                            </h4>
                        </td>
                        <td style="width:3%;">&nbsp;</td>
                        <td style="width:36%">
                        	<h4 class="field">
                                <label class="left"  ><span class="star">*</span>Voice file Location :</label>
                                <span class="left2">                                        	
                                  <select >
  <option selected="selected" value="0">Unknown</option>
  <option value="1">Diamond voice</option>
  <option value="2">Dialer</option>
</select>
                                </span>		
                            </h4>
                        </td>
                        <td style="width:3%;">&nbsp;</td>
                        <td style="padding-top:14px;">
                        	<input type="button" value="Process" class="btn btn-sm btn-success" />
                        </td>
                    </tr>
               </table>
               <!-- Voice file confirmation Emd --> 
                <div class="clear">&nbsp;</div>
                <br />
                
               
                
                
                
            </div>
        </div>
        <!-- PAYMENT DETAILS End  -->
        
         <div style="text-align:right; padding:10px 0 20px 0">
                	<input type="button" value="Transfer" class="btn btn-warning btn-sm" />
                        <input type="button" value="Sale" class="btn btn-success btn-sm" />
                        <input type="button" value="Save as draft" class="btn btn-info btn-sm" />
                        <input type="button" value="Abandon" class="btn btn-danger btn-sm" />
                </div>
        
        
        <div class="clear">&nbsp;</div>
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
    </form>
</body>
</html>
