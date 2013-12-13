<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CopyPage.aspx.cs" Inherits="CopyPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: Car Sales System ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    
    <link href="css/core.css" rel="stylesheet" type="text/css"   />
    <link href="css/core.theme.css" rel="stylesheet" type="text/css"   />
    <link href="css/styleNew.css" rel="stylesheet" type="text/css"   />
    
    
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




</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM" runat="server" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/WebService.asmx" />
        </Services>
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
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
            <h1>Car Sales System<span>Page Name</span></h1>  
        </div>
        <div class="headright">
            <div class="loginDet">
                Welcome &nbsp;<asp:Label ID="lblUserName" runat="server" Text="padma" CssClass="loginStat"></asp:Label>&nbsp;
                       |&nbsp; <asp:LinkButton ID="lnkBtnLogout" runat="server" Text="Logout" OnClick="lnkBtnLogout_Click"
                            CssClass="loginStat"></asp:LinkButton>
            </div>
            <asp:LinkButton ID="lnksalTicker" runat="server" CssClass="btn btn-xs btn-info floarR" Text="Sales Ticker"></asp:LinkButton>
            <div class="menu">
                <ul >
                                    <li class="parent current"><a href="Home.aspx">Leads</a>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="lnkbtnLeadsDownLoad" runat="server" Text="Upload" Enabled="false"></asp:LinkButton></li><li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton22" runat="server" Text="Download" Enabled="false"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton11" runat="server" Text="Abondon" Enabled="false"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton21" runat="server" Text="Free Pkg" Enabled="false"></asp:LinkButton></li>
                                        </ul>
                                    </li>
                                    <li class="parent "><a href="">Sales</a>
                                        <ul>
                                            <li class="disable">
                                                <asp:LinkButton ID="LinkButton2" runat="server" Text="Ticker"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton3" runat="server" Text="Intro Mial"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton23" runat="server" Text="New Entry"></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton1" runat="server" Text="Transfer In"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton12" runat="server" Text="My Report"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton17" runat="server" Text="Set Group"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton18" runat="server" Text="Group Report"></asp:LinkButton></li>
                                        </ul>
                                    </li>
                                    <li class="parent "><a href="">Process</a>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="lnkbtnIntromail" runat="server" Text="QC" Enabled="false"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="lnkbtnNewSale" runat="server" Text="Payments" Enabled="false"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton10" runat="server" Text="Publish" Enabled="false"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton4" runat="server" Text="My Report" Enabled="false"></asp:LinkButton></li>
                                        </ul>
                                    </li>
                                    <li class="parent "><a href="">Reports</a>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="LinkButton7" runat="server" Text="Leads" Enabled="false"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton8" runat="server" Text="Sales" Enabled="false"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton9" runat="server" Text="Process" Enabled="false"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="lnkbtnDialySales" runat="server" Text="Exceutive"></asp:LinkButton></li>
                                        </ul>
                                    </li>
                                    <li class="parent "><a href="">Admin</a>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="LinkButton5" runat="server" Text="Leads" Enabled="false"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton6" runat="server" Text="Sales" PostBackUrl="~/DefaultRights.aspx"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton16" runat="server" Text="Process" Enabled="false"></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton19" runat="server" Text="Executive" Enabled="false"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="lnkBrands" runat="server" Text="Brands" PostBackUrl="~/Brands.aspx" ></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="lnkupdatecenters" runat="server" Text="Centers" PostBackUrl="~/UpdateCentersList.aspx"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton26" runat="server" Text="User Log" Enabled="false"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton31" runat="server" Text="Edit Log" Enabled="false"></asp:LinkButton></li>
                                        </ul>
                                    </li>
                                   
                                </ul>
            </div>
            
        </div>
        
    </div>    
    <!-- Headder End  -->
    
     <!-- Content Start  -->
    <div class="content wid1000">
      <div class="clear">&nbsp;</div>      
     </div>
    <!-- Content End  -->
   
   
    <div class="clear">&nbsp;</div>
</div>
<!-- Main Wrapper Emd  -->
 
 
  <!-- Footer Start  -->  
   <div class="footer">
	United Car Exchange © 2013
</div>
 <!-- Footer End  -->
    </form>
</body>
</html>
