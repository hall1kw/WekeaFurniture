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
            
        string query = "INSERT INTO users (email, first_name, last_name, pass_hash) VALUES(" + email.Text + ", " + first_name.Text + ", " + last_name.Text + ", " + pw.Text + ");"; 
        DataAccess.selectQuery(query);

        query = "SELECT ID from users WHERE EMAIL=" + email.Text + ";";
        DataTable userinfo = DataAccess.selectQuery(query);

        String userid = userinfo.Rows[0][1].ToString();
        System.Diagnostics.Debug.WriteLine(userid);

        HttpCookie userInfo = new HttpCookie("userInfo");
        userInfo["userid"] = userid;
        userInfo["passhash"] = pw.Text;
        userInfo.Expires = DateTime.Now.AddHours(2);
        Response.Cookies.Add(userInfo);


    }
}