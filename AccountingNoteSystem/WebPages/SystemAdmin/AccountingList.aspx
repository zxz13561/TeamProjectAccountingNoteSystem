<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="WebPages.SystemAdmin.AccountingList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Button Text="新增一筆資料" ID="btnCreate" runat="server" OnClick="btnCreate_Click"/>
            </td>
        </tr>
        <tr>
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
</asp:Content>
