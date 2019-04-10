<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddressVerification.aspx.cs" Inherits="AddressVerification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="2" style="font-family: Arial, Helvetica, sans-serif">
                        <h3>Does this look right?</h3>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6" colspan="2" style="font-family: Arial, Helvetica, sans-serif">Original...</td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-family: Arial, Helvetica, sans-serif">&nbsp;</td>
                    <td style="font-family: Arial, Helvetica, sans-serif">
                        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-family: Arial, Helvetica, sans-serif">&nbsp;</td>
                    <td style="font-family: Arial, Helvetica, sans-serif">
                        <asp:Label ID="lblAddOne" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-family: Arial, Helvetica, sans-serif">&nbsp;</td>
                    <td style="font-family: Arial, Helvetica, sans-serif">
                        <asp:Label ID="lblAddTwo" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-family: Arial, Helvetica, sans-serif">&nbsp;</td>
                    <td style="font-family: Arial, Helvetica, sans-serif">
                        <asp:Label ID="lblCityState" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-family: Arial, Helvetica, sans-serif">&nbsp;</td>
                    <td style="font-family: Arial, Helvetica, sans-serif">
                        <asp:Label ID="lblZip" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6" colspan="2" style="font-family: Arial, Helvetica, sans-serif">USPS Verified...</td>
                </tr>
                <tr>
                    <td class="auto-style4" style="font-family: Arial, Helvetica, sans-serif">&nbsp;</td>
                    <td style="font-family: Arial, Helvetica, sans-serif">
                        <asp:Label ID="lblName0" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" style="font-family: Arial, Helvetica, sans-serif">&nbsp;</td>
                    <td style="font-family: Arial, Helvetica, sans-serif">
                        <asp:Label ID="lblAddOne0" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" style="font-family: Arial, Helvetica, sans-serif">&nbsp;</td>
                    <td style="font-family: Arial, Helvetica, sans-serif">
                        <asp:Label ID="lblAddTwo0" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" style="font-family: Arial, Helvetica, sans-serif">&nbsp;</td>
                    <td style="font-family: Arial, Helvetica, sans-serif">
                        <asp:Label ID="lblCityState0" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" style="font-family: Arial, Helvetica, sans-serif">&nbsp;</td>
                    <td style="font-family: Arial, Helvetica, sans-serif">
                        <asp:Label ID="lblZip0" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" style="font-family: Arial, Helvetica, sans-serif">&nbsp;</td>
                    <td style="font-family: Arial, Helvetica, sans-serif">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2" style="font-family: Arial, Helvetica, sans-serif">
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Nope! Use the original" />
&nbsp;<asp:Button ID="btnOK" runat="server" Text="Yep! Use the new" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
