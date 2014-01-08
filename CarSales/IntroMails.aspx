<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IntroMails.aspx.cs" Inherits="IntroMails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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

    <!--Newly Added -->

    <script type="text/javascript" language="javascript">
    
        function Clear1()
        {        
          document.getElementById('<%= txtEmailAddress.ClientID%>').value = "";               
        }   
         function validationDataFirst()
        {
        debugger
            if(document.getElementById("<%=txtEmailAddress.ClientID%>").value.trim().length<1)
            {                    
            alert("Please enter email address to send");
            document.getElementById("<%=txtEmailAddress.ClientID%>").focus();
            valid=false;
            return valid;
            } 
            var Lines = document.getElementById("<%=txtEmailAddress.ClientID%>").value
            var ctrlLines=Lines.split('\n');                    
//            if (ctrlLines.length>50)
//            {
//            alert('More than 50 lines not allowed for search');                     
//            valid=false;
//            return valid;
//            }
            
            if(document.getElementById("<%=txtAgentName.ClientID%>").value.trim().length<1)
            {                    
            alert("Please enter marketing specialist name");
            document.getElementById("<%=txtAgentName.ClientID%>").focus();
            valid=false;
            return valid;
            }
            for( var i =0;i<ctrlLines.length ;i++)
            {
              if ((ctrlLines[i].trim().length > 0) && (echeck(ctrlLines[i].trim()) == false) )
              { 
                document.getElementById('<%=txtEmailAddress.ClientID%>').focus()
                valid=false;
                return valid;                          
              }   
            } 
        }
    </script>

    <script type="text/javascript" language="javascript">
     function echeck(str) {
            var at = "@"
            var dot = "."
            var lat = str.indexOf(at)
            var lstr = str.length
            var ldot = str.indexOf(dot)
            if (str.indexOf(at) == -1) {
                alert("Enter valid email")
                return false
            }

            if (str.indexOf(at) == -1 || str.indexOf(at) == 0 || str.indexOf(at) == lstr) {
                alert("Enter valid email address")
                return false
            }

            if (str.indexOf(dot) == -1 || str.indexOf(dot) == 0 || str.indexOf(dot) == lstr) {
                alert("Enter valid email address")
                return false
            }

            if (str.indexOf(at, (lat + 1)) != -1) {
                alert("Enter valid email address")
                return false
            }

            if (str.substring(lat - 1, lat) == dot || str.substring(lat + 1, lat + 2) == dot) {
                alert("Enter valid email address")
                return false
            }

            if (str.indexOf(dot, (lat + 2)) == -1) {
                alert("Enter valid email address")
                return false
            }

            if (str.indexOf(" ") != -1) {
                alert("Enter valid email address")
                return false
            }

            return true
        }

    </script>

    <script type="text/javascript" language="javascript">
    
//onKeyDown="return nocopypaste(event)"
//        function nocopypaste(e)
//        {
//        debugger
//            var code = (document.all) ? event.keyCode:e.which;           
//            if (parseInt(code)==17) //CTRL
//            {  
//                return false;                
//                window.event.returnValue = false;
//            }
//        }


    function Formatdata(e)
    {
       debugger
      /* var code = (document.all) ? event.keyCode:e.which;

        var msg = "Sorry, this functionality is disabled.";
        if (parseInt(code)==17) //CTRL
        {
        alert(msg);
        window.event.returnValue = false;
        }
        */
       
       var charCode = (e.which) ? e.which : event.keyCode   
        var ctrl=e.value.split('\n');                    
//        if (ctrl.length>50)
//        {
//            alert('More than 50 lines not allowed');                     
//            return false; 
//        }        
        //        if (charCode != 13)
        //        {
        //            for( var i =0;i<ctrl .length ;i++)
        //            {
        //                if (ctrl[i].trim().length>30)
        //                {
        //                alert('Only 30 characters allowed for each line');
        //                return false;
        //                }
        //                return true;
        //            }       
        //        }
       return true;      
        
    }
    
     function  showSpinner(){
            $('#spinner').show();
        }
        function  hideSpinner(){
            $('#spinner').hide();
        } 
            
    </script>

    <script type="text/javascript">
 function pageLoad()
   { 
      //InitializeTimer();      
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
  
      function poptastic(url)
    {
	newwindow=window.open(url,'name','directories=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,height=420,width=300');
	    if (window.focus) {newwindow.focus()}
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

  function OnchangeDropdown(){   
            if(document.getElementById('<%=ddlUserType.ClientID%>').value =="2")
            {
               document.getElementById("ddlLanguage").disabled=true;  
               document.getElementById("ddlLanguage").value = 1;      
            } 
            else
            {
               document.getElementById("ddlLanguage").disabled=false;  
            }
  }

    </script>

    <!-- End Newly added -->
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
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="UpdatePane1BtnRefresh"
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdtPnlBtnSend"
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
                                <li class="act">
                                    <asp:LinkButton ID="IntroMail" runat="server" Text="Intro Mial" Enabled="false" PostBackUrl="~/IntroMails.aspx"></asp:LinkButton></li>
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
                                        <li class="act">
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
            <div class=" box1 box100p">
                <h1 class="hed1 hed2" style="margin-bottom: 0">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <b>IntroMail <b></b>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </h1>
                <div class="inn" style="margin: 0; padding: 0;">
                    <asp:UpdatePanel ID="updaproducts" runat="server">
                        <ContentTemplate>
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="lblHeaderText" runat="server" Style="font-weight: bold"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 300px; vertical-align: top;">
                                        Customer Email Address(es)<br />
                                        <asp:TextBox ID="txtEmailAddress" runat="server" TextMode="MultiLine" CssClass="emailAddress"
                                            MaxLength="4000"></asp:TextBox>
                                        Language/Mail Type<br />    
                                        <asp:DropDownList ID="ddlLanguage" runat="server" Width="95%">
                                            <asp:ListItem Value="1">English</asp:ListItem>
                                            <asp:ListItem Value="2">Spanish</asp:ListItem>
                                        </asp:DropDownList>
                                        User Type<br />
                                        
                                        <asp:DropDownList ID="ddlUserType" runat="server" Width="95%" onchange="return OnchangeDropdown();">
                                            <asp:ListItem Value="1">Consumer</asp:ListItem>
                                            <asp:ListItem Value="2">Dealer</asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <br />
                                        <%--<textarea class="emailAddress"></textarea>--%>
                                        Marketing Specialist<br />
                                        <asp:TextBox ID="txtAgentName" runat="server" MaxLength="20" Width="95%"></asp:TextBox>
                                        <%-- <input type="text" class="input1" />--%>
                                        <div class="clear">
                                            &nbsp;</div>
                                        <asp:UpdatePanel ID="UpdtPnlBtnSend" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="btn btn-warning btn-sm"
                                                    OnClick="btnSend_Click" OnClientClick="return validationDataFirst();" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <%--<input type="button" value="Send" class="g-button g-button-submit" />--%>
                                    </td>
                                    <td style="width: 40px;">
                                        &nbsp;
                                    </td>
                                    <td style="vertical-align: top;">
                                        Recently sent intro emails (recent 15 days)<br />
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="lblRes" Font-Size="12px" Font-Bold="true" ForeColor="Black" runat="server"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div style="width: 100%;" id="divresults" runat="server">
                                            <div style="width: 695px; position: relative; padding: 0 3px; height: 1px">
                                                <asp:UpdatePanel ID="UpdtpnlHeader" runat="server">
                                                    <ContentTemplate>
                                                        <table cssclass="table table-hover table-striped  MB0 noBorder" cellpadding="0" cellspacing="0"
                                                            style="position: absolute; top: 2px; width: 675px; background: #fff; border-top: #fff 2px solid;">
                                                            <tr class="tbHed">
                                                                <td width="12%">
                                                                    <asp:LinkButton ID="lnkDateSort" runat="server" Text="Date &#8657" OnClick="lnkDateSort_Click"></asp:LinkButton>
                                                                    <%-- Date--%>
                                                                </td>
                                                                <td width="11%">
                                                                    Time
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:LinkButton ID="lnkMarketSpecialist" runat="server" Text="Market Specialist &darr; &uarr;"
                                                                        OnClick="lnkMarketSpecialist_Click"></asp:LinkButton>
                                                                    <%-- Market Specialist--%>
                                                                </td>
                                                                <td>
                                                                    <asp:LinkButton ID="lnkCustomerEmail" runat="server" Text="Customer Email &darr; &uarr;"
                                                                        OnClick="lnkCustomerEmail_Click"></asp:LinkButton>
                                                                    <%-- Customer Email--%>
                                                                </td>
                                                                <td width="12%">
                                                                    <asp:LinkButton ID="lnkLanguage" runat="server" Text="Language &darr; &uarr;" OnClick="lnkLanguage_Click"></asp:LinkButton>
                                                                    <%-- Customer Email--%>
                                                                </td>
                                                                <td width="10%">
                                                                    <asp:LinkButton ID="lnkStatus" runat="server" Text="Status &darr; &uarr;" OnClick="lnkStatus_Click"></asp:LinkButton>
                                                                    <%--Status--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div style="width: 100%; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                                border: #ccc 1px solid; height: 180px">
                                                <asp:Panel ID="pnl1" Width="100%" runat="server">
                                                    <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                                        <ContentTemplate>
                                                            <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                                            <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                                            <asp:GridView Width="675px" ID="grdIntroInfo" runat="server" CellSpacing="0" CellPadding="0"
                                                                CssClass="table table-hover table-striped  MB0 noBorder" AutoGenerateColumns="False"
                                                                GridLines="None" ShowHeader="false">
                                                                <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                                                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle CssClass="tbHed  center" />
                                                                <PagerSettings Position="Top" />
                                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblMailDate" runat="server" Text='<%# Bind("SentDateTime", "{0:MM/dd/yyyy}") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" Width="12%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblMailTime" runat="server" Text='<%# Bind("SentDateTime", "{0:t}") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" Width="11%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAgentName" runat="server" Text='<%# Eval("MarketSpecialist")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("CustomerEmail")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblLanguage" runat="server" Text='<%# Eval("Language")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" Width="12%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("StatusName")%>'></asp:Label>
                                                                            <%--<asp:Label ID="lblReverDt" runat="server"></asp:Label>
                                            <asp:Label ID="lblReverBy" runat="server"></asp:Label>--%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="grdIntroInfo" EventName="Sorting" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </asp:Panel>
                                            </div>
                                            <div class="clear" style="height: 12px;">
                                                &nbsp;</div>
                                            <asp:UpdatePanel ID="UpdatePane1BtnRefresh" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="btn btn-default btn-sm"
                                                        OnClick="btnRefresh_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <%--<input type="button" value="Refresh" class="g-button g-button-submit" />--%>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <!-- End  -->
                </div>
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <!-- Content End  
            
                <!-- End  -->
        <div class="clear">
            &nbsp;</div>
    </div>
    <!-- Main Wrapper Emd  -->
    <!-- Footer Start  -->
    <div class="footer">
        United Car Exchange © 2013
    </div>
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div id="AlertUser" class="alert" style="display: block">
        <h4 id="H1">
            Alert
            <asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" OnClick="btnYes_Click" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="updpnlMsgUser1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErr" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnYes" class="btn" runat="server" Text="Ok" OnClick="btnYes_Click" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mdepAskUserType" runat="server" PopupControlID="divAskUserType"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAskUserType">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAskUserType" runat="server" />
    <div id="divAskUserType" class="alert" style="display: none">
        <h4 id="H2">
            Select User Type
            <%--<asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" OnClick="btnNo_Click" />--%>
            <!-- <div class="cls"> </div> -->
        </h4>
        <div class="data">
            <br />
            <asp:RadioButton ID="rdbtnCarsSingleUser" runat="server" Text="Single User" CssClass="noLM"
                GroupName="PmntStatus" Checked="true" />
            <asp:RadioButton ID="rdbtnCarsDealer" runat="server" Text="Cars Dealer" CssClass="noLM"
                GroupName="PmntStatus" />
            &nbsp;
            <asp:Button ID="btnOK" class="btn" runat="server" Text="Ok" OnClick="btnOK_Click" />
        </div>
    </div>
    <!-- New Vechlie Click -->
    <cc1:ModalPopupExtender ID="MPBrands" runat="server" PopupControlID="tblChangePW1"
        BackgroundCssClass="ModalPopupBG" TargetControlID="HdnGroup1s" CancelControlID="img1">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="HdnGroup1s" runat="server" />
    <div id="tblChangePW1" style="display: none; width: 450px;" class="popup">
        <h2>
            Add New Product
            <asp:ImageButton ID="img1" runat="server" ImageUrl="images\close.png" CssClass="floarR" /></h2>
        <div class="content">
            <table style="width: 96%; margin: 0 auto;">
                <tr>
                    <td>
                        Product
                    </td>
                    <td>
                        <asp:TextBox ID="txtgrpname" MaxLength="20" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td align="left">
                        <div style="margin: 0; padding-left: 0px; display: inline-block">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btngroupAdd" class="btn btn-warning" runat="server" Text="Add" OnClick="btngroupAdd_Click" />&nbsp;
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <!-- Editing -->
    <cc1:ModalPopupExtender ID="MdpEditProduc" runat="server" PopupControlID="tblChangePW2"
        BackgroundCssClass="ModalPopupBG" TargetControlID="HiddenField1" CancelControlID="ImageButton1">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <div id="tblChangePW2" style="display: none; width: 450px;" class="popup">
        <h2>
            Edit Product
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images\close.png" CssClass="floarR" /></h2>
        <div class="content">
            <table style="width: 96%; margin: 0 auto;">
                <tr>
                    <td>
                        Product
                    </td>
                    <td>
                        <asp:TextBox ID="txtEdit" MaxLength="20" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td align="left">
                        <div style="margin: 0; padding-left: 0px; display: inline-block">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="BtnEdit" class="btn btn-warning" runat="server" Text="Update" OnClick="BtnEdit_Click" />&nbsp;
                                    <asp:Button ID="btnCancelPW" class="btn btn-default" runat="server" Text="Cancel" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
