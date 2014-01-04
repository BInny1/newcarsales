<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeadsUpload.aspx.cs" Inherits="LeADSuPs" %>

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
                        <li class="parent active"><a href="#">Leads <span class="cert"></span></a>
                            <ul class="sub1">
                                <li class="act">
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
        <div class="content">
            <div class=" box1 boxBlue">
                <h1 class="hed1 hed2">
                    <asp:UpdatePanel ID="updaproducts" runat="server">
                        <ContentTemplate>
                            Leads Upload
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </h1>
                <div class="content wid1000">
                    <div class=" box1 box100p">
                        <table>
                            <tr>
                                <td  align="center">
                                    Vehicle Category <span class="star">*</span>
                                </td>
                                <td style="width:200px;">
                                    <asp:DropDownList ID="ddlVehicleType" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Cars" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="RVs" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Bikes" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Boats" Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" ID="LinkButton4" Text="Leads UpLoad History" PostBackUrl="~/LeadsUploadHistory.aspx"
                                        Style="color: blue; text-decoration: underline;" CssClass="floarR"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td  align="center">
                                    Select Sale file <span class="star">*</span>
                                </td>
                                <td >
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
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
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
                                <td>
                                    <asp:Button runat="server" ID="btnSubmit" Text="Process" CssClass="btn btn-warning"
                                        OnClick="btnSubmit_Click" />
                                    <asp:Button runat="server" ID="btnUpload" Text="Upload" Enabled="false" CssClass="btn btn-default"
                                        OnClick="btnUpload_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="inn">
                    <!-- Start  -->
                    <table style="width: 98%;">
                        <tr>
                            <td>
                                <div style="width: 100%;" id="divresults" runat="server">
                                    <div style="width: 750px; position: relative; padding: 0 3px; height: 1px" class=" "
                                        class="table table-hover table-striped">
                                        <table id="Header" class="table table-hover table-striped MB0 table1">
                                            <tr class="tbHed">
                                                <td width="200px">
                                                    <asp:Label ID="lblPhoneno" runat="server" Text="Phoneno"></asp:Label>
                                                </td>
                                                <td width="180px">
                                                    Price
                                                </td>
                                                <td width="250px">
                                                    <asp:Label ID="lblHeader" runat="server" Text="Header"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lnkCustomerEmail" runat="server" Text="Description"></asp:Label>
                                                </td>
                                                <td width="600px">
                                                    <asp:Label ID="lnkLanguage" runat="server" Text="URL"></asp:Label>
                                                </td>
                                                <td width="200px">
                                                    <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                                                </td>
                                                <td width="160px">
                                                    <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="width: 100%; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                        border: #ccc 1px solid; height: 400px">
                                        <asp:Panel ID="pnl1" Width="100%" runat="server">
                                            <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grdErrors" runat="server" CellPadding="0" TabIndex="8" CssClass="scrollTable table table-hover table-striped"
                                                        Width="99%" GridLines="Both" AutoGenerateColumns="False">
                                                        <HeaderStyle CssClass="" />
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
                                                        CssClass="table table-hover table-striped  MB0 noBorder" AutoGenerateColumns="False"
                                                        ShowFooter="true" GridLines="None">
                                                        <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle CssClass="tbHed" />
                                                        <PagerSettings Position="Top" />
                                                        <FooterStyle BackColor="#C6C3C6" CssClass="tbHed center" />
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
                                                                <ItemStyle HorizontalAlign="Left" Width="1000px" />
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
                    <!-- End  -->
                </div>
            </div>
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
            <a href="Template/Car Leads Sample.xlsx" target="_blank" class="link" style="color: blue;
                text-decoration: underline;">Download Sample Sales File</a>
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
    <!-- New Vechlie Click -->
    </form>
</body>
</html>
