w<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeadsUploadHistory.aspx.cs"
    Inherits="LeadsUploadHistory" %>

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
    
    </script>

</head>
<body>
    <form id="Form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <div>
        <div class="headder">
            <table style="width: 100%">
                <tr>
                    <td style="width: 330px;">
                        <a>
                            <img src="images/logo2.png" /></a>
                    </td>
                    <td>
                        <h1 style="border-bottom: none; padding-top: 5px;">
                            UNITED CAR EXCHANGE <span>Leads Upload</span></h1>
                    </td>
                    <td style="width: 380px; padding-top: 10px;">
                        <div class="loginStat">
                             &nbsp;<asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
                            <br />
                            <ul class="menu2">
                                <li><span style="font-size: 13px; font-weight: bold; cursor: pointer; color: #FFC50F">
                                    Menu &nabla;</span>
                                    <ul>
                                        <li>
                                            <asp:LinkButton ID="lnkTicker" runat="server" Text="Sales Ticker"></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="lnkbtnLeadsUpload" runat="server" Text="Leads Upload" PostBackUrl="~/LeadsUpload.aspx"></asp:LinkButton>
                                        </li>
                                    </ul>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnkBtnLogout" runat="server" Text="Logout" Visible="false" OnClick="lnkBtnLogout_Click"></asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="clear">
                &nbsp;
            </div>
        </div>
        <div style="height: 10px;">
            &nbsp;
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
                                            <td style="width: 225px;">
                                                Vehicle Category
                                                <asp:DropDownList ID="ddlVehicleType" runat="server" AppendDataBoundItems="true">
                                                    <asp:ListItem Text="Cars" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="RVs" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Bikes" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Boats" Value="4"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Button runat="server" ID="btnGet" Text="Get" class="g-button g-button-submit"
                                                    OnClick="btnGet_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td width="50%">
                                                <asp:Label ID="lblResHead" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="width: 450px; float: left;">
                                        <h3>
                                            <asp:Label ID="ldsHeading" runat="server"></asp:Label></h3>
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
                                                            <asp:LinkButton ID="lblIssuanceBatchID" runat="server" Text='<%# Bind("UpBatchID") %>'></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblToDownload" runat="server" Text='<%# Bind("Leaduploadeddate") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTobeDownload" runat="server" Text='<%# Bind("LeadCount") %>'></asp:Label>
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
    </div>
    </form>
</body>
</html>
