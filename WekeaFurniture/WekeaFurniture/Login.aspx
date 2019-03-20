<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title></title>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Login</h1>
    <form id="form1" method="post" action="Home.aspx">
        
        Name&nbsp;&nbsp;&nbsp;
        <input id="Name" type="text" name="name"/><br />
        <br />
        Email&nbsp;&nbsp;&nbsp;
        <input id="Email" type="text" name="email"/><br />
        <br />
        Username&nbsp;&nbsp;&nbsp;
        <input id="UserName" type="text" name="username"/><br />
        <br />
        Password&nbsp;&nbsp;&nbsp;
        <input id="pw" type="password" name="pw"/><br />
        <br />
        <input id="Submit1" type="submit" value="submit" /></form>
</asp:Content>

