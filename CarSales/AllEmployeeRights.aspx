<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllEmployeeRights.aspx.cs"
    Inherits="AllEmployeeRights" %>

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
    
   
    function ClosePopup10() {
            $find('<%= MpVechlAdd.ClientID%>').hide();
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
    <asp:UpdateProgress ID="UpdatePanel12" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
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
                    Car Sales System<span>All Employee Rights</span></h1>
            </div>
            <div class="headright">
                <div class="loginDet">
                    Welcome &nbsp;<asp:Label ID="lblUserName" runat="server" CssClass="loginStat"></asp:Label>&nbsp;
                    |&nbsp;
                    <asp:LinkButton ID="lnkBtnLogout" runat="server" Text="Logout" OnClick="lnkBtnLogout_Click"
                        CssClass="loginStat"></asp:LinkButton>
                </div>
                <asp:LinkButton ID="lnkTicker" runat="server" CssClass="btn btn-xs btn-info floarR"
                    Text="Sales Ticker"></asp:LinkButton>
                <div class="menu">
                    <ul>
                        <li class="parent"><a href="Home.aspx">Leads</a>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="LeadsUpload" runat="server" Text="Upload" Enabled="false"></asp:LinkButton></li><li>
                                <li>
                                    <asp:LinkButton ID="LeadsDownLoad" runat="server" Text="Download" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Abondoned" runat="server" Text="Abondon" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="FreePackage" runat="server" Text="Free Pkg" Enabled="false"></asp:LinkButton></li>
                            </ul>
                        </li>
                        <li class="parent "><a href="">Sales</a>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="IntroMail" runat="server" Text="Intro Mial" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="NewEntry" runat="server" Text="New Entry" Enabled="false"></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="Transferin" runat="server" Text="Transfer In" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="MyReport" runat="server" Text="My Report" Enabled="false"></asp:LinkButton></li>
                            </ul>
                        </li>
                        <li class="parent"><a href="">Process</a>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="QC" runat="server" Text="QC" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Payments" runat="server" Text="Payments" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Publish" runat="server" Text="Publish" Enabled="false"></asp:LinkButton></li>
                            </ul>
                        </li>
                        <li class="parent "><a href="">Reports</a>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="Leads" runat="server" Text="Leads" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Sales" runat="server" Text="Sales" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Process" runat="server" Text="Process" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Executive" runat="server" Text="Exceutive" Enabled="false"></asp:LinkButton></li>
                            </ul>
                        </li>
                        <li class="parent current"><a href="">Admin</a>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="leadsRights" runat="server" Text="Leads Rights" PostBackUrl="~/LeadsUserRights.aspx"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="LeadsList" runat="server" Text="Leads Statewise" PostBackUrl="~/StatewiseLeads.aspx"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="LeadsSatus" runat="server" Text="Leads Status" PostBackUrl="~/StateWiseLeadsStatus.aspx"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="SalesAdmin" runat="server" Text="Sales" PostBackUrl="~/AllEmployeeRights.aspx"
                                        Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnkDefaRights" runat="server" Text="Def.Rights" PostBackUrl="~/DefaultRights.aspx"></asp:LinkButton></li>
                                <li class="active">
                                    <asp:LinkButton ID="ProcessAdmin" runat="server" Text="Process" PostBackUrl="~/AllEmployeeRights.aspx"
                                        Enabled="false"></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="ExecutiveAdmin" runat="server" Text="Executive" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="BrandsAdmin" runat="server" Text="Brands" PostBackUrl="~/Brands.aspx"
                                        Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="CentersAdmin" runat="server" Text="Centers" PostBackUrl="~/Center.aspx"
                                        Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="UsersLog" runat="server" Text="User Log" Enabled="false"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="EditLog" runat="server" Text="Edit Log" Enabled="false"></asp:LinkButton></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- Headder End  -->
        <!-- Content Start  -->
        <div class="content">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="inn">
                        <div class="box1 boxBlue">
                            <h1 class="hed1 hed2">
                                User Rights
                                <asp:Label ID="lblcenters" Text="Centers" runat="server" Style="padding-left: 700px;"></asp:Label>
                                <asp:DropDownList ID="ddlcenters" runat="server" Style="width: 150px;" OnSelectedIndexChanged="ddlcenters_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                                &nbsp;
                                <asp:LinkButton ID="lnlupdatelist" runat="server" Text="Update Users List" OnClick="lnlupdatelist_Click"></asp:LinkButton>
                            </h1>
                            <div class="inn">
                                <!-- Grid Start -->
                                <asp:UpdatePanel ID="updtpnltblGrdcar" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="GridDefaultUserRights" runat="server" CellSpacing="0" CellPadding="0"
                                                        ShowFooter="true" CssClass="table table-hover table-striped" AutoGenerateColumns="False"
                                                        GridLines="None" OnRowCreated="GridDefaultUserRights_RowCreated" OnRowDataBound="GridDefaultUserRights_RowDataBound"
                                                        OnRowCommand="GridDefaultUserRights_RowCommand">
                                                        <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle CssClass="tbHed" />
                                                        <PagerSettings Position="Top" />
                                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lblEmpId" runat="server" Text='<%# Eval("EMPID")%>' CommandArgument='<%# Eval("EMPID")%>'
                                                                        CommandName="Empdeta"></asp:LinkButton>
                                                                    <%-- <asp:HiddenField ID="lblUserId" runat="server" Value='<%# Eval("UserID")%>' />--%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField FooterText="Count">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LblFirstName" runat="server" Text='<%# Eval("Names")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lblRoleNamre" runat="server" Text='<%# Eval("RoleName")%>'></asp:LinkButton>
                                                                    <asp:HiddenField ID="hdnRoleId" runat="server" Value='<%# Eval("RoleId")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lblVehType" runat="server" Text="Default"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Leads">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LeadsUploadXX" runat="server" Text='<%# Eval("LeadsUpload")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblupload" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Transfer Ins">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="TransferinXX" runat="server" Text='<%# Eval("Transferin")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lbltransfin" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Abondons">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="AbondonedXX" runat="server" Text='<%# Eval("Abondoned")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblabond" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Free Posts">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="FreePackageXX" runat="server" Text='<%# Eval("FreePackage")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblfreepack" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Intro Mail">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="IntroMailXX" runat="server" Text='<%# Eval("IntroMail")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblintm" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="New Entry">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="NewEntryXX" runat="server" Text='<%# Eval("NewEntry")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblneent" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Transfer Out">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lblTransferOutXX" runat="server" Text=" "></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lbltrnout" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Ticker">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="TickerXX" runat="server" Text='<%# Eval("Ticker")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblticker" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Self">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="SelfXX" runat="server" Text='<%# Eval("Self")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblselfs" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="CenterXX" runat="server" Text='<%# Eval("Center")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblcentrs" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LeadsAdminXX" runat="server" Text='<%# Eval("LeadsAdmin")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblladminsd" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <!-- Grid End  -->
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="clear">
                &nbsp;</div>
        </div>
        <!-- Content End  -->
        <div class="clear">
            &nbsp;</div>
    </div>
    <!-- Main Wrapper Emd  -->
    <!-- Footer Start  -->
    <div class="footer">
        United Car Exchange © 2013
    </div>
    <!-- Footer End  -->
    <cc1:ModalPopupExtender ID="MpVechlAdd" runat="server" PopupControlID="tblChangePW"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnChangePW" CancelControlID="btnCancelPW">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnChangePW" runat="server" />
    <div id="tblChangePW" style="display: none; width: 550px;" class="popup">
        <h2>
            Update Rights</h2>
        <div class="content">
            <asp:UpdatePanel ID="p1" runat="server">
                <ContentTemplate>
                    <table style="width: 96%; margin: 0 auto;">
                        <tr>
                            <td>
                                <b>Leads Download</b>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="Ckleads" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>Leads</asp:ListItem>
                                    <asp:ListItem>Transfer Ins</asp:ListItem>
                                    <asp:ListItem>Abondons</asp:ListItem>
                                    <asp:ListItem>Free Posts</asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Sales
                            </td>
                            <td>
                                <asp:CheckBoxList ID="chksales" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>Intro Mail</asp:ListItem>
                                    <asp:ListItem>New Entry</asp:ListItem>
                                    <asp:ListItem>Transfer Out</asp:ListItem>
                                    <asp:ListItem>Ticker</asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Reports
                            </td>
                            <td>
                                <asp:CheckBoxList ID="ChkReports" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>Self</asp:ListItem>
                                    <asp:ListItem>Center</asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Sales Admin
                            </td>
                            <td>
                                <asp:CheckBoxList ID="chksaleadmin" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>Admin</asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                            </td>
                            <td align="left">
                                <div style="margin: 0; padding-left: 0px; display: inline-block">
                                    <asp:UpdatePanel ID="updtPnlChangePwd" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnAddVehicle" class="btn btn-danger btn-warning" runat="server"
                                                Text="Update" OnClick="btnAddVehicle_Click" />&nbsp;
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <asp:Button ID="btnCancelPW" class="btn btn-danger btn-warning" runat="server" Text="Cancel"
                                    OnClientClick="return ClosePopup10();" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <!-- User Update List -->
    <cc1:ModalPopupExtender ID="MpUserUpdatelist" runat="server" PopupControlID="tblChangePW1"
        BackgroundCssClass="ModalPopupBG" TargetControlID="HdnUserPoyp" CancelControlID="btnCancelPW">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="HdnUserPoyp" runat="server" />
    <div id="tblChangePW1" style="display: none; width: 950px;" class="popup">
        <h2>
            Employees List</h2>
        <div class="content">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridUserUpdateList" runat="server" CellSpacing="0" CellPadding="0"
                        ShowFooter="true" CssClass="table table-hover table-striped" AutoGenerateColumns="False"
                        GridLines="None">
                        <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle CssClass="tbHed" />
                        <PagerSettings Position="Top" />
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_Check" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblSalesEmpid" runat="server" Text='<%# Eval("EMPID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="LblSalesName" runat="server" Text='<%# Eval("Names")%>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlsalesroles" runat="server">
                                        <asp:ListItem Value="1">Sales Agent Opener</asp:ListItem>
                                        <asp:ListItem Value="2">Sales Agent Closer</asp:ListItem>
                                        <asp:ListItem Value="3">Center Manager</asp:ListItem>
                                        <asp:ListItem Value="4">SalesAssistant</asp:ListItem>
                                        <asp:ListItem Value="5">QC Analyst</asp:ListItem>
                                        <asp:ListItem Value="6">Billing Processor</asp:ListItem>
                                        <asp:ListItem Value="7">Process Manager</asp:ListItem>
                                        <asp:ListItem Value="8">Leads Source</asp:ListItem>
                                        <asp:ListItem Value="9">Leads Manager</asp:ListItem>
                                        <asp:ListItem Value="10">Executive</asp:ListItem>
                                        <asp:ListItem Value="11">Admin</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="LblSalesName" runat="server" Text='<%# Eval("DeptName")%>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>
