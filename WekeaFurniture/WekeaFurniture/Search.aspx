<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
    <style type="text/css">
        .auto-style4 {
            width: 60%;
        }
        .auto-style5 {
            margin-left: 0px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<table style="margin-left:20px; margin-right:-20px;">
    <tr>
        <td class="auto-style4" style="border: 1px solid;">Featured Products - Needs to be databound</td>
        <td style="width:60%;" class="text-right">
            <h2 class="text-center">Search</h2>
            <br />
            <div class="text-left">
            <asp:Table ID="Table1" runat="server" Height="216px" Width="346px" CssClass="auto-style5">
        <asp:TableRow>
            <asp:TableCell>ID: </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbId" runat="server" Text=""></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Name: </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbName" runat="server" Text=""></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Min Price: </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbMinPrice" runat="server" Text=""></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Max Price: </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbMaxPrice" runat="server" Text="" AutoPostBack="False" CausesValidation="False"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Room</asp:TableCell>
            <asp:TableCell>
                <asp:CheckBox ID="cbKitchen" Text="Kitchen" runat="server" />
                <asp:CheckBox ID="cbLivingRoom" Text="LivingRoom" runat="server" />
                <asp:CheckBox ID="cbBedroom" Text="Bedroom" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Category</asp:TableCell>
            <asp:TableCell>
                <asp:CheckBox ID="cbChairs" Text="Chairs" runat="server" />
                <asp:CheckBox ID="cbCouches" Text="Couches" runat="server" />
                <asp:CheckBox ID="cbDesks" Text="Desks" runat="server" />
                <asp:CheckBox ID="cbDressers" Text="Dressers" runat="server" />
                <asp:CheckBox ID="cbLamps" Text="Lamps" runat="server" />
                <asp:CheckBox ID="cbTables" Text="Tables" runat="server" />
                <asp:CheckBox ID="cbBeds" Text="Beds" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
            </div>
            <br />
            <input id="Reset1" type="reset" value="Reset" />&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" UseSubmitBehavior="False" /> </td>
    </tr>
 
</table>
    
</asp:Content>






