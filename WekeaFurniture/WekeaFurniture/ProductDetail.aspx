<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .Background
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .Popup
        {
            background-color: #782b42;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 400px;
            height: 150px;            
        }
        .lbl
        {
            font-size:16px;
            font-style:italic;
            font-weight:bold;
        }
        .auto-style5 {
            width: 25%;
        }
        .auto-style6 {
            width: 50%;
        }
        .auto-style7 {
            text-align: center;
        }
        .auto-style8 {
            text-align: right;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table ID="table1" style="width:100%;">
        <tr>
            <td class="auto-style5" style="width:250px; border-right-style:solid; border-right-width:3px; border-right-color:#782b42; background-color: #FFFFFF; color: #800000;">
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
                            <td style="width:250px; border-bottom-style:solid; border-bottom-width:3px; border-bottom-color:#782b42" class="text-right"><asp:Label ID="Label2" runat="server" Text='<%# String.Format("{0:C}",Eval("PRICE")) %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            </td>
            <td class="auto-style6" style="vertical-align:top;">
                <asp:DataList ID="dlProductDetail" runat="server" BackColor="White" ForeColor="Black">
                    <ItemTemplate>
                        <table style="width:100%;">
                            <tr style="vertical-align:top;">
                                <td colspan="2">
                                    <h2>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("NAME") %>' ForeColor="#74253D"></asp:Label>
                                    </h2>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"  style="height:400px;" class="text-center">
                                    <asp:Image ID="Image2" runat="server" style="max-width:500px; max-height:400px;" ImageUrl='<%# "Images/ProductImages/" + Eval("IMAGE") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td  colspan="2">
                                    <asp:Label ID="Label3"  runat="server" Text='<%# Eval("DESCRIPTION") %>' style="margin-left:-2px; margin-right:-3px; margin-bottom:-1px;" Width="502px" BackColor="#74253D" BorderColor="#74253D" BorderStyle="Solid" BorderWidth="1px" ForeColor="#FFCC00"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style8" colspan="2"><asp:Label ID="Label2" style="margin-left:-2px; margin-right:-3px; margin-bottom:-1px; margin-top:-1px;" Width="502px" BackColor="#74253D" BorderColor="#74253D" BorderStyle="Solid" BorderWidth="1px" ForeColor="#FFCC00" runat="server" Text='<%# String.Format("{0:C}",Eval("PRICE")) %>'></asp:Label>
                                </td>
                            </tr>
                            <tr style="width:502px; margin-left:-1px;">
                                <td class="text-left" style="background-color: #74253D; color: #FFCC00">
                                    Currently in stock:
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("INVENTORY") %>'></asp:Label>
                                </td>
                                <td class="text-right" style="background-color: #74253D; color: #FFCC00">
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add To Cart" UseSubmitBehavior="False" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProductsConnection %>" SelectCommand="SELECT [RATING], [REVIEW] FROM [Reviews] WHERE ([PID] = @PID)">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="PID" QueryStringField="ID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="RATING" HeaderText="RATING" SortExpression="RATING" />
                        <asp:BoundField DataField="REVIEW" HeaderText="REVIEW" SortExpression="REVIEW" />
                    </Columns>
                </asp:GridView>
                <label style="font-size:18pt">Leave a review</label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>1 star</asp:ListItem>
                    <asp:ListItem>2 stars</asp:ListItem>
                    <asp:ListItem>3 stars</asp:ListItem>
                    <asp:ListItem>4 stars</asp:ListItem>
                    <asp:ListItem>5 stars</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:TextBox ID="TextBox1" runat="server" Height="75px" Width="329px" MaxLength="1024" Rows="500"></asp:TextBox>
                <br />
                <asp:Button ID="Button2" runat="server" Text="Submit Review" OnClick="Button2_Click" />
            </td>
        </tr>
    </table>
    
    <asp:LinkButton ID="dummyBtn" runat="server"></asp:LinkButton>
    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="ProdAdded" TargetControlID="dummyBtn" BackgroundCssClass="Background">
                                        </cc1:ModalPopupExtender>
    <asp:Panel ID="ProdAdded" runat="server" CssClass="Popup" align="center" style = "display:none">
        <div>
            <table style="width:100%;">
            <tr>
                <td>&nbsp;</td>
                <td><asp:Label ID="lblThankYou" runat="server" ForeColor="#FFCC00"></asp:Label></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width:300px">
                    
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7">
                    <asp:Button ID="btnCancelControl" OnClick="btnCancelControl_Click" runat="server" Text="OK, Cool!" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        </div>
    </asp:Panel>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1" TargetControlID="dummyBtn" BackgroundCssClass="Background">
                                        </cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="Popup" align="center" style = "display:none">
        <div>
            <table style="width:100%;">
            <tr>
                <td>&nbsp;</td>
                <td><asp:Label ID="lblOutOfStock" runat="server" ForeColor="#FFCC00"></asp:Label></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width:300px">
                    
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7">
                    <asp:Button ID="Button3" OnClick="btnCancelControl_Click" runat="server" Text="OK" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        </div>
    </asp:Panel>
</asp:Content>

