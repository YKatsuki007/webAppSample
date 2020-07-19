<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="WebApplication1.sample.WebUserControl1" %>
<asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="20">
    <Fields>
        <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="false" ShowNextPageButton="false" ShowPreviousPageButton="true" />
        <asp:NumericPagerField ButtonType="Link" />
        <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="false" />
    </Fields>
</asp:DataPager>
<table style="border-collapse: collapse;" border="1">
    <tr>
        <td>&nbsp;<asp:Label ID="Label1" runat="server" Text="no" Width="100px"></asp:Label></td>
        <td>&nbsp;<asp:Label ID="Label2" runat="server" Text="item" Width="100px"></asp:Label></td>
        <td>&nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Width="100px"></asp:Label></td>
    </tr>
</table>

<div style="overflow-y: scroll; height: 200px; width: 350px;">
    <asp:ListView ID="ListView1" runat="server"
        OnPagePropertiesChanging="ListView1_PagePropertiesChanging"
        OnItemDataBound="ListView1_ItemDataBound">
        <ItemTemplate>
            <asp:ListView ID="ListView2" runat="server">
                <ItemTemplate>
                </ItemTemplate>
            </asp:ListView>
        </ItemTemplate>
    </asp:ListView>
</div>
