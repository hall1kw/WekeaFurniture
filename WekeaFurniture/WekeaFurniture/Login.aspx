<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" CodeFile="Login.aspx.cs" Inherits="Login"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title></title>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Login</h1>
    <form id="LoginForm" method="post" action="Home.aspx">
        Username&nbsp;&nbsp;&nbsp;
        <asp:TextBox id="UserName" runat="server"/><br />
        <br />
        Password&nbsp;&nbsp;&nbsp;
        <asp:TextBox id="pw" runat="server" TextMode="Password"/><br />
        <br />
        <asp:Button id="btnLogin" class="btn btn-warning my-2 my-sm-0" runat="server" Text="Login"/><br />

    </form>
    <form id="LoginToSignUp" method="post" action="SignUp.aspx">
        <p>Don't have an account?</p>
        <asp:Button ID="createAccount" class="btn btn-warning my-2 my-sm-0" runat="server" Text="Sign Up" />
    </form>
</asp:Content>

