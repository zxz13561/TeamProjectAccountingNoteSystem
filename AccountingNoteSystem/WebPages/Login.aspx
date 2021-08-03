<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebPages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="plcLogin" runat="server" Visible="false">
        <h3>會員登入</h3>
        <table border="0">
            <tr>
                <td style="text-align:right;">帳號 :</td>
                <td>
                    <asp:TextBox runat="server" ID="txtAcc"/>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">密碼 :</td>
                <td>
                    <asp:TextBox runat="server" ID="txtPwd"  TextMode="Password"/>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button Text="登入" ID="btnLogin" runat="server" OnClick="btnLogin_Click"/>
                    <asp:Literal ID="ltlMsg" runat="server" />
                </td>
            </tr>
        </table>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="plcErr" runat="server" Visible="false">
        <br />
        <asp:Label ID="lblLogin" runat="server" Font-Names="微軟正黑體">您已經登入會員，要登出嗎?</asp:Label>
        <br />
        <asp:Button ID="btnLogout" runat="server" Text="登出" OnClick="btnLogout_Click" />
        <a><!-- 版面間格用 -->     </a>
        <asp:Button ID="btnGoInfo" runat="server" Text="回系統後台" OnClick="btnGoInfo_Click" />
    </asp:PlaceHolder>
</asp:Content>
