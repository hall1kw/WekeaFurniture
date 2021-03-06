﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" CodeFile="~/AdminOrders.aspx.cs" Inherits="AdminOrders"%>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br />
    <div class="row">
        <div class="offset-1 col-sm-2">
            <asp:Button ID="ProductButton" runat="server" CssClass="form-control" OnClick="ProductButton_Click" Text="Products" />
        </div>
        <div class="col-sm-2">
            <asp:Button ID="CustomerButton" runat="server" CssClass="form-control" OnClick="CustomerButton_Click" Text="Users"/>
        </div>
        <div class="col-sm-2">
            <asp:Button ID="OrderButton" runat="server" CssClass="form-control" Text="Orders" OnClick="OrderButton_Click"/>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="offset-1 col-sm-5 table-responsive">
            <h2>Orders</h2>
            <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="GridView1_PagingIndexChanging" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID"  EmptyDataText="There are no data records to display." 
                    CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="SelectEvent" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" />
                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" SortExpression="ID" />
                        <asp:BoundField DataField="UID" HeaderText="UID" ReadOnly="true" SortExpression="UID" />
                        <asp:BoundField DataField="PYMT_INFO" HeaderText="Payment Info" ReadOnly="true" SortExpression="PYMT_INFO" />
                        <asp:BoundField DataField="ORDER_DATE" HeaderText="Order Date" ReadOnly="true" SortExpression="ORDER_DATE" />
                        <asp:BoundField DataField="AMMT" HeaderText="Amount" ReadOnly="true" SortExpression="AMMT" />
                        <asp:BoundField DataField="SHIP_INFO" HeaderText="Shipping Info" ReadOnly="true" SortExpression="SHIP_INFO" />
                        <asp:BoundField DataField="FULLFILLED" HeaderText="Fulfilled" ReadOnly="true" SortExpression="FULLFILLED" />
                    </Columns>
                    <FooterStyle BackColor="#FFC107" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#74253D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFC107" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFC107" Font-Bold="True" ForeColor="Navy" Font-Overline="False" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </div>
        <div class="col-sm-6">
            <asp:DetailsView ID="DetailsView1" runat="server"
                    DataKeyNames="ID" AutoGenerateEditButton="true" AutoGenerateRows="false" Height="60px" Width="500px" OnItemUpdating="DetailsView1_OnItemUpdating"
                    OnModeChanging="DetailsView1_ModeChanging" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" RowStyle-Width="200px">
                    <Fields>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                            </InsertItemTemplate>
                        </asp:TemplateField>
                    
                        <asp:TemplateField HeaderText= "Name">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# getName() %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# getName() %>'></asp:Label>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Product (ID)">
                            <ItemTemplate>
                                <asp:Label ID="lblProducts" runat="server" Text='<%# getProducts() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="lblQuantity" runat="server" Text='<%# getQuantity() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Payment Info">
                            <ItemTemplate>
                                <asp:Label ID="lblPaymentInfo" runat="server" Text='<%# Hide_Card() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Order Date">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderDate" runat="server" Text='<%# Bind("ORDER_DATE") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblOrderDate" runat="server" Text='<%# Bind("ORDER_DATE") %>'></asp:Label>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Shipping Info">
                            <ItemTemplate>
                                <asp:Label ID="lblShippingInfo" runat="server" Text='<%# getShippingInfo() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fullfilled">
                            <ItemTemplate>
                                <asp:Label ID="lblFullfilled" runat="server" Text='<%# Bind("FULLFILLED") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlFullfilled" runat="server">
                                    <asp:ListItem Text="False" Value="False"></asp:ListItem>
                                    <asp:ListItem Text="True" Value="True"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>

                    </Fields>
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="Maroon" Font-Bold="True" ForeColor="White" />
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                </asp:DetailsView>
        </div>
    </div>
    <br />
</asp:Content>

