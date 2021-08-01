<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="WebPages.SystemAdmin.UserInfo" %>

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
                <td colspan="4">
                    <h1>歡迎使用流水帳紀錄系統 - 後台</h1>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <a href="../Login.aspx">會員登入/登出</a>
                </td>
                <td>
                    <a href="/SystemAdmin/AccountingList.aspx">流水帳紀錄</a>
                </td>
                <td>
                    <a href="/SystemAdmin/UserList.aspx">帳號管理</a>
                </td>
                <td>
                    <a href="/SystemAdmin/UserInfo.aspx">個人資料</a>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <hr />
                </td>
            </tr>
        </table>
        <table style="border:3px solid;" border="0">
            <tr>
                <td colspan="3">
                    <h2>個人資料</h2>
                </td>
            </tr>
            <tr>
                <td width="50"></td>
                <td>帳號</td>
                <td>
                    <asp:Literal ID="ltlAcc" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>姓名</td>
                <td>
                    <asp:Literal ID="ltlName" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>E-mail</td>
                <td>
                    <asp:Literal ID="ltlEmail" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td  colspan="3">
                    <asp:Button ID="btnLogout" Text="登出" runat="server" OnClick="btnLogout_Click"/>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
