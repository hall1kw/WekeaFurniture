<%@ Page Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Confirmation.aspx.cs" Inherits="Confirmation" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2 style="margin: auto; width: 50%;">Order Confirmation</h2>
    <br />

    <div style="margin: auto; width: 50%; padding: 5px; font-weight: bold; color: red;">
        <asp:Label ID="BackOrderWarning" runat="server" Text="" Font-Size="Large"></asp:Label>
    </div>

    <div id="ConfirmationMessage" style="margin: auto; width: 50%;">
        <h3>Hello,</h3>
        <p>Thank you for your order. We have sent out a confirmation letter to your given email address, and will begin the shipping process. Thank you for your order!</p>
    </div>

    <div id="ShippingInfo" style="border-top: 1px solid black; background-color: gainsboro; margin: auto; width: 50%;">
        <p><strong>Your order will be sent to:</strong></p>
        <table>
            <asp:Label ID="lblShipName" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="lblShipAddOne" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="lblShipAddTwo" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="lblShipCity" runat="server" Text="Label"></asp:Label><br />
        </table>
    </div>

    <div id="OrderDetails" style="margin: auto; width: 50%;">
        <div style="margin: auto; width: 50%;">
        <h3>Order Details</h3>
        <p>
            <asp:DataList ID="dlCartSummary" runat="server">
                <ItemTemplate>
                    <table style="width:100%;">
                        <tr>
                            <td rowspan="2" class="text-left">
                                <asp:Image ID="Image4" style="margin-left:15px; width:50px; height:50px;" runat="server" ImageUrl='<%# "/Images/ProductImages/" + Eval("IMAGE") %>' />
                            </td>
                            <td>&nbsp;</td>
                            <td class="text-right" style="S; font-size: small;">Item Price: $<asp:Label ID="Label2" runat="server" Font-Size="Small" Text='<%# String.Format("{0:n}",Eval("PRICE")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="text-right" style="font-size: small">QTY:
                                <asp:Label ID="Label3" runat="server" Font-Size="Small" Text='<%# Eval("QUANTITY") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left" colspan="3">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text='<%# Eval("NAME") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right" colspan="3" style="font-size: medium; border-bottom-style: solid; border-bottom-width: 2px; border-bottom-color: #753649;">Item Total: $<asp:Label ID="Label4" runat="server" Font-Size="Small" Text='<%# String.Format("{0:n}", Double.Parse(Eval("PRICE").ToString()) * Int32.Parse(Eval("QUANTITY").ToString())) %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>

            <div>
                <asp:Label ID="lblSubtotal" runat="server" Text="Label" Font-Size="Large"></asp:Label>
                <br />
                <span class="auto-style19">&nbsp;</span><br />
                <asp:Label ID="lblTax" runat="server" Text="Label" Font-Size="Large"></asp:Label>
                <br />
                <span class="auto-style19">&nbsp;</span><br />
                <asp:Label ID="lblTotal" runat="server" Text="Label" Font-Size="Large"></asp:Label>
                <br />
            </div>
        </p>
        </div>
    </div>

</asp:Content>

