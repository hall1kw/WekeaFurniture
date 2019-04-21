﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.master" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

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
    </style>   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form id="loginForm" method="post" action="Login.aspx.cs">
        <h1>Forgot Password</h1>
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
            <td class="labelCol"></td>
            <td class="inputCol">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td> 
          </tr>

           
        </table>
        <br />
        <asp:Button id="btn_SignUp" class="btn btn-warning my-2 my-sm-0" runat="server" OnClick="btnLogin_Click" Text="Login"/>
        <asp:Button id="btn_forgotPassword" class="btn btn-warning my-2 my-sm-0" runat="server" Text="Forgot Password" OnClick="btn_forgotPassword_Click"/>

    </form>
</asp:Content>
