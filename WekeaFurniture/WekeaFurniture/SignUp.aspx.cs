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
    List<string> errorMessage = new List<string>();
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
        string error = "";
        if (valid_entry())
        {
            for(int i = 0; i < errorMessage.Count; i++)
            {
                if (i == errorMessage.Count - 1)
                    error += errorMessage[i].ToString();
                else
                    error += errorMessage[i].ToString() + "\\n";
            }
            Response.Write("<script language = 'javascript' > alert('" + error + "');</script>");
        }
        else
        {
            //Check to see if email and password combination is taken already
            string query = "SELECT ID from Users WHERE EMAIL='" + email.Text + "';";
            DataTable userinfo = DataAccess.selectQuery(query);
            System.Diagnostics.Debug.Write("Before If\n");

            //If taken, alert them to choose a different password. If not, continue
            if (userinfo.Rows.Count == 1)
            {
                System.Diagnostics.Debug.Write("Rows Count is 1\n");
                Response.Write("<script language='javascript'>alert('You already have an account');</script>");
                //Alert for different password
            }
            else
            {
                string[] pwdHashAndSalt = new string[2];
                string pwd = "";

                if (Validation.ValidEmail(email.Text))
                {
                    pwdHashAndSalt = Validation.PassHash(pw.Text);
                    //pwd = Validation.PassHash(pw.Text);
                }
                else
                {
                    //Create alert that says "Email not valid"
                    Response.Write("<script language='javascript'>alert('Email not valid');</script>");
                }
                query = "INSERT INTO Users (email, first_name, last_name, pass_hash, pass_salt) VALUES('" + email.Text + "', '" +
                    first_name.Text + "', '" + last_name.Text + "', '" + pwdHashAndSalt[0] + "', '" + pwdHashAndSalt[1] + "');";
                DataAccess.selectQuery(query);

                query = "SELECT ID from Users WHERE EMAIL='" + email.Text + "'";
                userinfo = DataAccess.selectQuery(query);
                DataRow userRow = userinfo.Rows[0];
                String userid = userRow["ID"].ToString();

                System.Diagnostics.Debug.Write("Before Insert\n");

                //Insert user's shipping information
                query = "INSERT INTO Shipping_Info (uid, ship_to_name, address_one, city, state, zip, phone) VALUES('" +
                    userid + "', '" + first_name.Text + " " + last_name.Text + "', '" + address.Text + "', '" + city.Text
                     + "', '" + state.Text + "', '" + zip.Text + "');";
                DataAccess.selectQuery(query);


                HttpCookie userInfo = new HttpCookie("userInfo");
                userInfo["userid"] = userid;
                userInfo["passhash"] = pwdHashAndSalt[0];
                userInfo.Expires = DateTime.Now.AddHours(2);
                Response.Cookies.Add(userInfo);

                if (Session["userLoggedIn"] == null)
                {
                    Session["userLoggedIn"] = userid;
                    System.Diagnostics.Debug.Write("New Session SignUp: " + Session["userLoggedIn"].ToString() + "\n");
                }
                else
                {

                    Session["userLoggedIn"] = userid;
                    System.Diagnostics.Debug.Write("Session Signup Already made: " + Session["userLoggedIn"].ToString() + "\n");
                }


                Response.Redirect("Home.aspx");
            }
        }
    }
    protected bool valid_entry()
    {
        bool hasErrors = false;

        if (first_name.Text.Length == 0)
        {
            errorMessage.Add("First Name is required");
            hasErrors = true;
        }
        if (last_name.Text.Length == 0)
        {
            errorMessage.Add("Last Name is required");
            hasErrors = true;
        }
        if (email.Text.Length == 0)
        {
            errorMessage.Add("Password should be at least 5 characters long");
            hasErrors = true;
        }
        if (pw.Text.Length < 5)
        {
            errorMessage.Add("Password should be at least 5 characters long");
            hasErrors = true;
        }
        if (address.Text.Length == 0)
        {
            errorMessage.Add("Address is required");
            hasErrors = true;
        }
        if (city.Text.Length == 0)
        {
            errorMessage.Add("City is required");
            hasErrors = true;
        }
        if (state.Text.Length != 2)
        {
            errorMessage.Add("State should be 2 characters long");
            hasErrors = true;
        }
        if (zip.Text.Equals(""))
        {
            errorMessage.Add("Zip Code is required");
            hasErrors = true;
        }

        return hasErrors;
    }
}
