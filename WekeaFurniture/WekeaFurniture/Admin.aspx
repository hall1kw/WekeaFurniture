﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" MasterPageFile="~/Home.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
    <br /><br />
    <div class="row">
            <div class=" offset-1 col-sm-4 table-responsive">
                <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="GridView1_PagingIndexChanging" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID"  EmptyDataText="There are no data records to display." CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="SelectEvent">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
                        <asp:BoundField DataField="PRICE" HeaderText="PRICE" SortExpression="PRICE" />
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
            <div class="col-sm-5">
                <asp:DetailsView ID="DetailsView1" runat="server" OnItemDeleting="DetailsView1_ItemDeleting" OnItemInserted="DetailsView1_ItemInserted"
                    OnItemUpdating="DetailsView1_ItemUpdating" OnModeChanging="DetailsView1_ModeChanging" OnItemInserting="DetailsView1_ItemInserting"
                    DataKeyNames="ID" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" AutoGenerateInsertButton="true" 
                    AutoGenerateRows="false" Height="60px" Width="600px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
                    BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" RowStyle-Width="200px">
                    <Fields>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:Label ID="lblId" runat="server" ></asp:Label>
                            </InsertItemTemplate>
                        </asp:TemplateField>
                    
                        <asp:TemplateField HeaderText= "NAME">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("NAME") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("NAME") %>' CssClass="form-control" MaxLength="50"></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Text="Temporary" MaxLength="50" AutoPostBack="False"></asp:TextBox>
                            </InsertItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="PRICE">
                            <ItemTemplate>
                                <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("PRICE") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("PRICE") %>' CssClass="form-control" MaxLength="25"></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtPrice" runat="server" TextMode="Number" CssClass="form-control" MaxLength="8"></asp:TextBox>
                            </InsertItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="IMAGE">
                            <ItemTemplate>
                                <asp:Label ID="lblImage" runat="server" Text='<%# Bind("IMAGE") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <div class="row">
                                    <div class="col-xs-4 offset-1">                                    
                                        <asp:Label ID="lblImage" runat="server" Text='<%# Bind("IMAGE") %>'></asp:Label>
                                        <asp:FileUpload ID="fuImage" runat="server" Visible="false" />
                                    </div>
                                    <div class="col-xs-2 offset-1">
                                        <asp:Button ID="Button1" runat="server" Text="New Image" OnClick="Button1_Click" CssClass="form-control" />
                                    </div>
                                </div>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:FileUpload ID="fuImage" runat="server" ></asp:FileUpload>
                            </InsertItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="DESCRIPTION">
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("DESCRIPTION") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5" Text='<%# Bind("DESCRIPTION") %>' CssClass="form-control" MaxLength="25"></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                            </InsertItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ID CATEGORY">
                            <ItemTemplate>
                                <asp:Label ID="lblCat" runat="server" Text='<%# Bind("IDCAT") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlCat" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Chair (1)" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Couch (2)" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Table (3)" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Dresser (4)" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Bed (5)" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="Lamp (6)" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="Desk (7)" Value="7"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:DropDownList ID="ddlCat" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Chair (1)" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Couch (2)" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Table (3)" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Dresser (4)" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Bed (5)" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="Lamp (6)" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="Desk (7)" Value="7"></asp:ListItem>
                                </asp:DropDownList>
                            </InsertItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ID ROOM">
                            <ItemTemplate>
                                <asp:Label ID="lblRoom" runat="server" Text='<%# Bind("IDROOM") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlRoom" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Kitchen (1)" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Living Room (2)" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Bedroom (3)" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:DropDownList ID="ddlRoom" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Kitchen (1)" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Living Room (2)" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Bedroom (3)" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </InsertItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="FEATURED">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbFeatured" runat="server" Checked='<%# Eval("FEATURED") == DBNull.Value ? false : Eval("FEATURED") %>' onclick="return false;" ></asp:CheckBox>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="cbFeaturedEdit" runat="server" Checked='<%# Eval("FEATURED") == DBNull.Value ? false : Eval("FEATURED") %>' ></asp:CheckBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:CheckBox ID="cbFeaturedEdit" runat="server" ></asp:CheckBox>
                            </InsertItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="TAXABLE">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbTaxable" runat="server" Checked='<%# Eval("TAXABLE") == DBNull.Value ? false : Eval("TAXABLE") %>' onclick="return false;" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="cbTaxableEdit" runat="server" Checked='<%# Eval("TAXABLE") == DBNull.Value ? false : Eval("TAXABLE") %>' ></asp:CheckBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:CheckBox ID="cbTaxableEdit" runat="server" ></asp:CheckBox>
                            </InsertItemTemplate>
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
            <div class="col-sm-3">
                <asp:Image ID="ProductImage" runat="server" ImageUrl='<%#Eval("IMAGE")%>' />
            </div>
        </div>
</asp:Content>