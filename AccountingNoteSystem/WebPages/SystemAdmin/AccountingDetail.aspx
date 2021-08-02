<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="AccountingDetail.aspx.cs" Inherits="WebPages.SystemAdmin.AccountingDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <th colspan="2">
                <h3>紀錄編輯</h3>
            </th>
        </tr>
        <tr>
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
            <td style="text-align:right">
                金額 : 
            </td>
            <td>
                <asp:TextBox ID="txtAmount" runat="server" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">
                標題:
            </td>
            <td>
                <asp:TextBox ID="txtCaption" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right;">
                描述:
            </td>
            <td>
                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
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
</asp:Content>
