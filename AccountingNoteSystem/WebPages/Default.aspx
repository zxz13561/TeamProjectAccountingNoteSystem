<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebPages.Default" %>

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
                    <a href="Login.aspx">會員登入/登出</a>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
        </table>
        <table border="0">
            <tr>
                <td style="text-align:right">  第一個記帳時間 : </td>
                <td>
                    <asp:Literal ID="ltlFirstDate" Text="text" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="text-align:right">最後記帳時間 : </td>
                <td>
                    <asp:Literal ID="ltlLastDate" Text="text" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="text-align:right">總記帳筆數 : </td>
                <td>
                    <asp:Literal ID="ltlTotal" Text="text" runat="server" />
                </td>
            </tr>
            <tr>
                <td>目前使用者數量 : </td>
                <td>
                    <asp:Literal ID="ltlMembers" Text="text" runat="server" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
