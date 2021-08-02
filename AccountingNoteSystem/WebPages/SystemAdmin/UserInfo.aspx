<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="WebPages.SystemAdmin.UserInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="border:3px solid;" border="0">
        <tr>
            <td colspan="3">
                <h3>個人資料</h3>
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
</asp:Content>
