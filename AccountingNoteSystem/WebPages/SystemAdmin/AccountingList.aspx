<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="WebPages.SystemAdmin.AccountingList" %>

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
                <td>
                    <asp:Button Text="新增一筆資料" ID="btnCreate" runat="server" OnClick="btnCreate_Click"/>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:GridView ID="gvAccountList" runat="server" AutoGenerateColumns="false" Width="353px" OnRowDataBound="gvAccountList_RowDataBound" >
                        <Columns>
                            <asp:BoundField HeaderText="建立日期" DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:TemplateField HeaderText="收/支">
                                <ItemTemplate>
                                    <asp:Label ID="lblActType" runat="server" />
                                    <asp:Literal ID="ltActType" runat="server" Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="金額" DataField="Amount" />
                            <asp:BoundField HeaderText="標題" DataField="Caption" />
                            <asp:TemplateField HeaderText="Act">
                                <ItemTemplate>
                                    <a href="/SystemAdmin/AccountingDetail.aspx?ID=<%#Eval("ID")%>">Edit</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:PlaceHolder runat="server" ID="plcNoData" Visible="true">
                        <p style="font-family : Arial;color : red;">
                            No data in your Accounting Note.
                        </p>
                    </asp:PlaceHolder>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
