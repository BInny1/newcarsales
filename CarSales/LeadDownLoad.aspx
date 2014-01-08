<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeadDownLoad.aspx.cs" Inherits="LeadDownLoad" %>

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

    <script src="js/overlibmws.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">window.history.forward(1);</script>

    <script src="Test/Calendar.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script type="text/javascript" language="javascript">

     function poptastic(url)
{
	newwindow=window.open(url,'name','directories=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,height=420,width=300');
	    if (window.focus) {newwindow.focus()}
    }
         function poptasticTest(url)
        {
        //$('#newTab a').click();
           // alert(url);
            
           // var e = $.Event("click");
            //$("#newTab a").trigger('click');
            window.open(url,'_newtab');
            
           // window.onload =  window.close();
           // $('#newTab').attr('href', );   
         
            
            //return false;
        }
        function pageLoad() {
            //InitializeTimer();
           
        }
     


        function ClientCheck()
    {
       
        var grid = document.getElementById("rptrDownload");  //Retrieve the grid   
      
    var inputs = document.getElementsByTagName("input"); //Retrieve all the input elements from the grid
    var isValid = false;
    for (var i=0; i < inputs.length; i += 1) { //Iterate over every input element retrieved
        if (inputs[i].type === "checkbox") { //If the current element's type is checkbox, then it is wat we need
            if(inputs[i].checked === true) { //If the current checkbox is true, then atleast one checkbox is ticked, so break the loop
                isValid = true;
                        break;
            }
        }
    }
    if(!isValid) {
        alert('Please Select Atleast One');
    }
        return isValid;
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

    <script type="text/javascript">

function checkAll(cb) 
{
       var ctrls = document.getElementsByTagName('input');
        for (var i = 0; i < ctrls.length; i++) 
          {
            var cbox = ctrls[i];
            if (cbox.type == "checkbox") 
            {
                cbox.checked = cb.checked;
            }
        }
} 
    </script>

    <script type="text/javascript" language="javascript">
     function isNumberKeyForDt(evt) {	

                    var charCode = (evt.which) ? evt.which : event.keyCode
                    if (charCode > 31 && (charCode < 48 || charCode > 57)&& charCode != 47)
                    return false;
                    return true;
                    }
    
    
        function Validate() {
            var valid = true;
            var today = new Date();
            var month = today.getMonth() + 1
            var day = today.getDate()
            var year = today.getFullYear()
            today = month + "/" + day + "/" + year
            var today = new Date(today);
            var SDate = document.getElementById('txtStartDate').value;
            var EDate = document.getElementById('txtEndDate').value;
            var endDate = new Date(EDate);
            var startDate = new Date(SDate);
            var Startmonth = startDate.getMonth() + 1
            var Startday = startDate.getDate()
            var Startyear = startDate.getFullYear()
            startDate = Startmonth + "/" + Startday + "/" + Startyear
            var startDate = new Date(startDate);

            var Endmonth = endDate.getMonth() + 1
            var Endday = endDate.getDate()
            var Endyear = endDate.getFullYear()
            var oneDay = 24 * 60 * 60 * 1000;

            endDate = Endmonth + "/" + Endday + "/" + Endyear

            var endDate = new Date(endDate);

            var ValidOldData = Math.abs((startDate.getTime() - today.getTime()) / (oneDay));
            var ValidDates = Math.abs((startDate.getTime() - endDate.getTime()) / (oneDay));
            
          
             if(document.getElementById('ddlVehicleType').value =="0")
            {
                alert("Select a Vehicle Category"); 
                valid=false;
                document.getElementById('ddlVehicleType').focus();  
                return valid;               
            }    
            if (SDate == '') {
                alert("Please enter start date");

                valid = false;
                return valid;
            }
            if (EDate == '') {

                alert("Please enter end date");
                valid = false;
                return valid;
            }
            var dtFromDt = document.getElementById('txtStartDate').value;
            if (isDate(dtFromDt) == false) {
                document.getElementById('txtStartDate').focus();
                valid = false;
                return valid;
            }

            var dtTodt = document.getElementById('txtEndDate').value;
            if (isDate(dtTodt) == false) {
                document.getElementById('txtEndDate').focus();
                valid = false;
                return valid;
            }                   
            
            if (SDate != '' && EDate != '' && startDate > endDate) {
                alert("Start date is greater than end date");
                valid = false;
                return valid;
            }
            if (startDate > today) {
                alert("Start date should not be greater Than current date");
                valid = false;
                return valid;
            }
            if (endDate > today) {

                alert("End date should not be greater than current date");
                valid = false;
                return valid;
            }
            if (ValidOldData >= 365) {
                alert("Report can be generated for maximum of one year prior. Please change the dates and resubmit again");
                document.getElementById('txtStartDate').focus();
                valid = false;
                return valid;
            }
            return valid;
        }


        var dtCh = "/";
        var Chktoday = new Date();
        var minYear = Chktoday.getFullYear() - 1;
        var maxYear = Chktoday.getFullYear();

        function isInteger(s) {
            var i;
            for (i = 0; i < s.length; i++) {
                // Check that current character is number.
                var c = s.charAt(i);
                if (((c < "0") || (c > "9"))) return false;
            }
            // All characters are numbers.
            return true;
        }

        function stripCharsInBag(s, bag) {
            var i;
            var returnString = "";
            // Search through string's characters one by one.
            // If character is not in bag, append to returnString.
            for (i = 0; i < s.length; i++) {
                var c = s.charAt(i);
                if (bag.indexOf(c) == -1) returnString += c;
            }
            return returnString;
        }

        function daysInFebruary(year) {
            // February has 29 days in any year evenly divisible by four,
            // EXCEPT for centurial years which are not also divisible by 400.
            return (((year % 4 == 0) && ((!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28);
        }
        function DaysArray(n) {
            for (var i = 1; i <= n; i++) {
                this[i] = 31
                if (i == 4 || i == 6 || i == 9 || i == 11) { this[i] = 30 }
                if (i == 2) { this[i] = 29 }
            }
            return this
        }

        function isDate(dtStr) {
            var daysInMonth = DaysArray(12)
            var pos1 = dtStr.indexOf(dtCh)
            var pos2 = dtStr.indexOf(dtCh, pos1 + 1)
            var strMonth = dtStr.substring(0, pos1)
            var strDay = dtStr.substring(pos1 + 1, pos2)
            var strYear = dtStr.substring(pos2 + 1)
            strYr = strYear
            if (strDay.charAt(0) == "0" && strDay.length > 1) strDay = strDay.substring(1)
            if (strMonth.charAt(0) == "0" && strMonth.length > 1) strMonth = strMonth.substring(1)
            for (var i = 1; i <= 3; i++) {
                if (strYr.charAt(0) == "0" && strYr.length > 1) strYr = strYr.substring(1)
            }
            month = parseInt(strMonth)
            day = parseInt(strDay)
            year = parseInt(strYr)
            if (pos1 == -1 || pos2 == -1) {
                alert("The date format should be : mm/dd/yyyy")
                return false
            }
            if (strMonth.length < 1 || month < 1 || month > 12) {
                alert("Please enter a valid month")
                return false
            }
            if (strDay.length < 1 || day < 1 || day > 31 || (month == 2 && day > daysInFebruary(year)) || day > daysInMonth[month]) {
                alert("Please enter a valid day")
                return false
            }

            if (strYear.length != 4 || year == 0 || year < minYear || year > maxYear) {
                //alert("Enter only these years "+minYear+" "+maxYear+" to get data");		
                alert("Leads can be downloaded for maximum of one year prior. Please change the dates and resubmit again");
                return false
            }
            if (dtStr.indexOf(dtCh, pos2 + 1) != -1 || isInteger(stripCharsInBag(dtStr, dtCh)) == false) {
                alert("Please enter a valid date")
                return false
            }
            return true
        }
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="SM" runat="server" EnablePageMethods="true">
    </cc1:ToolkitScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtpnlData"
        DisplayAfter="0">
        <ProgressTemplate>
            <div id="spinner">
                <h4>
                    <div>
                        Processing
                        <img src="images/loading.gif" />
                    </div>
                </h4>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
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
                        <li class="parent active"><a href="#">Leads <span class="cert"></span></a>
                            <ul class="sub1">
                                <li>
                                    <asp:LinkButton ID="LeadsUpload" runat="server" Text="Upload" Enabled="false" PostBackUrl="~/LeadsUpload.aspx"></asp:LinkButton></li><li>
                                <li class="act">
                                    <asp:LinkButton ID="LeadsDownLoad" runat="server" Text="Download" Enabled="false"
                                        PostBackUrl="~/LeadDownLoad.aspx"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Abondoned" runat="server" Text="Abondon" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="FreePackage" runat="server" Text="Free Pkg" Enabled="false"></asp:LinkButton></li>
                            </ul>
                        </li>
                        <li class="parent "><a href="#">Sales <span class="cert"></span></a>
                            <ul class="sub1">
                                <li>
                                    <asp:LinkButton ID="IntroMail" runat="server" Text="Intro Mial" Enabled="false" PostBackUrl="~/IntroMails.aspx"></asp:LinkButton></li>
                                <li>
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
                                <li>
                                    <asp:LinkButton ID="UsersLog" runat="server" Text="User Log" PostBackUrl="~/UserLog.aspx"
                                        Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="EditLog" runat="server" Text="Edit Log" PostBackUrl="~/EditLogs.aspx"
                                        Enabled="false"></asp:LinkButton></li>
                                <li class="last">
                                    <asp:LinkButton ID="SuperAdmin" runat="server" Text="Super Admin" PostBackUrl="~/SuperadminRights.aspx"></asp:LinkButton></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- Headder End  -->
        <!-- Content Start  -->
        <div class="content wid1000">
            <div class=" box1 box75p" style="margin-left: auto; margin-right: auto; float: none;">
                <h1 class="hed1 hed2">
                    Leads Download</h1>
                <div class="inn">
                    <asp:UpdatePanel ID="updtpnldata" runat="server">
                        <ContentTemplate>
                            <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCenterCode" runat="server" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 100px;">
                                                    Vehicle category<br />
                                                    <asp:DropDownList ID="ddlVehicleType" runat="server" AppendDataBoundItems="true">
                                                        <asp:ListItem Text="Cars" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="RVs" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Bikes" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Boats" Value="4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 90px;">
                                                    Center location &nbsp;
                                                    <asp:DropDownList ID="ddlCenter" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 270px; padding-top: 2px;">
                                                    <table style="width: 270px; float: left; border-collapse: collapse; margin-left: 0px;
                                                        margin-right: 13px;">
                                                        <tr>
                                                            <td colspan="3" align="left" style="padding: 0">
                                                                <div style="border-bottom: 1px #666 solid; text-align: center; width: 230px; margin: 0 auto 2px auto;
                                                                    font-weight: normal; padding-bottom: 2px;">
                                                                    Lead collection date range</div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 45%; padding: 0; text-align: right">
                                                                <asp:TextBox ID="txtStartDate" runat="server" class="input1 " MaxLength="10" onkeypress="return isNumberKeyForDt(event)"
                                                                    Width="70px"></asp:TextBox>&nbsp; <a onclick="showCalendarControl(txtStartDate)"
                                                                        href="#">
                                                                        <img src="images/Calender.gif" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                                                            border-bottom: 0px" title="Calendar Control" width="18" /></a>
                                                                <%-- <img id="imgcal" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                                                    border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtStartDate,'mm/dd/yyyy',this);"
                                                                    alt="Calendar Control" src="images/Calender.gif" width="18" />--%>
                                                                <%--  <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate">
                                                                </cc1:CalendarExtender>--%>
                                                            </td>
                                                            <td style="width: 26px; text-align: center; padding: 0;">
                                                                to
                                                            </td>
                                                            <td style="text-align: left; padding: 0;">
                                                                <asp:TextBox ID="txtEndDate" runat="server" class="input1 " MaxLength="10" onkeypress="return isNumberKeyForDt(event)"
                                                                    Width="70px"></asp:TextBox>&nbsp; <a onclick="showCalendarControl(txtEndDate)" href="#">
                                                                        <img src="images/Calender.gif" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                                                            border-bottom: 0px" title="Calendar Control" width="18" /></a>
                                                                <%--  <img id="img1" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                                                    border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtEndDate,'mm/dd/yyyy',this);"
                                                                    alt="Calendar Control" src="images/Calender.gif" width="18" />--%>
                                                                <%-- <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate">
                                                                </cc1:CalendarExtender>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <br />
                                                    <asp:Button runat="server" ID="btnGet" Text="Get" class="btn btn-warning btn-sm" OnClientClick="return Validate();"
                                                        OnClick="btnGet_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Label ID="lblResHead" runat="server" Style="color: Red;"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <div id="dvLeads" runat="server" style="width: 450px; float: left;" visible="false">
                                            <h4>
                                                Center wise leads
                                                <asp:Button runat="server" ID="btnView" Text="Lead to view/download" class="btn btn-default btn-sm floarR"
                                                    OnClick="btnView_Click" OnClientClick="return ClientCheck();" />&nbsp;</h4>
                                            <br />
                                            <table style="width: 450px;" class="table table-hover table-striped MB0 table1">
                                                <asp:Repeater ID="rptrDownload" runat="server" OnItemCommand="rptrDownload_ItemCommand"
                                                    OnItemDataBound="rptrDownload_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <tr class="tbHed">
                                                            <th>
                                                                <asp:CheckBox ID="chkBxHeader" onclick="javascript:checkAll(this);" runat="server" />
                                                            </th>
                                                            <th style="width: 40px;">
                                                                State
                                                            </th>
                                                            <th>
                                                                Total leads available
                                                            </th>
                                                            <th>
                                                                Leads downloaded
                                                            </th>
                                                            <th>
                                                                Leads to download
                                                            </th>
                                                        </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chk" runat="server"></asp:CheckBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblStateCode" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                                                                <asp:HiddenField ID="lblStateID" runat="server" Value='<%# Bind("State_ID") %>'>
                                                                </asp:HiddenField>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblToDownload" runat="server" Text='<%# Bind("TotalLeads") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Downloaded") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblTobeDownload" runat="server" Text='<%# Bind("ToDownload") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnView" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <!-- Content End  -->
        <div class="clear">
            &nbsp;</div>
        <div style="height: 10px;">
        </div>
    </div>
    <!-- Footer Start  -->
    <div class="footer">
        United Car Exchange © 2013
    </div>
    <!-- Footer End  -->
    <cc1:ModalPopupExtender ID="mdepAlertExists" runat="server" PopupControlID="divExists"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnExists" OkControlID="btnExustCls"
        CancelControlID="btnOk">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnExists" runat="server" />
    <div id="divExists" class="popup" style="display: none; width: 450px;">
        <h2 id="H2">
            Alert
            <asp:ImageButton ID="btnExustCls" runat="server" ImageUrl="images\close.png" CssClass="floarR" /></h2>
        <!-- <div class="cls">
            </div> -->
        <div class="content">
            <p>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrorExists" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnOk" class="btn" runat="server" Text="Ok" />
        </div>
    </div>
    <!-- Starts -->
    <cc1:ModalPopupExtender ID="MpeShowLeads" runat="server" PopupControlID="tblChangePW2"
        BackgroundCssClass="ModalPopupBG" TargetControlID="HiddenField1" CancelControlID="ImageButton1">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <div id="tblChangePW2" style="display: none; width: 1000px; height: 450px;" class="popup">
        <h2>
            Lead View Total of
            <asp:Label ID="lblLeadCnt" runat="server"></asp:Label>
            leads
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images\close.png" CssClass="floarR" /></h2>
        <div class="content">
            <div class="scroll1" style="border: 2px solid #CCC">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table class="table table-hover table-striped MB0 table1">
                            <tr>
                                <td>
                                    <asp:Repeater ID="rptrLeads" runat="server" OnItemDataBound="rptrLeads_ItemDataBound">
                                        <HeaderTemplate>
                                            <tr class="tbHed">
                                                <th style="width: 80px;">
                                                    Phone#
                                                </th>
                                                <th>
                                                    Price
                                                </th>
                                                <th>
                                                    Mileage
                                                </th>
                                                <th>
                                                    State
                                                </th>
                                                <th>
                                                    City
                                                </th>
                                                <th>
                                                    Zip
                                                </th>
                                                <th>
                                                    URL
                                                </th>
                                                <th>
                                                    Heading
                                                </th>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="lblIssuanceBatchID" runat="server" Text='<%# Bind("Phone") %>'></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTobeDownload" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Mileage") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Zip") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("URL") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("Heading") %>'></asp:Label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div>
                <asp:Button ID="btnDownload" runat="server" Text="Download" CssClass="btn btn-warning "
                    OnClick="btnDownload_Click" />&nbsp;
            </div>
        </div>
    </div>
    </form>
</body>
</html>
