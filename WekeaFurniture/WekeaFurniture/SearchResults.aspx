<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="SearchResults.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style5" style="width:250px; border-right-style:solid; border-right-width:3px; border-right-color:#782b42; background-color: #FFFFFF;">
            <div class="text-center">
                <h3 style="background-color: #FFFFFF; color: #753649;">Featured Products<br />
                </h3>
            </div>
            <asp:DataList ID="dlSearchResFeat" runat="server">
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
                                    <asp:HyperLink ID="Label1" style="color:#782b42;" runat="server" NavigateUrl='<%# "ProductDetail.aspx?ID="+Eval("ID") %>' Text='<%# Eval("NAME") %>' Font-Size="Medium"></asp:HyperLink>
                                    </strong></h5>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:250px; border-bottom-style:solid; border-bottom-width:3px; border-bottom-color:#782b42; color: #743548;" class="text-right">$<asp:Label ID="Label2" runat="server" Text='<%# Eval("PRICE") %>' ForeColor="#753649"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            </td>
            <td>    <asp:DataList ID="dlSearchResults" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" BorderColor="#753649" BorderStyle="Solid" BorderWidth="3px" HorizontalAlign="Center">
        <ItemTemplate>
            <div class="text-left" style="width:220px; margin-top: 10px; margin-bottom: 10px; margin-right: 10px; margin-left: 10px;">
                <a href="<%# "ProductDetail.aspx?ID="+Eval("ID") %>"><asp:Image ID="Image2" runat="server" Height="200px" ImageUrl='<%# "Images/ProductImages/" + Eval("IMAGE") %>' width="200px" /></a>
                <br />
                <asp:HyperLink ID="Label1" runat="server" NavigateUrl='<%# "ProductDetail.aspx?ID="+Eval("ID") %>' Text='<%# Eval("NAME") %>'></asp:HyperLink>
                <br />
                <div style="text-align: right">
                    $<asp:Label ID="Label2" runat="server" Text='<%# Eval("PRICE") %>'></asp:Label>
                </div>
                
            </div>
        </ItemTemplate>
    </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>

