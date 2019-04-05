using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Collections;

public partial class SignUp : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {

        "if ($_SERVER[\"REQUEST_METHOD\"] == \"POST\")" + 
        "{ $email = $_POST[\'ctl00$ContentPlaceHolder1$email\']" +
        "$pwd = $_POST[\'ctl00$ContentPlaceHolder1$pw\']" +
            "if (!filter_var($email, FILTER_VALIDATE_EMAIL))" + 
                "{ echo \"<script>alert(\'email is not valid\')</script> }" +
            "else { $_POST[\'ctl00$ContentPlaceHolder1$email\'] = $email }" +

            "$pwd = password_hash($pwd, PASSWORD_DEFAULT)" +
            "$_POST[\'ctl00$ContentPlaceHolder1$pw\'] = $pwd" +
            //"header(\"Location: https://wekeafurniture20190329101320.azurewebsites.net/SignUp.aspx.cs\")";
            //"exit()";
        "}" +

        "elseif ($_SERVER[\"HTTP_REFERER\"] == \"https://wekeafurniture20190329101320.azurewebsites.net/Login.aspx\")" +
        "{" +
            "$email = $_POST[\'ctl00$ContentPlaceHolder1$email\']" +
            "$pwd = $_POST[\'ctl00$ContentPlaceHolder1$pw\']" +
            
            "if (!filter_var($email, FILTER_VALIDATE_EMAIL))" + 
                "{ echo \"<script>alert(\'email is not valid\')</script> }" +
            "else { $_POST[\'ctl00$ContentPlaceHolder1$email\'] = $email }" +

            "$pwd = password_hash($pwd, PASSWORD_DEFAULT)" +
            "$_POST[\'ctl00$ContentPlaceHolder1$pw\'] = $pwd" +
            //"header(\"Location: https://wekeafurniture20190329101320.azurewebsites.net/Login.aspx.cs\")";
            //"exit()";
        "}";
        string query = "INSERT INTO user (email, password) VALUES(" + email.Text + ", " + pw.Text + ");";
        DataAccess.selectQuery(query);


    }
}