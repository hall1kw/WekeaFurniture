<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>
<%--
<script runat="server">

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchResults.aspx?Name=" + tbSearch.Text);
    }
</script>
--%>

<html>
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/site.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <style>        
        body {
            background-color: #FFF;
        }
        .newStyle1 {
            font-family: Arial;
        }
        .auto-style1 {
            width: 86px;
            height: 46px;
        }
        .auto-style2 {
            color: #FFFF00;
        }
        .auto-style4 {
            text-align: center;
            background-color: #74253D;
            color: #FFC107;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server"><%-- 
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <img alt="WeKea logo" class="auto-style1" src="Images/logoSmall.png" />
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="/Home.aspx">Home <span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="#">Link One</a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="/Search.aspx">Shop our store</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link active" href="#">Link Two</a>
                </li>
        </ul>
    <form class="form-inline my-2 my-lg-0">
        <asp:TextBox ID="tbSearch" CssClass="form-control mr-sm-2" runat="server" placeholder="Search our catalog" aria-label="Search" style="width: 28%"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-warning my-2 my-sm-0" OnClick="btnSearch_Click"/>
    &nbsp;
    </form>
      <form action="Login.aspx">
          <button class="btn btn-warning my-2 my-sm-0" type="submit">Login</button>
      </form>
      
  </div>
</nav>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/gradient.png" Width="100%" Height="20px" style="margin-top:-9px; margin-bottom:-9px" />


        <br />
    <table style="width:100%;">
        <tr class="auto-style2">
            <td style="width:33%;" class="auto-style4"><a href="SearchResults.aspx?Rm=Kitchen" style="color:#ffc82e;">Kitchen</a></td>
            <td style="width:33%;" class="auto-style4"><a href="SearchResults.aspx?Rm=LivingRoom" style="color:#ffc82e;">Living Room</a></td>
            <td style="width:33%;" class="auto-style4"><a href="SearchResults.aspx?Rm=Bedroom" style="color:#ffc82e;">Bedroom</a></td>
            <td style="width:45px;" class="auto-style4">
                <a href="Cart.aspx"><img alt="Shopping Cart" src="Images/cartIcon.png" /> </a></td>
        </tr>
    </table> --%>
        <div class="row">
            <div class="col-sm-6 table-responsive">
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
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("IMAGE") %>'></asp:Label>
                                        <asp:FileUpload ID="fuImage" runat="server" Visible="false" />
                                    </div>
                                    <div class="col-xs-2 offset-1">
                                        <asp:Button ID="Button1" runat="server" Text="New Image" OnClick="Button1_Click" CssClass="form-control" />
                                    </div>
                                </div>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:FileUpload runat="server" ></asp:FileUpload>
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
                                <asp:Label ID="lblFeatured" runat="server" Text='<%# Bind("FEATURED") %>' ></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFeatured" runat="server" TextMode="Number" Text='<%# Bind("FEATURED") %>' CssClass="form-control"></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtFeatured" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
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
        </div>
    </form>
    <table style="width:100%;">
        <tr>
            <td class="auto-style4">Wekea Furniture<br />
                Developed by Code for Cache</td>
        </tr>
    </table>
</body>
</html>

        



<%--             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProductsConnection %>" 
    DeleteCommand="DELETE FROM [Products] WHERE [ID] = @ID" 
    InsertCommand="INSERT INTO [Products] ([NAME], [IMAGE], [PRICE], [DESCRIPTION], [IDCAT], [IDROOM], [FEATURED], [TAXABLE]) VALUES (@NAME, @IMAGE, @PRICE, @DESCRIPTION, @IDCAT, @IDROOM, @FEATURED, @TAXABLE)" 
    ProviderName="<%$ ConnectionStrings:ProductsConnection.ProviderName %>" 
    SelectCommand="SELECT [ID], [NAME], [IMAGE], [PRICE], [DESCRIPTION], [IDCAT], [IDROOM], [FEATURED], [TAXABLE] FROM [Products]" 
    UpdateCommand="UPDATE [Products] SET [NAME] = @NAME, [IMAGE] = @IMAGE, [PRICE] = @PRICE, [DESCRIPTION] = @DESCRIPTION, [IDCAT] = @IDCAT, [IDROOM] = @IDROOM, [FEATURED] = @FEATURED, [TAXABLE] = @TAXABLE WHERE [ID] = @ID"> --%>