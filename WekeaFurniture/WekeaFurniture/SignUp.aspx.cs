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
using System.Globalization;
using System.Text.RegularExpressions;

public partial class SignUp : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        string pwd = "";

        if(Validation.ValidEmail(email.Text))
        {
            pwd = Validation.PassHash(pw.Text);
        }
            string query = "INSERT INTO user (email, password) VALUES(" + email.Text + ", " + pwd + ");";
            DataAccess.selectQuery(query);

        Response.Redirect("Home.aspx");
    }
}