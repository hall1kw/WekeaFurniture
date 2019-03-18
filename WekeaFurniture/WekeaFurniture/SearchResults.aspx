<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="SearchResults.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DataList ID="dlSearchResults" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
        <ItemTemplate>
            <asp:Image ID="Image2" runat="server" ImageUrl='<%# "Images/" + Eval("IMAGE") %>' />
            <br />
            <asp:Hyperlink ID="Label1" runat="server" NavigateUrl='<%# "ProductDetail.aspx?ID="+Eval("ID") %>' Text='<%# Eval("NAME") %>'></asp:Hyperlink>
            <br />
            $<asp:Label ID="Label2" runat="server" Text='<%# Eval("PRICE") %>'></asp:Label>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

