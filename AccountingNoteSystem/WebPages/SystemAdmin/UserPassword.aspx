<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserPassword.aspx.cs" Inherits="WebPages.SystemAdmin.UserPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>會員密碼變更</h3>
    <table>
        <tr>
            <td style="text-align:right">帳號 : </td>
            <td>
                <asp:Literal ID="ltlAcc" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align:right">原密碼 : </td>
            <td>
                <asp:TextBox runat="server" ID="txtOldPwd" TextMode="Password"/>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">確認密碼 : </td>
            <td>
                <asp:TextBox runat="server" ID="txtPwdCheck" TextMode="Password"/>
            </td>
        </tr>
        <tr>
            <td></td>
            <td style="font-family:微軟正黑體;color:red">
                <asp:Literal ID="ltlCheckMsg" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align:right">新密碼 : </td>
            <td>
                <asp:TextBox runat="server" ID="txtNewPwd" TextMode="Password"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button Text="變更密碼" ID="btnChangePwd" OnClick="btnChangePwd_Click" runat="server" />
            </td>
            <td style="font-family:微軟正黑體;color:red">
                <asp:Literal ID="ltlErrMsg" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
