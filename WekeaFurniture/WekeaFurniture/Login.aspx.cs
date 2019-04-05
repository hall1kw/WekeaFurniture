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

public partial class Login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {

        if(SignUp.IsValidEmail(email))
        {
            string pwd = SignUp.PassHash(pw);
        }
        else
        {
            Response.Redirect("https://wekeafurniture20190329101320.azurewebsites.net/Login.aspx", true);
        }

        string query = "SELECT (*)Count FROM user WHERE email=" + email.Text + " AND password=" + pwd + ";";
        DataTable dt = DataAccess.selectQuery(query);

        if (dt.Rows.Count.ToString() == "1")
        {
            HttpCookie mycookie = new HttpCookie("Login");
            mycookie["email"] = dt.Rows[0]["email"].ToString();
            mycookie["pw"] = dt.Rows[0]["pw"].ToString();
            mycookie.Expires = DateTime.Now.AddHours(2.00);
            Response.Cookies.Add(mycookie);

            HttpContext.Current.Session["userid"] = mycookie["userid"];
            HttpContext.Current.Session["passHash"] = mycookie["pw"];


        } else
        {
            errorLabel.Text = "UserName does not exist. Sign Up";
        }
    }
}