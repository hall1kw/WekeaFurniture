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
        Console.WriteLine("This works");


        string pwd = "";

        if (Validation.ValidEmail(email.Text))
        {
            pwd = Validation.PassHash(pw.Text);
        }
        string query = "INSERT INTO Users (email, first_name, last_name, pass_hash) VALUES('" + email.Text + "', '" +
            first_name.Text + "', '" + last_name.Text + "', '" + pwd + "');";
        DataAccess.selectQuery(query);
        
        query = "SELECT ID from Users WHERE EMAIL='" + email.Text + "';";
        DataTable userinfo = DataAccess.selectQuery(query);

        String userid = userinfo.Rows[0][0].ToString();
        /*
        System.Diagnostics.Debug.WriteLine(userid + "\nHKFDLFKDLFKLSFHDLSHFLKSDHFLD");
        
        HttpCookie userInfo = new HttpCookie("userInfo");
        userInfo["userid"] = userid;
        userInfo["passhash"] = pwd;
        userInfo.Expires = DateTime.Now.AddHours(2);
        Response.Cookies.Add(userInfo);
        */
        Response.Redirect("Home.aspx");

    }
}

/*

*/
