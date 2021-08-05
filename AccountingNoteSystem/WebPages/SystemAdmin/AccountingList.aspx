<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="WebPages.SystemAdmin.AccountingList" %>

<%@ Register Src="~/SystemAdmin/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>流水帳紀錄</h3>
    <table>
        <tr>
            <td>
                <asp:Button Text="新增一筆資料" ID="btnCreate" runat="server" OnClick="btnCreate_Click"/>
            </td>
            <td style="text-align:right">
                <asp:Literal ID="ltlSubtotal" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvAccountList" runat="server" AutoGenerateColumns="False" Width="353px" OnRowDataBound="gvAccountList_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
        <tr>
            <td>
                <uc1:ucPager runat="server" id="ucPager" PageSize="10" CurrentPage="1" Url="/SystemAdmin/AccountingList.aspx"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:PlaceHolder runat="server" ID="plcNoData" Visible="true">
                    <p style="font-family : Arial;color : red;">
                        No data in your Accounting Note.
                    </p>
                </asp:PlaceHolder>
            </td>
        </tr>
    </table>
</asp:Content>
