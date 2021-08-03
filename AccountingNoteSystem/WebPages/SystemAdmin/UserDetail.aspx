<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="WebPages.SystemAdmin.UserDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>編輯會員資料</h3>
    <table>
        <tr>
            <td style="text-align:right">
                ID : 
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtID" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">
                帳號 : 
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtAccount" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <asp:PlaceHolder ID="plcPwd" runat="server" Visible="false">
            <tr>
                <td style="text-align:right">
                    密碼 : 
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtPwd" runat="server" Enabled="false" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
        </asp:PlaceHolder>
        <tr>
            <td style="text-align:right">
                姓名 : 
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right;">
                Email :
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">
                等級 : 
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlUserLevel" runat="server" Enabled="false">
                    <asp:ListItem Value="0">管理者</asp:ListItem>
                    <asp:ListItem Value="1">一般會員</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align:right;">
                建立日期 :
            </td>
            <td colspan="2">
                <asp:Literal ID="ltlCreateDate" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="儲存"/>
                <b>&nbsp;&nbsp;</b>
                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="刪除"/>
            </td>
            <td style="font-family:Arial;color:red">
                <asp:Literal Text="" ID="ltlMsg" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
