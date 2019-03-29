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
            <td class="auto-style5" style="width:250px; border-right-style:solid; border-right-width:3px; border-right-color:#782b42">
            <div class="text-center">
                <h3>Featured Products<br />
                </h3>
            </div>
            <asp:DataList ID="dlDetailFeat" runat="server">
                <ItemTemplate>
                    <table style="width:100%;">
                        <tr>
                            <td class="text-center">
                                <asp:Image ID="Image2" runat="server" style="width:200px; height:200px;" ImageUrl='<%# "/Images/ProductImages/" + Eval("IMAGE") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h5 class="text-center" ><strong>
                                    <asp:HyperLink ID="Label1" style="color:#782b42;" runat="server" NavigateUrl='<%# "ProductDetail.aspx?ID="+Eval("ID") %>' Text='<%# Eval("NAME") %>'></asp:HyperLink>
                                    </strong></h5>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:250px; border-bottom-style:solid; border-bottom-width:3px; border-bottom-color:#782b42" class="text-right">$<asp:Label ID="Label2" runat="server" Text='<%# Eval("PRICE")  %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            </td>
            <td>
                <asp:DataList ID="dlProductDetail" runat="server">
                    <ItemTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td colspan="2">
                                    <h2>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("NAME") %>'></asp:Label>
                                    </h2>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Image ID="Image2" runat="server" style="width:500px; height:500px;" ImageUrl='<%# "Images/ProductImages/" + Eval("IMAGE") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td style="border-top-style:solid; border-top-color:#772b43; border-top-width:3px;" colspan="2">
                                    <asp:Label ID="Label3"  runat="server" Text='<%# Eval("DESCRIPTION") %>' Width="500px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="text-right" colspan="2">$<asp:Label ID="Label2" runat="server" Text='<%# Eval("PRICE") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="text-left">
                                    Currently in stock:
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("INVENTORY") %>'></asp:Label>
                                </td>
                                <td class="text-right">
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add To Cart" UseSubmitBehavior="False" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>

