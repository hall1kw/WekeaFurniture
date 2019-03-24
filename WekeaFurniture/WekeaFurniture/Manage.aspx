<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>        
        body {
            background-color: f8f9fa;
        }
        .newStyle1 {
            font-family: Arial;
        }
        .auto-style1 {
            width: 86px;
            height: 46px;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <p>
        <asp:DataList ID="dlFeatured" runat="server" HorizontalAlign="Center" RepeatColumns="3" RepeatDirection="Horizontal">
            <ItemTemplate>
                <table style="width:100%; ">
                    <tr>
                        <td style="width:250px;">
                            <asp:Image ID="Image2" style="width:300px; height:300px;" runat="server" ImageUrl='<%# "Images/ProductImages/" + Eval("IMAGE") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td class="text-center">
                            <h5 class="text-center" ><strong>
                            <asp:HyperLink ID="Label1" style="color:#782b42;" runat="server" NavigateUrl='<%# "ProductDetail.aspx?ID="+Eval("ID") %>' Text='<%# Eval("NAME") %>'></asp:HyperLink>
                                </strong></h5>
                        </td>
                    </tr>
                    <tr>
                        <td class="text-right">
                            $<asp:Label ID="Label2" runat="server" Text='<%# Eval("PRICE") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </p>
    
    
</asp:Content>

