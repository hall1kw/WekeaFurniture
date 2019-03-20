<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" CodeFile="SignUp.aspx.cs" Inherits="SignUp"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title></title>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Sign Up</h1>
    <form id="SignUpForm" method="post" action="Home.aspx">
        
        First Name&nbsp;&nbsp;&nbsp;
        <asp:TextBox id="firstName" runat="Server"/><br />
        <br />
        Last Name&nbsp;&nbsp;&nbsp;
        <asp:TextBox id="lastName" runat="Server"/><br />
        <br />
        Email&nbsp;&nbsp;&nbsp;
        <asp:TextBox id="email" runat="server"/><br />
        <br />
        Username&nbsp;&nbsp;&nbsp;
        <asp:TextBox id="userName" runat="server"/><br />
        <br />
        Password&nbsp;&nbsp;&nbsp;
        <asp:TextBox id="pw" runat="server" TextMode="Password"/><br />
        <br />
        <asp:Button id="btnSignUp" class="btn btn-warning my-2 my-sm-0" runat="server" Text="Sign Up"/><br />

    </form>
</asp:Content>