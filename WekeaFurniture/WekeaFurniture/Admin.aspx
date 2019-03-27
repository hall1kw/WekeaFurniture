<%@ Page Title="Admin.aspx" Language="C#" MasterPageFile="~/Home.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
                <div class="col-xs-12">
                    <asp:GridView ID="grdProducts" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="ObjectDataSource1" 
                        CssClass="table table-bordered table-condensed" 
                        OnRowUpdated="grdProducts_RowUpdated">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID"
                                ReadOnly="True">
                                <HeaderStyle CssClass="col-sm-2" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NAME" HeaderText="Name" SortExpression="NAME" 
                                ReadOnly="True">
                                <HeaderStyle CssClass="col-sm-6" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Price" SortExpression="PRICE">
                                <EditItemTemplate>
                                    <div class="col-xs-11 col-edit">
                                        <asp:TextBox runat="server" Text='<%# Bind("PRICE") %>' ID="txtPrice" 
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice" 
                                        Text="*" ErrorMessage="Price is a required field." 
                                        Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cvOnPrice" runat="server" ControlToValidate="txtPrice"  
                                        Text="*" ErrorMessage="On Hand must be a non-negative decimal number." 
                                        Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" 
                                        Display="Dynamic" CssClass="text-danger"></asp:CompareValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Bind("PRICE") %>' ID="lblPrice"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="col-sm-2 text-right"></HeaderStyle>
                                <ItemStyle CssClass="text-right"></ItemStyle>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" />
                        </Columns>
                        <HeaderStyle CssClass="bg-halloween" />
                        <AlternatingRowStyle CssClass="altRow" />
                        <EditRowStyle CssClass="warning" />
                        <PagerStyle CssClass="bg-halloween" HorizontalAlign="Center" />
                    </asp:GridView>  
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
                        DataObjectTypeName="Product" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetProducts" TypeName="ProductDB" UpdateMethod="UpdateProduct">
                    </asp:ObjectDataSource>
                </div>  
            </div>
</asp:Content>

<%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProductsConnection %>" DeleteCommand="DELETE FROM [Products] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Products] ([NAME], [IMAGE], [PRICE], [DESCRIPTION], [IDCAT], [IDROOM], [FEATURED], [TAXABLE]) VALUES (@NAME, @IMAGE, @PRICE, @DESCRIPTION, @IDCAT, @IDROOM, @FEATURED, @TAXABLE)" ProviderName="<%$ ConnectionStrings:ProductsConnection.ProviderName %>" SelectCommand="SELECT [ID], [NAME], [IMAGE], [PRICE], [DESCRIPTION], [IDCAT], [IDROOM], [FEATURED], [TAXABLE] FROM [Products]" UpdateCommand="UPDATE [Products] SET [NAME] = @NAME, [IMAGE] = @IMAGE, [PRICE] = @PRICE, [DESCRIPTION] = @DESCRIPTION, [IDCAT] = @IDCAT, [IDROOM] = @IDROOM, [FEATURED] = @FEATURED, [TAXABLE] = @TAXABLE WHERE [ID] = @ID"> --%>