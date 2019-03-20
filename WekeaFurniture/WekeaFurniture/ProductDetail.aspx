<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            width: 251px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style5">Featured Products - To be databound</td>
            <td>
                <asp:DataList ID="dlProductDetail" runat="server">
                    <ItemTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    <h2>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("NAME") %>'></asp:Label>
                                    </h2>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Image ID="Image2" runat="server" style="width:500px; height:500px;" ImageUrl='<%# "Images/ProductImages/" + Eval("IMAGE") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td style="border-top-style:solid; border-top-color:#772b43; border-top-width:3px;">
                                    <asp:Label ID="Label3"  runat="server" Text='<%# Eval("DESCRIPTION") %>' Width="500px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="text-right">$<asp:Label ID="Label2" runat="server" Text='<%# Eval("PRICE") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>

