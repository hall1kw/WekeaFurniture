<%@ Page Title="AdminUsers" Language="C#" CodeFile="~/AdminUsers.aspx.cs" MasterPageFile="~/Home.master" Inherits="AdminUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <br /><br />
    <div class="row">
        <div class="offset-1 col-sm-2">
            <asp:Button ID="ProductButton" runat="server" CssClass="form-control" OnClick="ProductButton_Click" Text="Products" />
        </div>
        <div class="col-sm-2">
            <asp:Button ID="CustomerButton" runat="server" CssClass="form-control" OnClick="CustomerButton_Click" Text="Users"/>
        </div>
        <div class="col-sm-2">
            <asp:Button ID="OrderButton" runat="server" CssClass="form-control" Text="Orders" OnClick="OrderButton_Click" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="offset-1 col-sm-5 table-responsive">
            <h2>Users</h2>
            <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="GridView1_PagingIndexChanging" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID"  EmptyDataText="There are no data records to display." 
                CellPadding="4" ForeColor="#333333" GridLines="None" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="SelectEvent" 
                OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_OnRowDeleting">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="true" />
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" SortExpression="ID" />
                    <asp:TemplateField HeaderText="First Name">
                        <ItemTemplate>
                            <asp:Label ID="lblFName" runat="server" Text='<%# Bind("FIRST_NAME")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblFName" runat="server" Text='<%# Bind("FIRST_NAME")%>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Name">
                        <ItemTemplate>
                            <asp:Label ID="lblLName" runat="server" Text='<%# Bind("LAST_NAME")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblLName" runat="server" Text='<%# Bind("LAST_NAME")%>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("EMAIL")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("EMAIL")%>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Permission">
                        <ItemTemplate>
                            <asp:Label ID="lblPermission" runat="server" Text='<%# Bind("PERMISSION") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlPermission" runat="server">
                                <asp:ListItem Text="0"></asp:ListItem>
                                <asp:ListItem Text="1"></asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" />
                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" CssClass="text-danger"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="Update" />
                            <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                    </asp:TemplateField>
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
        <div class="col-sm-6 table-responsive">

            <asp:Button ID="LinkButtonShipping" Text="Shipping Info" Visible="false" runat="server" OnClick="LinkButtonShipping_Click"></asp:Button>
            <asp:Button ID="LinkButtonPaymentInfo" Text="Payment Info" Visible="false" runat="server" OnClick="LinkButtonPaymentInfo_Click"></asp:Button>
            <asp:Button ID="LinkButtonReviews" Text="Reviews" Visible="false" runat="server" OnClick="LinkButtonReviews_Click"></asp:Button>
            <asp:Button ID="LinkButtonOrders" Text="Orders" Visible="false" runat="server" OnClick="LinkButtonOrders_Click"></asp:Button>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <asp:GridView ID="GridViewShipping" runat="server" OnPageIndexChanging="GridViewShipping_PagingIndexChanging" AllowPaging="true"
                        AllowSorting="true" AutoGenerateColumns="false" DataKeyNames="ID" EmptyDataText="Shipping Info Not Available"
                        CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="GridViewShipping_OnRowDeleting">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" SortExpression="ID" />
                            <asp:BoundField DataField="SHIP_TO_NAME" HeaderText="Name" ReadOnly="true" SortExpression="SHIP_TO_NAME" />
                            <asp:BoundField DataField="ADDRESS_ONE" HeaderText="Address 1" ReadOnly="true" SortExpression="ADDRESS_ONE" />
                            <asp:BoundField DataField="ADDRESS_TWO" HeaderText="Address 2" ReadOnly="true" SortExpression="ADDRESS_TWO" />
                            <asp:BoundField DataField="CITY" HeaderText="City" ReadOnly="true" SortExpression="CITY" />
                            <asp:BoundField DataField="STATE" HeaderText="State" ReadOnly="true" SortExpression="STATE" />
                            <asp:BoundField DataField="ZIP" HeaderText="Zipcode" ReadOnly="true" SortExpression="ZIP" />
                            <asp:CommandField ShowDeleteButton="true" />
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
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:GridView ID="GridViewPaymentInfo" runat="server" OnPageIndexChanging="GridViewPaymentInfo_PagingIndexChanging" AllowPaging="true"
                        AllowSorting="true" AutoGenerateColumns="false" DataKeyNames="ID" EmptyDataText="Payment Info Not Available"
                        CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="GridViewPaymentInfo_OnRowDeleting" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Payment ID" ReadOnly="true" SortExpression="ID" />
                            <asp:BoundField DataField="NAME_ON_CARD" HeaderText="Name On Card" ReadOnly="true" SortExpression="NAME_ON_CARD" />
                            <asp:TemplateField HeaderText="Card #">
                                <ItemTemplate>
                                    <asp:Label ID="lblCard" runat="server" Text='<%# Hide_Card(Eval("CARD_NUM").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EXP_MO" HeaderText="Exp. Month" ReadOnly="true" SortExpression="EXP_MO" />
                            <asp:BoundField DataField="EXP_YR" HeaderText="Exp. Year" ReadOnly="true" SortExpression="EXP_YR" />
                            <asp:CommandField ShowDeleteButton="true" />
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
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <asp:GridView ID="GridViewReviews" runat="server" OnPageIndexChanging="GridViewReviews_PagingIndexChanging" AllowPaging="true"
                        AllowSorting="true" AutoGenerateColumns="false" DataKeyNames="ID" EmptyDataText="Reviews Not Available"
                        CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="GridViewReviews_OnRowDeleting" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Review ID" ReadOnly="true" SortExpression="ID" />
                            <asp:BoundField DataField="PID" HeaderText="Product ID" ReadOnly="true" SortExpression="PID" />
                            <asp:BoundField DataField="RATING" HeaderText="Rating" ReadOnly="true" SortExpression="RATING" />
                            <asp:BoundField DataField="REVIEW" HeaderText="Review" ReadOnly="true" SortExpression="REVIEW" />
                            <asp:CommandField ShowDeleteButton="true" />
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
                </asp:View>
                <asp:View ID="View4" runat="server">
                    <asp:GridView ID="GridViewOrders" runat="server" OnPageIndexChanging="GridViewOrders_PagingIndexChanging" AllowPaging="true"
                        AllowSorting="true" AutoGenerateColumns="false" DataKeyNames="ID" EmptyDataText="Orders Not Available"
                        CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="GridViewOrders_OnRowDeleting" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Order ID" ReadOnly="true" SortExpression="ID" />
                            <asp:BoundField DataField="PYMT_INFO" HeaderText="Payment Info" ReadOnly="true" SortExpression="PYMT_INFO" />
                            <asp:BoundField DataField="AMMT" HeaderText="Amount" ReadOnly="true" SortExpression="AMMT" />
                            <asp:BoundField DataField="SHIP_INFO" HeaderText="Shipping Info" ReadOnly="true" SortExpression="SHIP_INFO" />
                            <asp:BoundField DataField="FULLFILLED" HeaderText="Fullfilled" ReadOnly="true" SortExpression="FULLFILLED" />
                            <asp:CommandField ShowDeleteButton="true" />
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
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
    <br />
</asp:Content>

