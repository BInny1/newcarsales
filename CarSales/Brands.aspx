<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Brands.aspx.cs" Inherits="Brands" %>

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
                <h1>
                    Car Sales System<span>Page Name</span></h1>
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
                        <li class="parent current"><a href="Home.aspx">Leads</a>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="LeadsUpload" runat="server" Text="Upload"></asp:LinkButton></li><li>
                                <li>
                                    <asp:LinkButton ID="LeadsDownLoad" runat="server" Text="Download"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Abondoned" runat="server" Text="Abondon"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="FreePackage" runat="server" Text="Free Pkg"></asp:LinkButton></li>
                            </ul>
                        </li>
                        <li class="parent "><a href="">Sales</a>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="IntroMail" runat="server" Text="Intro Mial"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="NewEntry" runat="server" Text="New Entry"></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="Transferin" runat="server" Text="Transfer In"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="MyReport" runat="server" Text="My Report"></asp:LinkButton></li>
                            </ul>
                        </li>
                        <li class="parent"><a href="">Process</a>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="QC" runat="server" Text="QC"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Payments" runat="server" Text="Payments"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Publish" runat="server" Text="Publish"></asp:LinkButton></li>
                            </ul>
                        </li>
                        <li class="parent "><a href="">Reports</a>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="Leads" runat="server" Text="Leads"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Sales" runat="server" Text="Sales"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Process" runat="server" Text="Process"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="Executive" runat="server" Text="Exceutive"></asp:LinkButton></li>
                            </ul>
                        </li>
                        <li class="parent "><a href="">Admin</a>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="LeadsAdmin" runat="server" Text="Leads"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="SalesAdmin" runat="server" Text="Sales" PostBackUrl="AllEmployeeUserRights"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="ProcessAdmin" runat="server" Text="Process"></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="ExecutiveAdmin" runat="server" Text="Executive"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="BrandsAdmin" runat="server" Text="Brands" PostBackUrl="~/Brands1.aspx"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="CentersAdmin" runat="server" Text="Centers" PostBackUrl="~/UpdateCentersList.aspx"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="UsersLog" runat="server" Text="User Log"></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="EditLog" runat="server" Text="Edit Log"></asp:LinkButton></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- Headder End  -->
        <!-- Content Start  -->
        <div class="content wid1000">
            <div class=" box1 box50p">
                <h1 class="hed1 hed2">
                    Search</h1>
                <div class="inn">
                    <!-- Start  -->
                  
                    <asp:GridView  ID="GridVehicletype" runat="server" CellSpacing="0" CellPadding="0"
                        AutoGenerateColumns="False" GridLines="None" CssClass="table table-hover table-striped">
                        <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                       
                        <PagerSettings Position="Top" />
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                       
                       
                        <Columns>
                            <asp:TemplateField>
                          <HeaderTemplate>
                         <asp:Label Text="SNo." runat="server" CssClass="tbHed"></asp:Label>
                          </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkUName" runat="server" Text='<%# Eval("TypeId")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                              <HeaderTemplate>
                        <asp:Label ID="Label1" Text="Vehicle Type" runat="server" CssClass="tbHed"></asp:Label>
                          </HeaderTemplate>
                                <ItemTemplate>
                                   <HeaderTemplate>
                                            <asp:Label ID="lbl1n_HT" runat="server" Text="Status"></asp:Label>
                                        </HeaderTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("VehicleTypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <!-- End  -->
                </div>
            </div>
            <div class=" box1 box50p">
                <h1 class="hed1 hed2">
                    Brands <b>
                        <asp:LinkButton ID="lnkBrndNew" runat="server" Text="New" OnClick="lnkBrndNew_Click" CssClass="floarR" ></asp:LinkButton></b>
                </h1>
                <div class="inn">
                    <!-- Start -->
               
                    <asp:GridView ID="GridBrands" runat="server" CellSpacing="0" CellPadding="0"
                        CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None">
                        <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle CssClass="tbHed" />
                        <PagerSettings Position="Top" />
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                     
                        <Columns>
                            <asp:TemplateField HeaderText="SNo.">
                                <ItemTemplate >
                                    <asp:LinkButton ID="lnkUName" runat="server" Text='<%# Eval("BId")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vehcile Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("VName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText=" Brand">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Brands") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Stat") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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
                        <asp:TextBox ID="txtVeckType" MaxLength="20" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Brand
                    </td>
                    <td>
                        <asp:TextBox ID="txtBrnad" MaxLength="20" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Status
                    </td>
                    <td>
                        <div style="display:inline-block; width:190px;" class="noMargin">
                        <asp:RadioButtonList ID="rbt_VechGrop" runat="server" RepeatColumns="2">
                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>InActive</asp:ListItem>
                        </asp:RadioButtonList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        
                    </td>
                    <td align="left">
                        <div style=" margin: 0; padding-left: 0px; display:inline-block">
                            <asp:UpdatePanel ID="updtPnlChangePwd" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnAddVehicle" class="btn btn-danger btn-warning" runat="server"
                                        Text="Add" OnClick="btnAddVehicle_Click" />&nbsp;
                                </ContentTemplate>
                            </asp:UpdatePanel>
                         </div>
                        <asp:Button ID="btnCancelPW" class="btn btn-danger btn-warning" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
