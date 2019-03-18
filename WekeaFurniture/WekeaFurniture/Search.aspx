<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

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
    
    <style type="text/css">
        .auto-style4 {
            width: 60%;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<table style="margin-left:20px; margin-right:-20px;">
    <tr>
        <td class="auto-style4" style="border: 1px solid;">Featured Products - Needs to be databound</td>
        <td style="width:40%;" class="text-right">
            <h2 class="text-center">Search</h2>
            <br />
            <div class="text-left">
            <asp:Table ID="Table1" runat="server" Height="216px" Width="346px">
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
            </div>
            <br />
            <input id="Reset1" type="reset" value="Reset" />&nbsp; <input id="Button1" type="button" value="Search" /></td>
    </tr>
</table>
</asp:Content>






