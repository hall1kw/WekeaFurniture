<%@ Page Title="" Language="C#" MasterPageFile="~/HomeForms.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
    <style type="text/css">
        .auto-style4 {
            width: 60%;
        }
.dropbtn {
  background-color: #782b42;
  color: #ffc82e;
  padding: 16px;
  font-size: 16px;
  border: none;
}

.dropdown {
  position: relative;
  display: inline-block;
}

.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f1f1f1;
  box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
  z-index: 1;
}

.dropdown-content a {
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
}

.dropdown-content a:hover {background-color: #ddd;}

.dropdown:hover .dropdown-content {display: inline-block; height: auto;}

.dropdown:hover .dropbtn {background-color: #582b42; height: auto;}
        .auto-style6 {
            height: 3px;
        }
        .auto-style8 {
            height: auto;
        }
        .auto-style9 {
            text-align: left;
            width: 144px;
        }
        </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
    <tr>
        <td class="auto-style5"  style="width:250px; border-right-style:solid; border-right-width:3px; border-right-color:#782b42">
            <div class="text-center">
                <h3>Featured Products<br />
                </h3>
            </div>
            <asp:DataList ID="dlSearchFeat" runat="server">
                <ItemTemplate>
                    <table style="width:100%;">
                        <tr>
                            <td class="text-center">
                                <asp:Image ID="Image2" runat="server" style="width:200px; height:200px;" ImageUrl='<%# "/Images/ProductImages/" + Eval("IMAGE") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h5 class="text-center" ><strong>
                                    <asp:HyperLink ID="Label1" style="color:#782b42;" runat="server" NavigateUrl='<%# "ProductDetail.aspx?ID="+Eval("ID") %>' Text='<%# Eval("NAME") %>'></asp:HyperLink>
                                    </strong></h5>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:250px; border-bottom-style:solid; border-bottom-width:3px; border-bottom-color:#782b42;" class="text-right">$<asp:Label ID="Label2" runat="server" Text='<%# Eval("PRICE") %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </td>
        <td class="text-right">
            <h2 class="text-center">Search</h2>
            <form method="get" action="SearchResults.aspx">
            <table style="width:100%;" align="center">
                <tr>
                    <td class="auto-style9">Item Number:</td>
                    <td>
                        <input name="PID" type="text" /></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">Item Name:</td>
                    <td>
                        <input name="Name" type="text" /></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="text-left" colspan="2">
                        <h3>Search price range</h3>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">Minimum Price:</td>
                    <td>
                        <input name="MinP" type="text" /></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">Maximum Price:</td>
                    <td>
                        <input name="MaxP" type="text" /></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9" rowspan="2">
                        <div class="dropdown">
                            <button class="dropbtn" onclick="return false">Search by Room</button>
                            <div class="dropdown-content">
                                <select name="Rm" multiple style="width:200px; height:auto">
                                    <option value="Bedroom">Bedroom</option>
                                    <option value="Kitchen">Kitchen</option>
                                    <option value="LivingRoom">Living Room</option>
                                </select>
                            </div>
                        </div>

                    </td>
                    <td class="auto-style6"></td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="h-auto"></td>
                    <td class="auto-style8"></td>
                </tr>
                <tr>
                    <td class="text-left" colspan="2">Ctrl + Click to select multiple rooms / categories</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9" rowspan="2"><div class="dropdown">
                            <button class="dropbtn" onclick="return false">Search by Categories</button>
                            <div class="dropdown-content">
                                <select name="Cat" multiple style="width:200px; height:200px">
                                    <option value="Beds">Beds</option>
                                    <option value="Chairs">Chairs</option>
                                    <option value="Couches">Couches</option>
                                    <option value="Desks">Desks</option>
                                    <option value="Dressers">Dressers</option>
                                    <option value="Lamps">Lamps</option>
                                    <option value="Tables">Tables</option>
                                </select>
                            </div>
                        </div></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
            </table>
            <br />
            <input id="Reset1" type="reset" value="Reset" />&nbsp;<input type="submit" value="Search" /> 
                </form>

        </td>
            
        
    </tr>
 
</table>
    
</asp:Content>






