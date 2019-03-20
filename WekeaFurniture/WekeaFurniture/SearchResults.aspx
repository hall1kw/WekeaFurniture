<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="SearchResults.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DataList ID="dlSearchResults" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" BorderColor="#753649" BorderStyle="Solid" BorderWidth="3px" HorizontalAlign="Center">
        <ItemTemplate>
            <div class="text-left" style=" margin-top: 10px; margin-bottom: 10px; margin-right: 10px; margin-left: 10px;">
                   
           
                <asp:Image ID="Image2" runat="server" Height="200px" ImageUrl='<%# "Images/ProductImages/" + Eval("IMAGE") %>' width="200px" />
                <br />
                <asp:HyperLink ID="Label1" runat="server" NavigateUrl='<%# "ProductDetail.aspx?ID="+Eval("ID") %>' Text='<%# Eval("NAME") %>'></asp:HyperLink>
                <br />
                <div style="text-align: right">
                    $<asp:Label ID="Label2" runat="server" Text='<%# Eval("PRICE") %>'></asp:Label>

                </div>
                
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

