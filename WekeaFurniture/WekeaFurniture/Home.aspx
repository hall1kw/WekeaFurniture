<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function ()
        {
            $('#tbSearch').click(function ()
            {
                var search = $('#tbName').val();

                $.ajax({
                    url: 'Home.aspx/GetAllProduct',
                    method: 'post',
                    contentType: 'application/json',
                    data: '{productName: ' + search + '}',
                    dataType: 'json',
                    success: function (data)
                    {
                        $('#txtId').val(data.d.id);
                        $('#txtName').val(data.d.name);
                        $('#txtQuantity').val(data.d.quantity);
                        $('#txtPrice').val(data.d.price);
                        $('#txtDesc').val(data.d.description);
                        $('#txtImage').val(data.d.imageurl);
                    },
                    error: function (error)
                    {
                        alert(error);
                    }
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="jumbotron">
        <h1>WeKeA</h1>
    </div>
    <asp:Table ID="Table1" runat="server" Height="216px" Width="285px">
        <asp:TableRow>
            <asp:TableCell>ID: </asp:TableCell>
            <asp:TableCell><input id="txtId" type="text" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Name: </asp:TableCell>
            <asp:TableCell><input id="txtName" type="text" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Quantity: </asp:TableCell>
            <asp:TableCell><input id="txtQuantity" type="text" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Price: </asp:TableCell>
            <asp:TableCell><input id="txtPrice" type="text" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Desc: </asp:TableCell>
            <asp:TableCell><input id="txtDesc" type="text" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Image: </asp:TableCell>
            <asp:TableCell><input id="txtImage" type="text" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

