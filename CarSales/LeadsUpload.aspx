<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeadsUpload.aspx.cs" Inherits="Intromail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        function Formatdata(e) {
            debugger
            var charCode = (e.which) ? e.which : event.keyCode
            var ctrl = e.value.split('\n');

            return true;

        }

        function showSpinner() {
            $('#spinner').show();
        }
        function hideSpinner() {
            $('#spinner').hide();
        } 
            
    </script>

    <script type="text/javascript">
        function pageLoad() {
            $('.sample4').numeric({ allow: "-" });
        }

        function ValidateUpload() {
            debugger
            var valid = true;
            if ($('#ddlVehicleType option:selected').val() == "0") {
                alert("Select a vehicle type");
                $('#ddlVehicleType').focus();
                valid = false;
            }
            else if ($('#fuAttachments').val().length < 1) {
                alert("Select lead file to upload");
                $('#fuAttachments').focus();
                valid = false;
            }
            else if ($('#txtNoofRecords').val().length < 1) {
                alert("Enter no of records to upload");
                $('#txtNoofRecords').focus();
                valid = false;
            }
            else if ($('#txtNoofRecords').val() < 1) {
                alert("Enter valid no of records To Upload");
                $('#txtNoofRecords').focus();
                valid = false;
            }
            if (valid == true) {
                $('#btnSubmit').val('Please Wait');
            }
            return valid;

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
            <td style="width: 280px;">
                <a>
                    <img src="images/logo2.png" /></a>
            </td>
            <td>
                <h1 style="border-bottom: none; padding-top: 5px;">
                    UNITED CAR EXCHANGE <span>Leads Upload</span></h1>
            </td>
            <td style="width: 470px; padding-top: 10px;">
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
        <div class="clear">
            &nbsp;</div>
        <table style="width: 100%;">
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td style="vertical-align: top; width: 100px;">
                                Vehicle Category <span class="star">*</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlVehicleType" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Cars" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="RVs" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Bikes" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Boats" Value="4"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 350px; text-align: right" rowspan="4">
                                <%-- <asp:LinkButton runat="server" ID="LinkButton1" Text="State Wise Allocatin Leads"
                                    PostBackUrl="~/LeadAssign.aspx"></asp:LinkButton>
                                <br />
                                <asp:LinkButton runat="server" ID="LinkButton2" Text="Leads Download" PostBackUrl="~/LeadDownLoad.aspx"></asp:LinkButton>
                                <br />
                                <asp:LinkButton runat="server" ID="LinkButton3" Text="Leads Download History" PostBackUrl="~/LeadDownLoadHistory.aspx"></asp:LinkButton>
                                <br />--%>
                                <asp:LinkButton runat="server" ID="LinkButton4" Text="Leads UpLoad History" PostBackUrl="~/LeadsUploadHistory.aspx"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Select Sale file <span class="star">*</span>
                            </td>
                            <td colspan="2">
                                <asp:FileUpload ID="fuAttachments" runat="server" />
                                &nbsp;
                                <asp:LinkButton runat="server" ID="lnkRefQCText" Text="Help" onmouseover="return overlib1(document.getElementById('SalesUploadHelp').innerHTML,STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 260,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');"
                                    onmouseout="return nd1(4000);" Font-Size="11px"></asp:LinkButton>
                                <br />
                                <small style="color: #777"><i>( Max 8000 records can upload )</i></small>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                # of Records <span class="star">*</span>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtNoofRecords" runat="server" Width="145px" CssClass="sample4"
                                    MaxLength="4"></asp:TextBox><br />
                                <asp:Label ID="lblErrorMsg" runat="server" Style="color: red; display: inline-block;
                                    line-height: 30px;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="btnSubmit" Text="Process" CssClass="g-button g-button-submit"
                                                OnClick="btnSubmit_Click" />
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="btnUpload" Text="Upload" Enabled="false" CssClass="g-button g-button-submit"
                                                OnClick="btnUpload_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="width: 100%;" id="divresults" runat="server">
                        <div style="width: 750px; position: relative; padding: 0 3px; height: 1px">
                            <asp:UpdatePanel ID="UpdtpnlHeader" runat="server">
                                <ContentTemplate>
                                    <table id="Header" runat="server" class="grid1" cellpadding="0" cellspacing="0" style="position: absolute;
                                        top: 2px; width: 950px; background: #fff; border-top: #fff 2px solid;">
                                        <tr class="tbHed">
                                            <td width="100px">
                                                <asp:Label ID="lblPhoneno" runat="server" Text="Phoneno"></asp:Label>
                                            </td>
                                            <td width="80px">
                                                Price
                                            </td>
                                            <td width="150px">
                                                <asp:Label ID="lblHeader" runat="server" Text="Header"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lnkCustomerEmail" runat="server" Text="Description"></asp:Label>
                                            </td>
                                            <td width="160px">
                                                <asp:Label ID="lnkLanguage" runat="server" Text="URL"></asp:Label>
                                            </td>
                                            <td width="100px">
                                                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                                            </td>
                                            <td width="60px">
                                                <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div style="width: 100%; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                            border: #ccc 1px solid; height: 400px">
                            <asp:Panel ID="pnl1" Width="100%" runat="server">
                                <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grdErrors" runat="server" CellPadding="0" TabIndex="8" CssClass="scrollTable"
                                            Width="99%" GridLines="Both" AutoGenerateColumns="False">
                                            <HeaderStyle CssClass="headder" />
                                            <PagerSettings Position="Top" />
                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                            <RowStyle CssClass="row1" />
                                            <AlternatingRowStyle CssClass="row2" />
                                            <Columns>
                                                <asp:BoundField DataField="RowNo" HeaderText="Row No" HeaderStyle-ForeColor="black"
                                                    HtmlEncode="False" meta:resourcekey="RowNo" SortExpression="RowNo">
                                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Phoneno" HeaderText="Phone No" HeaderStyle-ForeColor="black"
                                                    HtmlEncode="False">
                                                    <ItemStyle Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Error" HeaderText="Error" HeaderStyle-ForeColor="black"
                                                    HtmlEncode="False" meta:resourcekey="Error" SortExpression="Error">
                                                    <ItemStyle Width="50%" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                        <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                        <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                        <asp:GridView Width="950px" ID="grdIntroInfo" runat="server" CellSpacing="0" CellPadding="0"
                                            AutoGenerateColumns="False" GridLines="Both" ShowHeader="false">
                                            <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                            <PagerSettings Position="Top" />
                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                            <HeaderStyle CssClass="headder" />
                                            <PagerSettings Position="Top" />
                                            <RowStyle CssClass="row1" />
                                            <AlternatingRowStyle CssClass="row2" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPhoneno" runat="server" Text='<%# Bind("PhoneNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHeader" runat="server" Text='<%# GenFunc.WrapTextByMaxCharacters(Eval("Header"),20)%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescription" runat="server" Text='<%# GenFunc.WrapTextByMaxCharacters(Eval("Description"),35)%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnDescription" runat="server" Value='<%# Eval("Description")%>'>
                                                        </asp:HiddenField>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="lblURL" runat="server" NavigateUrl='<%# Eval("URL")%>' Text='<%# GenFunc.WrapTextByMaxCharacters(Eval("URL"),25)%>'></asp:HyperLink>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="160px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCity" runat="server" Text='<%# Eval("City")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblState" runat="server" Text='<%# Eval("State")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:Panel>
                        </div>
                        <div class="clear" style="height: 12px;">
                            &nbsp;</div>
                        <asp:UpdatePanel ID="UpdatePane1BtnRefresh" runat="server">
                        </asp:UpdatePanel>
                    </div>
                </td>
            </tr>
        </table>
        <div class="clear">
            &nbsp;</div>
        <br />
    </div>
    <div id="SalesUploadHelp" style="display: none; background-color: #fff">
        <div class="QCTextTitle">
            Help
        </div>
        <div class="QCReferenceText">
            File Format Accepted: .xls/.xlsx
        </div>
        <%--  <div class="QCReferenceText">
            (Microsoft Office Excel 97-2003 Worksheet)
        </div>--%>
        <div class="QCReferenceText">
            <a href="Template/Car Leads Sample.xlsx" target="_blank" class="link">Download Sample
                Sales File</a>
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div id="AlertUser" class="alert" style="display: none">
        <h4 id="H1">
            Alert
            <asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" />
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
            <asp:Button ID="btnYes" class="btn" runat="server" Text="Ok" />
        </div>
    </div>
    </form>
</body>
</html>
