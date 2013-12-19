<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="UserControl_Header" %>
<table style="width: 100%">
    <td style="width: 250px;">
        <a href="index.aspx">
            <img src="images/logo2.png" /></a>
    </td>
    <td>
        <h1 class="h11" style="border-bottom: none">
            Car Sales System</h1>
    </td>
    <td style="width: 250px;">
        <div class="loginStat">
             &nbsp;<asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
            <br />
            <a href="index.aspx" class="home">Home</a>&nbsp; | &nbsp;<asp:LinkButton ID="lnkBtnLogout"
                runat="server" Text="Logout" Visible="false" OnClick="lnkBtnLogout_Click"></asp:LinkButton></div>
    </td>
</table>
