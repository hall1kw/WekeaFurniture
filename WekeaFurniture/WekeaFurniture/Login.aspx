<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Text1 {
            height: 12px;
            margin-left: 13px;
        }
        #form1 {
            height: 410px;
            width: 1464px;
        }
        #Text2 {
            margin-left: 18px;
        }
    </style>
</head>
<body>
    <h1>Login</h1>
    <form id="form1" method="post" action="Home.aspx" runat="server">
        
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
</body>
</html>
