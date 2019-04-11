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

    /*
     * Runs when the user clicks the "Sign Up" button. 
     * 
     * This method checks to see if the email and password is valid.
     * If the fields aren't valid, alert the user of wrong input.
     * 
     * If they are valid, hash the password and insert all fields into User table.
     * Create a cookie containing the ID and the password hash of the user.
     */ 
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        //Check to see if email and password combination is taken already
        string query = "SELECT ID from Users WHERE EMAIL='" + email.Text + "';";
        DataTable userinfo = DataAccess.selectQuery(query);

        //If taken, alert them to choose a different password. If not, continue
        if (userinfo.Rows.Count == 1)
        {
            //Alert for different password
        } else
        {
            string pwd = "";

            if (Validation.ValidEmail(email.Text))
            {
                pwd = Validation.PassHash(pw.Text);
            }
            else
            {
                //Create alert that says "Email not valid"
            }
            query = "INSERT INTO Users (email, first_name, last_name, pass_hash) VALUES('" + email.Text + "', '" +
                first_name.Text + "', '" + last_name.Text + "', '" + pwd + "');";
            DataAccess.selectQuery(query);

            query = "SELECT ID from Users WHERE EMAIL='" + email.Text + "' AND PASS_HASH='" + pwd + "';";
            userinfo = DataAccess.selectQuery(query);

            String userid = userinfo.Rows[0][0].ToString();


            HttpCookie userInfo = new HttpCookie("userInfo");
            userInfo["userid"] = userid;
            userInfo["passhash"] = pwd;
            userInfo.Expires = DateTime.Now.AddHours(2);
            Request.Cookies.Add(userInfo);

            if(Session["userLoggedIn"] == null)
            {
                Session["userLoggedIn"] = userid;
                System.Diagnostics.Debug.Write("New Session SignUp: " + Session["userLoggedIn"].ToString() + "\n");
            } else
            {

                Session["userLoggedIn"] = userid;
                System.Diagnostics.Debug.Write("Session Signup Already made: " + Session["userLoggedIn"].ToString() + "\n");
            }
            

            Response.Redirect("Home.aspx");
        }

        

    }
}
