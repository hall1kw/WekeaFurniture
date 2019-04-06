<%@ Page Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>
        $(document).ready(function () {
            var submitButton = '<input id="submitFormButton" type="submit" value="Submit" />';
            $("#billingform").hide();
            $("#credit").hide();
            $("#gift").hide();
            $("#paypal").hide();

            /*On shippment continue click, only show payment options if fields are full*/
            $("#shippmentbutton").click(function () {
                if( $("#Name").val() && $("#Address").val() && $("#City").val() && $("#State").val() && $("#Zip").val() && $("#Country").val() && $("#PhoneNumber").val()) {
                    $("#shippingform").hide();
                    $("#billingform").show();   
                }
            });

            $("#creditbutton").click(function () {
                $("#paypal").hide();
                $("#gift").hide();
                $("#credit").show();

                /*switches select button to a form submit button*/
                $("#creditbutton").hide();
                $("#paypalbutton").show();
                $("#giftbutton").show();
                $("#submitFormButton").remove();
                $("#credit").append(submitButton);
            });

            $("#giftbutton").click(function () {
                $("#paypal").hide()
                $("#credit").hide()
                $("#gift").show()

                /*switches select button to a form submit button*/
                $("#giftbutton").hide();
                $("#paypalbutton").show();
                $("#creditbutton").show();
                $("#submitFormButton").remove();
                $("#gift").append(submitButton);
            });

            $("#paypalbutton").click(function () {
                console.log($("#Name").val())
                $("#gift").hide()
                $("#credit").hide()
                $("#paypal").show()

                /*switches select button to a form submit button*/
                $("#paypalbutton").hide();
                $("#creditbutton").show();
                $("#giftbutton").show();
                $("#submitFormButton").remove();
                $("#paypal").append(submitButton);
            });
        });
    </script>
    <form id="form1" method="post" action="Home.aspx">
    <div id ="checkoutform" style="padding-left: 20px;">
        <div id="shippingform" style="float:left;">
            &nbsp;&nbsp;&nbsp; <h1>Shipping Info</h1>
            &nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp; Full Name:&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;
            <input id="Name" type="text" name="name"/><br />
            <br />
            &nbsp;&nbsp; Address:&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;
            <input id="Address" type="text" name="address"/><br />
            <br />
            &nbsp;&nbsp; City:&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;
            <input id="City" type="text" name="city"/><br />
            <br />
            &nbsp;&nbsp; State/Province/Region:&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;
            <input id="State" type="text" name="state"/> <br />
            <br />
            &nbsp;&nbsp; Zip:&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;
            <input id="Zip" type="text" name="zip"/> <br />
            <br />
            &nbsp;&nbsp; Country/Region:&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;
            <input id="Country" type="text" name="country"/> <br />
            <br />
            &nbsp;&nbsp; Phone Number:&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;
            <input id="PhoneNumber" type="text" name="phonenumber"/> <br />
            <br />
            &nbsp;&nbsp;
            <button id="shippmentbutton" type="button">Continue</button>
        <br />
        </div>

        <div id="billingform" style="float:left;">
            &nbsp;&nbsp;&nbsp; <h1>Payment Info</h1><br />
            &nbsp;&nbsp;
            <h3>Credit or Debit Card:</h3>
                <div id="credit">
                    &nbsp;&nbsp;&nbsp; Name on Card:&nbsp;&nbsp;&nbsp;
                    <br />
                    &nbsp;&nbsp;
                    <input id="CardName" type="text" name="cardname"/><br />
                    <br />
                    &nbsp;&nbsp; Card Number:&nbsp;&nbsp;&nbsp;
                    <br />
                    &nbsp;&nbsp;
                    <asp:TextBox id="cardnumber" name="cardnumber" runat="server" TextMode="Number" /><br />
                    <br />
                    &nbsp;&nbsp; Expiration Date:&nbsp;&nbsp;&nbsp;
                    <br />
                    &nbsp;&nbsp;
                    <input id="ExpirationDate" type="text" name="expirationdate"/><br />
                    <br />
                </div>
                <button id="creditbutton" type="button">Select</button>
            <h3>Gift Card:</h3>
                <div id="gift">
                    &nbsp;&nbsp;&nbsp; Enter Code:&nbsp;&nbsp;&nbsp;
                    <br />
                    &nbsp;&nbsp;
                    <input id="CardCode" type="text" name="cardcode"/><br />
                    <br />
                </div>
                <button id="giftbutton" type="button">Select</button>
            <h3>PayPal:</h3>
                <div id="paypal">
                     
                </div>
                <button id="paypalbutton" type="button">Select</button>
        </div>

        <div id="cartinfo" style="margin-left: 20px; padding-left: 10px; padding-right: 10px; float: left">
            &nbsp;&nbsp;&nbsp;<h1>Cart:</h1>
        <table style="width:100%;">
        <tr>
            <td>
                <asp:DataList ID="dlProductDetail" runat="server">
                    <ItemTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("NAME") %>'></asp:Label>
                                </td>
                                <td class="text-right">
                                    $<asp:Label ID="Price" runat="server" Text='<%# Eval("PRICE") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
            &nbsp;&nbsp;&nbsp;<h1>Total:</h1>
        </div>
    </div>
    </form>
    </asp:Content>