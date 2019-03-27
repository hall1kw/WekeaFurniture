<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" CodeFile="Login.aspx.cs" Inherits="Login"%>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #loginForm {
            border: 3px solid #f1f1f1;
            text-align:center;
        }
        #loginTable {
            text-align: center;
            width: 466px;
            margin-left: 477px;
        }
        th:empty {
          visibility: hidden;
        }
        .trow {
            height: 50px;
        }
        .auto-style5 {
            height: 6px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <form id="loginForm" method="post" action="Home.aspx">
        <h1>Login</h1>
        <table id="loginTable">
          <tr>
            <th class="auto-style5"></th>
            <th class="auto-style5"></th> 
          </tr>
          <tr class ="trow">
            <td class="labelCol">Email</td>
            <td class="inputCol"><asp:TextBox id="email" name="email" runat="server"/></td> 
          </tr>
          <tr class ="trow">
            <td class="labelCol">Password</td>
            <td class="inputCol"><asp:TextBox id="pw" name="pw" runat="server" TextMode="Password"/></td> 
          </tr>

           
        </table>
        <br />
        <asp:Label ID="errorLabel" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label><br />
        <asp:Button id="btnSignUp" class="btn btn-warning my-2 my-sm-0" runat="server" Text="Login"/>

    </form>
    <p>or</p>
    <form id="goToSignUp" method="post" action="SignUp.aspx">
        <button id="loginToSignUp" class="btn btn-warning my-2 my-sm-0" type="submit" >Sign Up</button>
    </form>
</asp:Content>

