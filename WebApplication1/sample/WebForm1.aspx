<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.sample.WebForm1" ClientIDMode="Static" %>

<%@ Register Src="~/sample/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
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
                                <%--                                <table style="border-collapse: collapse;" border="1">
                                    <tr>--%>
                                <%--                                       <td>&nbsp;<asp:Label ID="Label1" runat="server" Text='<%# Eval("no") %>' Width="100px"></asp:Label></td>
                                        <td>&nbsp;<asp:Label ID="Label2" runat="server" Text='<%# Eval("item") %>' Width="100px"></asp:Label></td>
                                        <td>&nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Width="100px"></asp:Label></td>--%>
                                <asp:ListView ID="ListView2" runat="server">
                                    <ItemTemplate>
                                        <%--                                                <td>

                                                </td>--%>
                                    </ItemTemplate>
                                </asp:ListView>
                                <%--                                 </tr>
                                </table>--%>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        <asp:Panel ID="Panel1" runat="server">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <uc1:WebUserControl1 runat="server" ID="WebUserControl1" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
