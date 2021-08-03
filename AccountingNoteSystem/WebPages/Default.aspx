<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebPages.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>系統使用狀態</h3>
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
</asp:Content>
