<%@ Page Title="" Language="C#"AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<!DOCTYPE html>
<script runat="server">

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchResults.aspx?Name=" + tbSearch.Text);
    }
</script>


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
        .auto-style5 {
            text-align: right;
            height: 74px;
        }
        .auto-style6 {
            width: 103px;
        }
        .auto-style7 {
            width: 752px;
        }
        .auto-style8 {
            width: 503px;
        }
        .auto-style10 {
            text-align: right;
            width: 909px;
        }
        .auto-style11 {
            text-align: right;
            height: 26px;
            margin-left: 40px;
        }
        .newStyle2 {
            font-family: Arial;
            font-size: x-small;
        }
        .newStyle3 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
    
        <asp:TextBox ID="tbSearch" CssClass="form-control mr-sm-2" runat="server" placeholder="Search our catalog" aria-label="Search" style="width: 28%"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-warning my-2 my-sm-0" OnClick="btnSearch_Click"/>
    &nbsp;
    
      
          <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-warning my-2 my-sm-0" Text="Login" PostBackUrl="~/Login.aspx"></asp:Button>
      
      
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
                <a href="Cart.aspx">
                    <asp:Label ID="lblCart" runat="server" style="color:#ffc82e;" Text=""></asp:Label>
                    <img alt="Shopping Cart" src="Images/cartIcon.png" />
                </a>
        </tr>
    </table>


        <div>
            <div class="text-center">
                <h4>Shopping Cart</h4>
                <br />
            </div>
            <asp:GridView ID="gvShoppingCart" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvShoppingCart_RowCancelingEdit" OnRowDeleting="gvShoppingCart_RowDeleting" OnRowEditing="gvShoppingCart_RowEditing" OnRowUpdating="gvShoppingCart_RowUpdating" ClientIDMode="AutoID" HorizontalAlign="Center">
        <Columns>
            <asp:TemplateField HeaderText="Item">
                <ItemTemplate>
                    <table class="auto-style7">
                        <tr>
                            <td colspan="2" style="margin-left:15px; border-bottom-style: outset; border-bottom-color:#74253D; border-bottom-width: 3px">
                                <h5>
                                    <asp:Label ID="Label2" style="margin-left:15px;" runat="server" Text='<%# Eval("NAME") %>'></asp:Label>
                                </h5>
                            </td>
                            <td class="text-right" style="border-bottom-style: outset; border-bottom-width: 3px; border-bottom-color:#74253D;">&nbsp;$<asp:Label style="margin-right:15px;" ID="Label4" runat="server" Text='<%# Eval("PRICE") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="3" style="margin-left:15px;" class="auto-style6">
                                <asp:Image style="margin-left:15px; width:100px; height:100px;" ID="Image2" runat="server" ImageUrl='<%# "/Images/ProductImages/" + Eval("IMAGE") %>' />
                            </td>
                            <td rowspan="3" class="auto-style8">
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("DESCRIPTION") %>'></asp:Label>
                            </td>
                            <td class="auto-style5">&nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style11">Total: $<asp:Label ID="Label5" runat="server" Text='<%# String.Format("{0:n}", Double.Parse(Eval("PRICE").ToString()) * Int32.Parse(Eval("QUANTITY").ToString())) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11">
                                <asp:Label ID="Label6" runat="server" CssClass="newStyle3" Text='<%# Eval("INVENTORY") %>'></asp:Label>
                                <span class="newStyle2">&nbsp;in stock</span></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" />
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
                <EditRowStyle HorizontalAlign="Center" VerticalAlign="Top" />
    </asp:GridView>
            <table style="width:800px;" align="center">
                <tr>
                    <td class="auto-style10">
    <asp:Label ID="lblGrandTotal" runat="server"  Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
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





