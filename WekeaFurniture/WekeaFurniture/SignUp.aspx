<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" CodeFile="SignUp.aspx.cs" Inherits="SignUp"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #SignUpForm {
            border: 3px solid #f1f1f1;
            text-align:center;
        }
        #signUpTable {
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
        .auto-style6 {
            height: 38px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <form id="SignUpForm" method="post" action="Home.aspx">
        <h1>Sign Up</h1>
        <table id="signUpTable">
          <tr>
            <th class="auto-style5"></th>
            <th class="auto-style5"></th> 
          </tr>
          <tr class ="trow">
            <td class="auto-style6">First Name</td>
            <td class="auto-style6"><asp:TextBox id="firstName" runat="Server"/></td> 
          </tr>
          <tr class ="trow">
            <td class="labelCol">Last Name</td>
            <td class="inputCol"><asp:TextBox id="lastName" runat="Server"/></td> 
          </tr>
          <tr class ="trow">
            <td class="labelCol">Email</td>
            <td class="inputCol"><asp:TextBox id="email" runat="server"/></td> 
          </tr>
          <tr class ="trow">
            <td class="labelCol">UserName</td>
            <td class="inputCol"><asp:TextBox id="userName" runat="server"/></td> 
          </tr>
          <tr class ="trow">
            <td class="labelCol">Password</td>
            <td class="inputCol"><asp:TextBox id="pw" runat="server" TextMode="Password"/></td> 
          </tr>

           
        </table>
        <br />
         <asp:Button id="btnSignUp" class="btn btn-warning my-2 my-sm-0" runat="server" Text="Sign Up"/><br />
        

    </form>
</asp:Content>