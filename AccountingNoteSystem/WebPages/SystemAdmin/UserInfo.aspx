<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="WebPages.SystemAdmin.UserInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>個人資料</h3>    
    <table style="border:2px solid;" border="0">
        <tr>
            <th style="text-align:right">帳號 : </th>
            <td>
                <asp:Literal ID="ltlAcc" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th style="text-align:right">姓名 : </th>
            <td>
                <asp:Literal ID="ltlName" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th style="text-align:right">E-mail : </th>
            <td>
                <asp:Literal ID="ltlEmail" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnLogout" Text="登出" runat="server" OnClick="btnLogout_Click"/>
</asp:Content>
