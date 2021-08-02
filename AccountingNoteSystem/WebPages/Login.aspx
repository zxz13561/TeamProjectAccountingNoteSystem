<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebPages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table border="0">
            <tr>
                <td>
                    <h1>歡迎使用流水帳紀錄系統</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <a href="Default.aspx">回系統首頁</a>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
        </table>
        <asp:PlaceHolder ID="plcLogin" runat="server" Visible="false">
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
            <asp:Label ID="lblLogin" runat="server">您已經登入會員</asp:Label>
            <br />
            <asp:Button ID="btnLogout" runat="server" Text="登出" OnClick="btnLogout_Click" />
            <a><!-- 版面間格用 -->     </a>
            <asp:Button ID="btnGoInfo" runat="server" Text="回會員資訊" OnClick="btnGoInfo_Click" />
        </asp:PlaceHolder>
    </form>
</body>
</html>
