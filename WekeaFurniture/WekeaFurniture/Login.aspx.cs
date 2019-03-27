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
        string query = "SELECT (*)Count FROM user WHERE email=" + email.Text + " AND password=" + pw.Text + ";";
        DataAccess.selectQuery(query);


    }
}