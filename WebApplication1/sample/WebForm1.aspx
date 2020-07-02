<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.sample.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="30">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="false" ShowNextPageButton="false" ShowPreviousPageButton="true" />
                    <asp:NumericPagerField />
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
            <div style="overflow-y: scroll; height: 200px; width :350px;">
                <asp:ListView ID="ListView1" runat="server">
                    <ItemTemplate>
                        <table style="border-collapse: collapse;" border="1">
                            <tr>
                                <td>&nbsp;<asp:Label ID="Label1" runat="server" Text='<%# Eval("no") %>' Width="100px"></asp:Label></td>
                                <td>&nbsp;<asp:Label ID="Label2" runat="server" Text='<%# Eval("item") %>' Width="100px"></asp:Label></td>
                                <td>&nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Width="100px"></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </form>
</body>
</html>
