<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Password_Reset.aspx.cs" Inherits="Password_Reset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 29px;
        }
        .auto-style2 {
            width: 277px;
        }
        .auto-style3 {
            height: 29px;
            width: 277px;
        }
        .auto-style4 {
            width: 277px;
            height: 26px;
        }
        .auto-style5 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

&nbsp;&nbsp;&nbsp;
            <br />
            <br />
&nbsp;&nbsp;&nbsp;
            
        </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">

            <asp:Label ID="Label1" runat="server" Text="New Password"></asp:Label>
                </td>
                <td>
            <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
            <asp:Label ID="Label2" runat="server" Text="Reenter New Password"></asp:Label>
                </td>
                <td class="auto-style1">
            <asp:TextBox ID="txtPass2" runat="server"></asp:TextBox>

                </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style5">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Reset Password" />
                </td>
                <td class="auto-style5"></td>
            </tr>
        </table>
    </form>
</body>
</html>
