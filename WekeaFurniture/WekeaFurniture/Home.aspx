<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>        
        body {
            background-color: f8f9fa;
        }
        .newStyle1 {
            font-family: Arial;
        }
        .auto-style1 {
            width: 86px;
            height: 46px;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    <table style="width:100%;">
        <tr>
            <td style="width:66%;">Featured Products - Needs to be databound</td>
            <td style="width:34%;">
                <img alt="" src="Images/account-login.png" /><br />
                Username:&nbsp;&nbsp;
                <input id="Text1" type="text" /><br />
                Password:&nbsp;&nbsp;&nbsp;
                <input id="Text2" type="password" /></td>
        </tr>
        <tr>
            <td style="width:66%;">&nbsp;</td>
            <td style="width:34%;">&nbsp;</td>
        </tr>
    </table>
    
    
</asp:Content>

