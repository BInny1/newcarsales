<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateCentersList.aspx.cs" Inherits="UpdateCentersList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: Car Sales System ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="js/emulatetab.joelpurra.js"></script>

    <script type="text/javascript" src="js/plusastab.joelpurra.js"></script>

    <link href="css/css2.css" rel="stylesheet" type="text/css"/>
    <link  href="css/css.css" rel="stylesheet" type="text/css" />

    <script type='text/javascript' language="javascript" src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="Static/JS/calendar.js" type="text/javascript"></script>

    <link href="Static/Css/calender.css" rel="stylesheet" type="text/css" />

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

    <!-- Drop Menu CSS -->
    <link rel="stylesheet" href="css/dropdown-menu.css" />
    <link rel="stylesheet" href="css/dropdown-menu-skin.css" />
    <!-- Drop Menu JS -->

    <script type="text/javascript" src="js/dropdown-menu.min.js"></script>

    <script type="text/javascript">
$(function() {
    $('#example3').dropdown_menu();
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
    <div class="headder">
        <table style="width: 100%">
            <tr>
                <td style="width: 260px;">
                    <a>
                        <img src="images/logo2.png" /></a>
                </td>
                <td>
                    <h1 style="border-bottom: none; padding-top: 5px;">
                        UNITED CAR EXCHANGE <span>Daily Sales Count</span></h1>
                </td>
                <td style="width: 490px; padding-top: 10px;">
                    <div class="loginStat">
                        Welcome &nbsp;<asp:Label ID="lblUserName" runat="server" Text="padma" CssClass="loginStat"></asp:Label>&nbsp;
                        <br />
                        <asp:LinkButton ID="lnksalTicker" runat="server" CssClass="loginStat" Text="Sales Ticker"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="lnkBtnLogout" runat="server" Text="Logout" OnClick="lnkBtnLogout_Click"
                            CssClass="loginStat"></asp:LinkButton>
                        <div class="wrap-nav zerogrid">
                            <div class="menu" style="width: 600px;">
                                <ul>
                                    <%-- <li class="parent current"><a href="Home.aspx">Leads</a>
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
                                    <li class="parent current"><a href="">Sales</a>
                                        <ul>
                                            <li>
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
                                    <li class="parent current"><a href="">Process</a>
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
                                    <li class="parent current"><a href="">Reports</a>
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
                                    <li class="parent current"><a href="">Admin</a>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="LinkButton5" runat="server" Text="Leads" Enabled="false"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton6" runat="server" Text="Sales" Enabled="false"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton16" runat="server" Text="Process" Enabled="false"></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton19" runat="server" Text="Executive" Enabled="false"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton24" runat="server" Text="Brands" Enabled="false"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton25" runat="server" Text="Centers" Enabled="false"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton26" runat="server" Text="User Log" Enabled="false"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton31" runat="server" Text="Edit Log" Enabled="false"></asp:LinkButton></li>
                                        </ul>
                                    </li>
                                    <li class="parent current"><a href="">Search</a>
                                        <ul>
                                           
                                        </ul>
                                    </li>--%>
                                </ul>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <div class="clear">
            &nbsp;
        </div>
    </div>
    <div style="height: 10px;">
    </div>
    <div class="main" style="width: 90%; min-width: 1100px; margin: 0 10px 10px 10px">
        <asp:UpdatePanel ID="updtpnltblGrdcar" runat="server">
            <ContentTemplate>
                <div class="main" style="width: 90%; min-width: 1100px; margin: 0 10px 10px 10px">
                    <table style="width: 100%">
                    <tr><td></td><td></td></tr>
                        <tr>
                            <td>
                            <br/>
                                <table id="Table1" runat="server" class="grid1" style="width: 800px;">
                                <tr class="tbHed">
                                <td  width="92px">
                                            Center Code
                                        </td>
                                        <td  width="95px">
                                            Leads Upload 
                                        </td>
                                        <td  width="95px">
                                           Sales
                                        </td>
                                         <td  width="95px">
                                            Customer Service
                                        </td>
                                        <td  width="95px">
                                            Process
                                        </td>
                                 <td colspan="3">Leads Download</td>
                                 
                                </tr>
                                    <tr class="tbHed">
                                       <td></td>
                                       <td></td>
                                       <td></td>
                                       <td></td>
                                       <td></td>
                                             <td>Transfers In</td>
                                             <td>Abondons</td>
                                             <td>Free Posts</td>
                                       
                                    </tr>
                                    
                                </table>
                                <asp:GridView Width="800px" ID="GridCentersUpades" runat="server" CellSpacing="0" CellPadding="0"
                                    CssClass="grid1" AutoGenerateColumns="False" GridLines="None" ShowHeader="false">
                                    <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle CssClass="headder" />
                                    <PagerSettings Position="Top" />
                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                    <RowStyle CssClass="row1" />
                                    <AlternatingRowStyle CssClass="row2" />
                                    <Columns>
                                        <asp:TemplateField  ItemStyle-Width="80">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkUName" runat="server" Text='<%# Eval("CenterCode")%>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="80">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("LeadsUpload") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="80">
                                            <ItemTemplate>
                                                <asp:Label ID="lnkUName" runat="server" Text='<%# Eval("Sales")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="80">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("CustomerService") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="80">
                                            <ItemTemplate>
                                                <asp:Label ID="lnkUName" runat="server" Text='<%# Eval("Process")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="80">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("LeadsDTranfersIn") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="80">
                                            <ItemTemplate>
                                                <asp:Label ID="lnkUName" runat="server" Text='<%# Eval("LeadsDAbondons")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="80">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("LeadsFreePosts") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                       
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    
    <!-- New Vechlie Click -->
      <cc1:ModalPopupExtender ID="MpVechlAdd" runat="server" PopupControlID="tblChangePW"
                BackgroundCssClass="ModalPopupBG" TargetControlID="hdnChangePW" CancelControlID="btnCancelPW">
            </cc1:ModalPopupExtender>
            <asp:HiddenField ID="hdnChangePW" runat="server" />
            <div id="tblChangePW" style="display: none; width: 450px;" class="popup">
                <h2>
                    Add New Brand</h2>
                <div class="content">
                    <table style="width: 96%; margin: 0 auto;">
                        <tr>
                         <td>
                                Vehicle Type
                            </td>
                            <td>
                               <asp:TextBox ID="txtVeckType"  MaxLength="20" runat="server" ></asp:TextBox>
                            </td>
                          
                        </tr>
                        <tr>
                            <td>
                                Brand
                            </td>
                            <td>
                                <asp:TextBox ID="txtBrnad"  MaxLength="20" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Status
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbt_VechGrop" runat="server" RepeatColumns="2">
                                <asp:ListItem>Active</asp:ListItem> <asp:ListItem>InActive</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <div style="width: 90%; margin: 0; padding-left: 0px">
                                    <asp:UpdatePanel ID="updtPnlChangePwd" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnAddVehicle" class="btn btn-danger btn-warning" runat="server" Text="Add" OnClick="btnAddVehicle_Click"/>&nbsp;
                                                 
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                            </td>
                            <td align="left">
                               <asp:Button ID="btnCancelPW" class="btn btn-danger btn-warning" runat="server" Text="Cancel" />
                                 </td> </tr> </table>
                </div>
               
            </div>
   
    </form>
</body>
</html>
