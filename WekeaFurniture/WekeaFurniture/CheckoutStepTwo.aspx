<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="CheckoutStepTwo.aspx.cs" Inherits="CheckoutStepTwo" Async="true"%>

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
            width: 16px;
        }
        .auto-style11 {
            margin-left: 40px;
            width: 16px;
        }
        .auto-style12 {
            height: 26px;
            text-align: right;
            width: 13px;
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
        .auto-style20 {
            margin-left: 40px;
            width: 16px;
            height: 26px;
        }
        .auto-style25 {
            width: 214px;
            height: 26px;
        }
        .auto-style26 {
            width: 214px;
        }
        .auto-style27 {
            width: 22px;
        }
        .auto-style28 {
            width: 22px;
            height: 26px;
        }
        .auto-style29 {
            width: 86px;
            text-decoration: underline;
        }
        .auto-style31 {
            text-align: right;
            width: 16px;
        }
        .auto-style32 {
            width: 16px;
        }
        .auto-style33 {
            width: 13px;
        }
        .auto-style34 {
            text-align: right;
            width: 13px;
        }
        .auto-style35 {
            height: 26px;
        }
        .auto-style38 {
            width: 151px;
            text-align: right;
            height: 29px;
        }
        .auto-style39 {
            width: 208px;
            height: 26px;
        }
        .auto-style40 {
            width: 208px;
        }
        .auto-style41 {
            width: 208px;
            height: 29px;
            text-align: left;
        }
        .auto-style42 {
            height: 29px;
            text-align: left;
        }
        .auto-style43 {
            width: 151px;
            text-align: right;
        }
        .auto-style45 {
            width: 208px;
            text-align: left;
        }
        .auto-style46 {
            width: 208px;
            text-align: left;
            margin-left: 40px;
        }
        .auto-style47 {
            width: 151px;
            height: 26px;
        }
        .auto-style48 {
            width: 151px;
        }
        .auto-style49 {
            width: 21px;
            height: 26px;
        }
        .auto-style50 {
            width: 21px;
            height: 29px;
        }
        .auto-style51 {
            width: 21px;
        }
        .auto-style52 {
            height: 26px;
            width: 216px;
        }
        .auto-style53 {
            height: 29px;
            width: 216px;
            text-align: right;
        }
        .auto-style54 {
            width: 216px;
        }
        .auto-style55 {
            width: 216px;
            text-align: right;
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
                            <h2>Checkout: Step 2</h2>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            &nbsp;</td>
                        <td>
                            <h4>Payment Information</h4>
                        </td>
                    </tr>
                    <tr style="vertical-align:top;">
                        <td style="vertical-align:top;" colspan="3">
                            <table style="width:100%; vertical-align:top;" runat="server">
                                <tr style="vertical-align:top;">
                                    <td class="auto-style29" style="border-color: #782b42; border-style: solid solid none none; border-width: 3px 2px 0px 0px;" colspan="2">Ship To:</td>
                                    <td class="auto-style33" style="border-color: #782b42; border-style: solid none none none; border-width: 3px;">&nbsp;</td>
                                    <td style="border-color: #782b42; border-style: solid none none none; border-width: 3px;" class="auto-style32">&nbsp;</td>
                                    <td style="border-color: #782b42; border-style: solid none none none; border-width: 3px;" class="text-center" rowspan="13">
                                        <table class="w-100">
                                            <tr>
                                                <td class="auto-style47"></td>
                                                <td class="auto-style39"></td>
                                                <td class="auto-style49"></td>
                                                <td class="auto-style52"></td>
                                                <td class="auto-style35"></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style38">Payment Method:</td>
                                                <td class="auto-style41">
                                                    <asp:DropDownList ID="ddlPaymentMethod" runat="server" OnSelectedIndexChanged="ChoosePaymentAction" AppendDataBoundItems="true" AutoPostBack="True">
                                                        <asp:ListItem Selected="True" disabled="disabled">--- Select Payment Type ---</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="auto-style50"></td>
                                                <td class="auto-style53">
                                                    <asp:Label ID="lblBillingInfo" runat="server" Text="Billing Information: "></asp:Label>
                                                </td>
                                                <td class="auto-style42">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style48">&nbsp;</td>
                                                <td class="auto-style40">
                                                    &nbsp;</td>
                                                <td class="auto-style51">&nbsp;</td>
                                                <td class="auto-style54">&nbsp;</td>
                                                <td class="text-left">
                                                    <asp:CheckBox ID="cbSameAsBilling" runat="server" OnCheckedChanged="SameAsBilling"  AutoPostBack="True" Text=" Same as shipping" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style43">
                                                    <asp:Label ID="lblCardName" runat="server" Text="Label" ViewStateMode="Enabled"></asp:Label>
                                                </td>
                                                <td class="auto-style45">
                                                    <asp:TextBox ID="txtCardName" runat="server"></asp:TextBox>
                                                </td>
                                                <td class="auto-style51">&nbsp;</td>
                                                <td class="auto-style55">
                                                    <asp:Label ID="lblBillingName" runat="server" Text="Name:"></asp:Label>
                                                </td>
                                                <td class="text-left">
                                                    <asp:TextBox ID="txtBillName" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style43">
                                                    <asp:Label ID="lblCardNum" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td class="auto-style46">
                                                    <asp:TextBox ID="txtCardNum" runat="server"></asp:TextBox>
                                                </td>
                                                <td class="auto-style51">&nbsp;</td>
                                                <td class="auto-style55">
                                                    <asp:Label ID="lblStAddOne" runat="server" Text="Street Address Line 1:"></asp:Label>
                                                </td>
                                                <td class="text-left">
                                                    <asp:TextBox ID="txtBillAddOne" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style43">
                                                    <asp:Label ID="lblExpDat" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td class="auto-style46">
                                                    <asp:TextBox ID="txtExpMo" runat="server" Width="26px"></asp:TextBox>
                                                    <asp:Label ID="lblSlash" runat="server" Font-Size="Large" Text="&nbsp;/ "></asp:Label>
                                                    <asp:TextBox ID="txtExpYr" runat="server" Width="26px"></asp:TextBox>
                                                    <asp:Image ID="imgPaypal" runat="server" ImageUrl="~/Images/icon-256x256.png" />
                                                </td>
                                                <td class="auto-style51">&nbsp;</td>
                                                <td class="auto-style55">
                                                    <asp:Label ID="lblStAddTwo" runat="server" Text="Street Address Line 2:"></asp:Label>
                                                </td>
                                                <td class="text-left">
                                                    <asp:TextBox ID="txtBillAddTwo" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style43">&nbsp;</td>
                                                <td class="auto-style46">&nbsp;</td>
                                                <td class="auto-style51">&nbsp;</td>
                                                <td class="auto-style55">
                                                    <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>
                                                </td>
                                                <td class="text-left">
                                                    <asp:TextBox ID="txtBillCity" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style43">
                                                    <asp:Label ID="lblCardCVV" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td class="auto-style46">
                                                    <asp:TextBox ID="txtCVV" runat="server" Width="57px"></asp:TextBox>
                                                </td>
                                                <td class="auto-style51">&nbsp;</td>
                                                <td class="auto-style55">
                                                    <asp:Label ID="lblState" runat="server" Text="State:"></asp:Label>
                                                </td>
                                                <td class="text-left">
                                                    <asp:DropDownList ID="ddlBillState" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style43">&nbsp;</td>
                                                <td class="auto-style46">&nbsp;</td>
                                                <td class="auto-style51">&nbsp;</td>
                                                <td class="auto-style55">
                                                    <asp:Label ID="lblZip" runat="server" Text="Zip:"></asp:Label>
                                                </td>
                                                <td class="text-left">
                                                    <asp:TextBox ID="txtBillZip" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style43">&nbsp;</td>
                                                <td class="auto-style46">&nbsp;</td>
                                                <td class="auto-style51">&nbsp;</td>
                                                <td class="auto-style54">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style27">&nbsp;</td>
                                    <td class="auto-style26" style="border-right-style: solid; border-right-width: 2px; border-right-color: #753649">
                                        <asp:Label ID="lblShipName" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td class="auto-style34">&nbsp;</td>
                                    <td class="auto-style32">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style27">&nbsp;</td>
                                    <td class="auto-style26" style="border-right-style: solid; border-right-width: 2px; border-right-color: #753649">
                                        <asp:Label ID="lblShipAddOne" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td class="auto-style34">&nbsp;</td>
                                    <td class="auto-style31">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style27">&nbsp;</td>
                                    <td class="auto-style26" style="border-right-style: solid; border-right-width: 2px; border-right-color: #753649">
                                        <asp:Label ID="lblShipAddTwo" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td class="auto-style34">&nbsp;</td>
                                    <td class="auto-style32">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style28"></td>
                                    <td class="auto-style25" style="border-right-style: solid; border-right-width: 2px; border-right-color: #753649">
                                        <asp:Label ID="lblShipCity" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td class="auto-style12">&nbsp;</td>
                                    <td class="auto-style10">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style27">&nbsp;</td>
                                    <td class="auto-style26" style="border-right-style: solid; border-right-width: 2px; border-right-color: #753649">
                                        <asp:Button ID="btnChange" runat="server" OnClick="btnChange_Click" Text="Change" />
                                    </td>
                                    <td class="auto-style34">&nbsp;</td>
                                    <td class="auto-style32">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style27">&nbsp;</td>
                                    <td class="auto-style26">&nbsp;</td>
                                    <td class="auto-style34">&nbsp;</td>
                                    <td class="auto-style11">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style27">&nbsp;</td>
                                    <td class="auto-style7">&nbsp;</td>
                                    <td class="auto-style34">&nbsp;</td>
                                    <td class="auto-style11">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style8" colspan="2"></td>
                                    <td class="auto-style12"></td>
                                    <td class="auto-style20">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style7" colspan="2">&nbsp;</td>
                                    <td class="auto-style34">&nbsp;</td>
                                    <td class="auto-style11">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style7" colspan="2">&nbsp;</td>
                                    <td class="auto-style34">&nbsp;</td>
                                    <td class="auto-style11">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style7" colspan="2">&nbsp;</td>
                                    <td class="auto-style34">&nbsp;</td>
                                    <td class="auto-style11">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style7" colspan="2">&nbsp;</td>
                                    <td class="auto-style34">&nbsp;</td>
                                    <td class="auto-style11">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    </asp:Content>

