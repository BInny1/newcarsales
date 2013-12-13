<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeadDownLoadHistory.aspx.cs"
    Inherits="AddNewCenters" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: Car Sales System ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="css/cssLeads.css" rel="stylesheet" type="text/css" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />

    <script src="js/overlibmws.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="js/emulatetab.joelpurra.js"></script>

    <script type="text/javascript" src="js/plusastab.joelpurra.js"></script>

    <script type='text/javascript' language="javascript" src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="Static/JS/calendar.js" type="text/javascript"></script>

    <link href="Static/Css/calender.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">window.history.forward(1);</script>

    <script type="text/javascript" language="javascript">
     function poptastic(url)
{
	newwindow=window.open(url,'name','directories=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,height=420,width=300');
	    if (window.focus) {newwindow.focus()}
    }
        function pageLoad() {
            //InitializeTimer();      
        }

    </script>

    <script type="text/javascript" language="javascript">

            function printPartOfPage(elementId)
            {
             var printContent = document.getElementById('<%= lblMultiListMail.ClientID %>');
             alert(printContent)
             
             var windowUrl = 'about:blank';
             var uniqueName = new Date();
             var windowName = 'Print' + uniqueName.getTime();
             var printWindow = window.open(windowUrl, windowName, 'left=5000,top=5000,width=700,height=600');             
             printWindow.document.write(printContent.innerHTML);
             printWindow.document.close();
             printWindow.focus();
             printWindow.print();
             printWindow.close();
            }
            
            function CallPrint(strid) 
            { 
             var prtContent = document.getElementById(strid); 
             var WinPrint = 
             window.open('','','letf=0,top=0,width=500,height=500,toolbar=0,scrollbars=0,sta tus=0'); 
             WinPrint.document.write(prtContent.innerHTML); 
             WinPrint.document.close(); 
             WinPrint.focus(); 
             WinPrint.print(); 
             WinPrint.close(); 
             prtContent.innerHTML=strOldOne; 
            } 

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="SM" runat="server" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/WebService.asmx" />
        </Services>
    </cc1:ToolkitScriptManager>
    <div class="headder">
        <table style="width: 100%">
            <td style="width: 380px;">
                <a>
                    <img src="images/logo2.png" /></a>
            </td>
            <td>
                <h1 style="border-bottom: none; padding-top: 5px;">
                    UNITED CAR EXCHANGE<span>Leads Download History</span></h1>
                <td style="width: 380px; padding-top: 10px;">
                    <div class="loginStat">
                        Welcome &nbsp;<asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
                        <br />
                        <ul class="menu2">
                            <li><span style="font-size: 13px; font-weight: bold; cursor: pointer; color: #FFC50F">
                                Menu &nabla;</span>
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lnkTicker" runat="server" Text="Sales Ticker"></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnkbtnLeadsDownLoad" runat="server" Text="Leads Download" PostBackUrl="~/LeadDownLoad.aspx"></asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnkBtnLogout" runat="server" Text="Logout" Visible="false" OnClick="lnkBtnLogout_Click"></asp:LinkButton>
                            </li>
                        </ul>
                    </div>
                </td>
        </table>
        <div class="clear">
            &nbsp;
        </div>
    </div>
    <div style="height: 10px;">
    </div>
    <div class="main">
        <table style="width: 720px;">
            <tr>
                <td style="vertical-align: top;">
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
                                            Vehicle Category<br />
                                            <asp:DropDownList ID="ddlVehicleType" runat="server" AppendDataBoundItems="true">
                                                <asp:ListItem Text="Cars" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="RVs" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Bikes" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Boats" Value="4"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 95px;">
                                            Center Location
                                            <asp:DropDownList ID="ddlCenter" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:Button runat="server" ID="btnGet" Text="Get" class="g-button g-button-submit"
                                                OnClick="btnGet_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="lblResHead" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <div style="width: 450px; float: left;">
                                    <h3 id="h3hed" runat="server" style="display: none;">
                                        Center wise leads</h3>
                                    <table style="width: 450px;" class="scrollTable noPad">
                                        <asp:Repeater ID="rptrDownload" runat="server" OnItemCommand="rptrDownload_ItemCommand">
                                            <HeaderTemplate>
                                                <tr>
                                                    <th style="width: 40px;">
                                                        Batch#
                                                    </th>
                                                    <th>
                                                        UL Date/Time
                                                    </th>
                                                    <th>
                                                        # of records
                                                    </th>
                                                    <th>
                                                        Vehicle category
                                                    </th>
                                                    <th>
                                                        Uploaded by
                                                    </th>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lblIssuanceBatchID" runat="server" Text='<%# Bind("IssuanceBatchID") %>'></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblToDownload" runat="server" Text='<%# Bind("Leadissueddate") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblTobeDownload" runat="server" Text='<%# Bind("LeadIssuedCount") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("VehicleType") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblStateID" runat="server" Text='<%# Bind("AgentUserName") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <cc1:ModalPopupExtender ID="MpeListMail" runat="server" PopupControlID="divViewListingMail"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnListingMail" CancelControlID="btnCancelSendListingMail">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnListingMail" runat="server" />
    <div id="divViewListingMail" class="PopUpHolder">
        <div class="main " style="height: 480px; margin-top: 70px; width: 880px">
            <h4>
                MultiListing Mail
            </h4>
            <div class="dat" style="padding: 0;">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 70%;">
                            <table>
                                <tr>
                                    <td>
                                        <b style="padding-top: 5px; display: inline-block;">Mail To:</b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblMultiSiteMailTo" CssClass="input1" Width="160px" runat="server"
                                            MaxLength="100"></asp:TextBox>
                                        <%--<asp:Label ID="lblMultiSiteMailTo" runat="server"></asp:Label>--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <b style="padding-top: 5px; display: inline-block;">CC: </b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMultiListEmailToCC" CssClass="input1" Width="160px" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnPrint" Text="Print" OnClientClick="javascript:CallPrint('width870');"
                                            runat="Server" CssClass="g-button g-button-submit" Style="display: block;" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div id="width870" runat="server" class="YScroll">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblMultiListMail" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="clear">
                        &nbsp;</div>
                </div>
                <asp:Button ID="btnCancelSendListingMail" class="g-button btnUpdate" runat="server"
                    Text="Cancel" />
                <asp:Button ID="btnSendListingMail" class="g-button btnUpdate" runat="server" Text="Send"
                    OnClientClick="return ValidateMultiSiteList();" />
                <div class="clear">
                    &nbsp;</div>
                <br />
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    </form>
</body>
</html>
