q<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeadAssign.aspx.cs" Inherits="LeadAssign1" %>

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

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

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
    <form runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
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
                        <li class="parent "><a href="#">Sales <span class="cert"></span></a>
                            <ul class="sub1">
                                <li>
                                    <asp:LinkButton ID="IntroMail" runat="server" Text="Intro Mial" Enabled="false"></asp:LinkButton></li>
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
                                        <li class="last">
                                            <asp:LinkButton ID="LeadsSatus" runat="server" Text="Leads Status" PostBackUrl="~/StateWiseLeadsStatus.aspx"></asp:LinkButton></li>
                                    </ul>
                                </li>
                                <li class="act"><a href="#">Sales <span class="cert"></span></a>
                                    <ul class="sub2">
                                        <li>
                                            <asp:LinkButton ID="SalesAdmin" runat="server" Text="User Rights" PostBackUrl="~/SalesUserRights.aspx"
                                                Enabled="false"></asp:LinkButton></li>
                                        <li class="act">
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
        <div class="content ">
            <div class="inn">
                <div class="box1 boxBlue">
                    <h1 class="hed1 hed2" style="margin-bottom: 0">
                        Leads Assign</h1>
                    <div class="inn">
                        <div style="height: 10px;">
                            &nbsp;
                        </div>
                        <div class="inn" style="margin: 0; padding: 0; "">
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
                                            <h4>
                                                Center wise lead allocation</h4>
                                            <table class="table table-hover table-striped ">
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
                    </div>
                </div>
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div style="height: 10px;">
        </div>
        <cc1:ModalPopupExtender ID="mpelblUerExist" runat="server" PopupControlID="tblUpdate"
            BackgroundCssClass="ModalPopupBG" TargetControlID="hdnlblUerExist" CancelControlID="ImageButton1">
        </cc1:ModalPopupExtender>
        <asp:HiddenField ID="hdnlblUerExist" runat="server" />
        <div id="tblUpdate" style="display: none; width: 550px;" class="popup">
            <h2>
                Assign leads to a center
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images\close.png" CssClass="floarR" /></h2>
            </h2>
            <div class="content">
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
                <asp:Button ID="btnGo" runat="server" Text="Ok" CssClass="btn btn-warning" OnClientClick="return Validate();"
                    OnClick="btnGo_Click" />
                <asp:Button ID="btnCancelAssign" runat="server" Text="Cancel" CssClass="btn btn-default"
                    Visible="false" />
                <div class="clearFix">
                    &nbsp</div>
            </div>
        </div>
        <cc1:ModalPopupExtender ID="MpeQcPopUp" runat="server" PopupControlID="QcAdding"
            BackgroundCssClass="ModalPopupBG" TargetControlID="hdnQcPop" CancelControlID="ImageButton1">
        </cc1:ModalPopupExtender>
        <asp:HiddenField ID="hdnQcPop" runat="server" />
        <div id="QcAdding" style="display: none; width: 1000px; height: 450px;" class="popup">
            <h2>
                <span style="float: left;">Lead rejection criteria</span> <span style="float: right;
                    font-size: 10px">(QC fails for matching any of the following conditions)</span>
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="images\close.png" CssClass="floarR" /></h2>
            <div class="content">
                <div class="scroll1" style="border: 2px solid #CCC">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <h1 class="hed1 hed2" style="margin-bottom: 0">
                                Phone # range</h1>
                            <table>
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
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 50%;">
                                        <h1 class="hed1 hed2" style="margin-bottom: 0">
                                            Price range</h1>
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
                                    </td>
                                    <td>
                                        <h1 class="hed1 hed2" style="margin-bottom: 0">
                                            Model year range</h1>
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
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h1 class="hed1 hed2" style="margin-bottom: 0">
                                            Mileage range</h1>
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
                                    </td>
                                    <td>
                                        <h1 class="hed1 hed2" style="margin-bottom: 0">
                                            Lead date range</h1>
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
                                            <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="btn btn-warning" OnClick="btnSave_Click" /></span>
                                        <span>
                                            <asp:Button ID="btnCANCEL" Text="CANCEL" runat="server" CssClass="btn btn-danger"
                                                OnClick="btnCANCEL_Click" /></span> <span>
                                                    <asp:Button ID="btnApplytoexistingDB" Text="Save/Apply to existing DB" runat="server"
                                                        CssClass="btn bt-default" /></span>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="clearFix">
                        &nbsp</div>
                </div>
            </div>
        </div>
        <cc1:ModalPopupExtender ID="mpealteruserUpdated" runat="server" PopupControlID="AlertUserUpdated"
            BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuserUpdated" CancelControlID="BtnClsUpdated"
            OkControlID="btnYesUpdated">
        </cc1:ModalPopupExtender>
        <asp:HiddenField ID="hdnAlertuserUpdated" runat="server" />
        <div id="AlertUserUpdated"  style="display: none; width: 550px;" class="popup">
            <h2 id="H3">
                Alert
                  <asp:ImageButton ID="BtnClsUpdated" runat="server" ImageUrl="images\close.png" CssClass="floarR" /></h2>
            <div class="content">
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
