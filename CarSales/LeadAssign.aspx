q<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeadAssign.aspx.cs" Inherits="LeadAssign1" %>

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
    
        function Validate() {
            var valid = true;
            if ($('#ddlCenter1 option:selected').val() == "0") {
                alert("Select a Center");
                $('#ddlCenter1').focus();
                valid = false;
            }
            return valid;

        }
    </script>

</head>
<body>
    <form runat="server">
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
                            UNITED CAR EXCHANGE <span>CENTER WISE LEAD ALLOCATION</span></h1>
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
                                            <asp:LinkButton ID="lnkbtnIPAddress" runat="server" Text="IP Address" PostBackUrl="~/IPAddress.aspx"></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="lnkbtnQCReport" runat="server" Text="QC Report" PostBackUrl="~/QCReport.aspx"></asp:LinkButton>
                                        </li>
                                        <li>
                                <asp:LinkButton ID="lnkbtnBulkReport" runat="server" Text="Bulk Process" PostBackUrl="~/BulkProcess.aspx"></asp:LinkButton>
                                </li>
                                        <li>
                                            <asp:LinkButton ID="lnkbtnAllCentersReport" runat="server" Text="Centers report"
                                                PostBackUrl="~/AllCentersReport.aspx"></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="lnkbtnAddCenters" runat="server" Text="Centers Mgmt" PostBackUrl="~/AddNewCenters.aspx"></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="lnkbtnSalesreport" runat="server" Text="Sales Report" PostBackUrl="~/CarSalesReportNew.aspx"></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="lnkbtnAlluserMgmt" runat="server" Text="User Mgmt" PostBackUrl="~/AllUsersManagement.aspx"></asp:LinkButton>
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
            <table style="width: 94%;">
                <tr>
                    <td style="width: 100%">
                        <div style="float: right">
                            <asp:LinkButton ID="lbtnQcShow" Text="Lead rejection criteria" runat="server" OnClick="lbtnQcShow_Click"></asp:LinkButton>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">
                        <table style="width: 100%;" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblCenterCode" runat="server" Font-Bold="true"></asp:Label>
                                    <br />
                                    <label style="padding-right: 10px; float: left; line-height: 26px;">
                                        Vehicle Category</label>
                                    <div style="width: 95px; float: left">
                                        <asp:DropDownList ID="ddlVehicleType1" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Text="Cars" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="RVs" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Bikes" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Boats" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div style="width: 120px; float: left">
                                        <asp:Button ID="btnShow" runat="server" Style="width: 100px;" Text="Show" CssClass="g-button g-button-submit"
                                            OnClick="btnShow_Click"></asp:Button>
                                    </div>
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
                        <div id="divDetails" runat="server" style="width: 1000px;" visible="false">
                            <h3>
                                Center wise lead allocation</h3>
                            <table>
                                <tr>
                                    <td style="width: 750px;">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DataList ID="grdAssign" runat="server" AutoGenerateColumns="false" RepeatColumns="12"
                                                    Width="99%" OnItemDataBound="grdAssign_ItemDataBound" OnItemCommand="grdAssign_ItemCommand1">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lblStateCode" runat="server" Text='<%# Bind("State_Code") %>'
                                                            CommandArgument='<%# Bind("State_ID") %>' CommandName="State"></asp:LinkButton>
                                                        <asp:HiddenField ID="hdnStateID" runat="server" Value='<%# Bind("State_ID") %>'>
                                                        </asp:HiddenField>
                                                        <asp:HiddenField ID="hdnCenterID" runat="server"></asp:HiddenField>
                                                        <asp:HiddenField ID="hdnCSID" runat="server"></asp:HiddenField>
                                                        <asp:Label ID="lblCenterName" runat="server">
                                                        </asp:Label><br />
                                                        <span style="font-size: 9px;">(<asp:Label ID="lblTimeZone" runat="server" Text='<%# Bind("TimeZone") %>'>
                                                        </asp:Label>)</span>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnShow" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <div style="width: 350px; float: left">
                                            <img src="images/timezones.png" style="width: 350px; height: auto; padding: 2px;
                                                background: #fff; border: #ccc 1px solid" />
                                        </div>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <cc1:ModalPopupExtender ID="mpelblUerExist" runat="server" PopupControlID="tblUpdate"
            BackgroundCssClass="ModalPopupBG" TargetControlID="hdnlblUerExist" CancelControlID="btnCancelAssign">
        </cc1:ModalPopupExtender>
        <asp:HiddenField ID="hdnlblUerExist" runat="server" />
        <div id="tblUpdate" class="PopUpHolder" style="display: none;">
            <div class="main" style="width: 600px; margin: 60px auto 0 auto;">
                <h4>
                    Assign leads to a center
                </h4>
                <asp:UpdatePanel ID="updpnl" runat="server">
                    <ContentTemplate>
                        <table style="width: 100%;" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    Vehicle category :
                                    <asp:Label ID="lblVehicleType" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    State:
                                    <asp:Label ID="lblSelectedState" runat="server" Font-Bold="true"></asp:Label>
                                    <asp:HiddenField ID="hdnSelectedStateID" runat="server"></asp:HiddenField>
                                    <br />
                                    Currently allocated to:
                                    <asp:Label ID="lblAllocatedLocation" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <label style="padding-right: 10px; float: left; line-height: 26px;">
                                        Center</label>
                                    <div style="width: 120px; float: left">
                                        <asp:DropDownList ID="ddlCenter1" runat="server" Style="width: 100px;" AppendDataBoundItems="true">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <asp:HiddenField ID="hdnCSID1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td width="50%">
                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Button ID="btnGo" runat="server" Text="Ok" CssClass="g-button g-button-submit"
                    OnClientClick="return Validate();" OnClick="btnGo_Click" />
                <asp:Button ID="btnCancelAssign" runat="server" Text="Cancel" CssClass="g-button g-button-submit" />
                <div class="clearFix">
                    &nbsp</div>
            </div>
        </div>
        <cc1:ModalPopupExtender ID="MpeQcPopUp" runat="server" PopupControlID="QcAdding"
            BackgroundCssClass="ModalPopupBG" TargetControlID="hdnQcPop">
        </cc1:ModalPopupExtender>
        <asp:HiddenField ID="hdnQcPop" runat="server" />
        <div id="QcAdding" class="PopUpHolder" style="display: none; height: 700px">
            <div class="main" style="width: 600px; margin: 60px auto 0 auto;">
                <h4>
                    <div style="float: left;">
                        Lead rejection criteria
                    </div>
                    <div style="float: right; font-size: 10px">
                        (QC fails for matching any of the following conditions)
                    </div>
                </h4>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <fieldset class="popFieldset" style="width:96%;">
                        <legend>Phone # range</legend>
                        <table style="width: 90%; margin: 0 auto;" cellpadding="0" cellspacing="0">
                        <tr>
                                <td style="width: 150px;">
                                    NPA Range
                                </td>
                                <td>
                                    <span>From</span><span><asp:TextBox ID="txtNpaRangeFrom" runat="server"></asp:TextBox></span>
                                </td>
                                <td>
                                    <span>To</span><span><asp:TextBox ID="NPARangeTo" runat="server"></asp:TextBox></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    NXX Range
                                </td>
                                <td>
                                    <span>From</span> <span>
                                        <asp:TextBox ID="NXXRangeFrom" runat="server"></asp:TextBox></span>
                                </td>
                                <td>
                                    <span>To</span> <span>
                                        <asp:TextBox ID="NXXRangeTo" runat="server"></asp:TextBox></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Other NPA
                                </td>
                                <td>
                                    <asp:TextBox ID="OtherNPA" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Other NXX
                                </td>
                                <td>
                                    <asp:TextBox ID="OtherNXX" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    NPA NXX combos
                                </td>
                                <td>
                                    <asp:TextBox ID="NPA_NXX_combos" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Last four digits
                                </td>
                                <td>
                                    <asp:TextBox ID="Last_four_digits" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    
                    <table style="width:100%;" >
                        <tr>
                            <td style="width:50%;" >
                                <fieldset  class="popFieldset">
                        <legend>Price range</legend>
                        <table style="width: 90%; margin: 0 auto;" cellpadding="0" cellspacing="0">
                        
                            <tr>
                                <td>
                                    Price Below
                                </td>
                                <td>
                                    <asp:TextBox ID="PRICE_Below" runat="server"></asp:TextBox>
                                </td>
                                </tr>
                            <tr>
                                    <td>
                                        Price above
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PRICE_Above" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                        </table>
                    </fieldset>
                            </td>
                            <td>
                                  <fieldset  class="popFieldset">
                        <legend>Model year range</legend>
                        <table style="width: 90%; margin: 0 auto;" cellpadding="0" cellspacing="0">
                       
                                <tr>
                                    <td>
                                        Prior to
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ModelPriorTo" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        After
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ModelTo" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                        </table>
                    </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <fieldset  class="popFieldset">
                        <legend>Mileage range</legend>
                        <table style="width: 90%; margin: 0 auto;" cellpadding="0" cellspacing="0">
                         
                                <tr>
                                    <td>
                                        Grater than
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MileageGreaterthan" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Less than
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MileageLessThan" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                        </table>
                    </fieldset>
                            </td>
                            <td>
                                <fieldset  class="popFieldset">
                        <legend>Lead date range</legend>
                        <table style="width: 90%; margin: 0 auto;" cellpadding="0" cellspacing="0">
                        
                                <tr>
                                    <td>
                                        Prior to
                                    </td>
                                    <td>
                                        <asp:TextBox ID="LeadDatePriorTo" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Future date
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFuture_date" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                        </table>
                    </fieldset>
                            </td>
                        </tr>
                    </table>
                    
                    
                  
                    
                    
                    
                    
                    
                    
                        <table style="width: 90%; margin: 0 auto;" cellpadding="0" cellspacing="0">                         
                           
                           <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        <span>
                                            <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="g-button g-button-submit"
                                                OnClick="btnSave_Click" /></span> <span>
                                                    <asp:Button ID="btnCANCEL" Text="CANCEL" runat="server" CssClass="g-button g-button-submit"
                                                        OnClick="btnCANCEL_Click" /></span> <span>
                                                            <asp:Button ID="btnApplytoexistingDB" Text="Save/Apply to existing DB" runat="server"
                                                                CssClass="g-button g-button-submit" /></span>
                                    </td>
                                </tr>
                           
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="clearFix">
                    &nbsp</div>
            </div>
        </div>
        <cc1:ModalPopupExtender ID="mpealteruserUpdated" runat="server" PopupControlID="AlertUserUpdated"
            BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuserUpdated" CancelControlID="BtnClsUpdated"
            OkControlID="btnYesUpdated">
        </cc1:ModalPopupExtender>
        <asp:HiddenField ID="hdnAlertuserUpdated" runat="server" />
        <div id="AlertUserUpdated" class="alert" style="display: none">
            <h4 id="H3">
                Alert
                <asp:Button ID="BtnClsUpdated" class="cls" runat="server" Text="" BorderWidth="0" />
            </h4>
            <div class="data">
                <p>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblErrUpdated" runat="server" Visible="false"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </p>
                <asp:Button ID="btnYesUpdated" class="btn" runat="server" Text="Ok" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
