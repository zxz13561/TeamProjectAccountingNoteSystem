<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingDetail.aspx.cs" Inherits="WebPages.SystemAdmin.AccountingDetail" %>

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
        <table>
            <tr>
                <td width="50"></td>
                <td style="text-align:right">
                    收/支 : 
                </td>
                <td>
                    <asp:DropDownList ID="ddlActType" runat="server">
                        <asp:ListItem Value="0">支出</asp:ListItem>
                        <asp:ListItem Value="1">收入</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td></td>
                <td style="text-align:right">
                    金額 : 
                </td>
                <td>
                    <asp:TextBox ID="txtAmount" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td style="text-align:right">
                    標題:
                </td>
                <td>
                    <asp:TextBox ID="txtCaption" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td style="text-align:right;">
                    描述:
                </td>
                <td>
                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="儲存"/>
                    <b>&nbsp;&nbsp;</b>
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="刪除"/>
                    <b>&nbsp;&nbsp;</b>
                    <asp:Literal Text="" ID="ltlMsg" runat="server" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
