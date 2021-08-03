<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="WebPages.SystemAdmin.UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>會員管理</h3>
    <table>
        <tr>
            <td>
                <asp:Button ID="btnAddAccount" runat="server" OnClick="btnAddAccount_Click" text="新增會員"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvUserList_RowDataBound" >
                    <Columns>
                        <asp:BoundField HeaderText="帳號" DataField="Account" />
                        <asp:BoundField HeaderText="姓名" DataField="Name" />
                        <asp:BoundField HeaderText="E-mail" DataField="Email" />
                        <asp:TemplateField HeaderText="等級">
                            <ItemTemplate>
                                <asp:Label ID="lblUserLevel" runat="server" />
                                <asp:Literal ID="ltlUserLevel" runat="server" Visible="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="建立日期" DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd hh:mm:ss}"/>
                        <asp:TemplateField HeaderText="Act">
                            <ItemTemplate>
                                <a href="/SystemAdmin/UserDetail.aspx?UID=<%#Eval("Account")%>">Edit</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:PlaceHolder ID="plcNoUser" runat="server">
                    <p style="color:red;font-family:Arial;font-size:24px">
                        WARNING! No User Data!
                    </p>
                </asp:PlaceHolder>
            </td>
        </tr>
    </table>
</asp:Content>
