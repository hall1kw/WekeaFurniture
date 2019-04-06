﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="CheckoutStepOne.aspx.cs" Inherits="CheckoutNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            width: 1123px;
        }
        .auto-style7 {
            width: 86px;
        }
        .auto-style8 {
            width: 86px;
            height: 26px;
        }
        .auto-style10 {
            height: 26px;
            margin-left: 80px;
            width: 301px;
        }
        .auto-style11 {
            margin-left: 40px;
            width: 301px;
        }
        .auto-style12 {
            height: 26px;
            text-align: right;
            width: 180px;
        }
        .auto-style14 {
            text-align: right;
            width: 180px;
        }
        .auto-style15 {
            width: 180px;
        }
        .auto-style16 {
            width: 301px;
        }
        .auto-style17 {
            width: 34px;
        }
        .auto-style18 {
            width: 107px;
        }
        .auto-style19 {
            font-size: xx-small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style5" style="width:250px; border-right-style:solid; border-right-width:3px; border-right-color:#782b42">
            <div class="text-center">
                <h3>Shopping Cart</h3>
                <h3>
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
                    <div class="text-right">
                                                        <asp:Label ID="lblSubtotal" runat="server" Text="Label" Font-Size="Large"></asp:Label>
                                                    <br />
                        <span class="auto-style19">&nbsp;</span><br />
                                                        <asp:Label ID="lblTax" runat="server" Text="Label" Font-Size="Large"></asp:Label>
                                                    <br />
                        <span class="auto-style19">&nbsp;</span><br />
                                                        <asp:Label ID="lblTotal" runat="server" Text="Label" Font-Size="Large"></asp:Label>
                    <br />
                    </div>
                </h3>
            </div>
            </td>
            <td style="vertical-align:top">    
                <table style="width: 100%; vertical-align:top">
                    <tr>
                        <td class="auto-style18" rowspan="2">
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/ShippingImage.png" />
                        </td>
                        <td colspan="2">
                            <h2>Checkout: Step 1</h2>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            &nbsp;</td>
                        <td>
                            <h4>Shipping Information</h4>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table style="width:100%;">
                                <tr>
                                    <td class="auto-style7" style="border-color: #782b42; border-style: solid none none none; border-width: 3px;">Ship To:</td>
                                    <td class="auto-style15" style="border-color: #782b42; border-style: solid none none none; border-width: 3px;">&nbsp;</td>
                                    <td style="border-color: #782b42; border-style: solid none none none; border-width: 3px;" class="auto-style16">&nbsp;</td>
                                    <td style="border-color: #782b42; border-style: solid none none none; border-width: 3px;" class="text-center" rowspan="13">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">&nbsp;</td>
                                    <td class="auto-style14">Full Name:</td>
                                    <td class="auto-style16">
                                        <asp:TextBox ID="txtFullName" runat="server" OnTextChanged="ShipNameChanged" AutoPostBack="true" Width="267px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">&nbsp;</td>
                                    <td class="auto-style14">&nbsp;</td>
                                    <td class="auto-style16">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">&nbsp;</td>
                                    <td class="auto-style14">Street Address - Line 1</td>
                                    <td class="auto-style16">
                                        <asp:TextBox ID="txtAddressLn1" runat="server" OnTextChanged="ShipAddLineOneChanged" AutoPostBack="true" Width="267px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style8"></td>
                                    <td class="auto-style12">Street Address - Line 2</td>
                                    <td class="auto-style10">
                                        <asp:TextBox ID="txtAddressLn2" runat="server" OnTextChanged="ShipAddLineTwoChanged" AutoPostBack="true" Width="267px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">&nbsp;</td>
                                    <td class="auto-style14">&nbsp;</td>
                                    <td class="auto-style16">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">&nbsp;</td>
                                    <td class="auto-style14">City</td>
                                    <td class="auto-style11">
                                        <asp:TextBox ID="txtCity" runat="server" OnTextChanged="ShipCityChanged" AutoPostBack="true" Width="267px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">&nbsp;</td>
                                    <td class="auto-style14">&nbsp;</td>
                                    <td class="auto-style11">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">&nbsp;</td>
                                    <td class="auto-style14">State</td>
                                    <td class="auto-style11">
                                        <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="CalcTax" AutoPostBack="True" AppendDataBoundItems="true" Width="188px">
                                            <asp:ListItem>--- Select state ---</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">&nbsp;</td>
                                    <td class="auto-style14">&nbsp;</td>
                                    <td class="auto-style11">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">&nbsp;</td>
                                    <td class="auto-style14">Zip</td>
                                    <td class="auto-style11">
                                        <asp:TextBox ID="txtZip" OnTextChanged="ShipZipChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">&nbsp;</td>
                                    <td class="auto-style14">&nbsp;</td>
                                    <td class="auto-style11">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">&nbsp;</td>
                                    <td class="auto-style14">&nbsp;</td>
                                    <td class="auto-style11">
                                        <asp:Button ID="btnReset" runat="server" OnClick="Button1_Click" Text="Reset" CommandName="Reset" />
                                        &nbsp;<asp:Button ID="btnContinue" runat="server" OnClick="Button2_Click" Text="Continue" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    </asp:Content>
