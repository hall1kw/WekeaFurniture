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

    /*
     * Method fires when the User clicks the login button.
     * 
     * Validates the email and password. If not valid, alerts the user.
     * 
     * If the email and password is valid, checks the database to see if
     * the user has already signed up. If not, alerts the user to sign up.
     * 
     * If the user is in the database, checks to see if a cookie has been 
     * created for this user. If not, create a cookie.
     * 
     * If a cookie has been created for this user, extend the time of the 
     * cookie's expiration date.
     */ 
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string pwd = "";

        //Validates/hashes the input
        if(Validation.ValidEmail(email.Text))
        {
            pwd = Validation.PassHash(pw.Text);
        }
        else
        {
            //Alert user saying email isn't valid
            Response.Redirect("https://wekeafurniture20190329101320.azurewebsites.net/Login.aspx", true);
        }

        string query = "SELECT * FROM Users WHERE email='" + email.Text + "';";
        DataTable dt = DataAccess.selectQuery(query);
        System.Diagnostics.Debug.WriteLine("DT Count: " + dt.Rows.Count + "\n");

        string userid = dt.Rows[0][0].ToString();
        pwd = dt.Rows[0][4].ToString();

        //if there is one user in the database
        if (dt.Rows.Count == 1)
        {
            HttpCookie mycookie = null;
            //If there's already a cookie containing the user's information
            if (HttpContext.Current.Response.Cookies.AllKeys.ToString().Contains("userInfo"))
            {
                mycookie = Request.Cookies.Get("userInfo");
                if(mycookie["userid"].ToString().Equals(userid))
                {
                    //make sure that the cookie contains the right user's info
                    mycookie.Expires = DateTime.Now.AddHours(2.00);
                } else
                {
                    //This means that a user logged in with different login info than the cookie
                    Request.Cookies.Remove("userInfo");
                    newUserCookie(mycookie, userid, pwd);
                }
                
            } else
            {
                //Create a cookie containing the user's Information
                newUserCookie(mycookie, userid, pwd);
            }
            

        } else
        {
            //Create an alert saying the UserName doesn't exist
            errorLabel.Text = "UserName does not exist. Sign Up";
        }

        //Check to see if a session has never been created, or if the Session just ended
        if (Session["userLoggedIn"] == null)
        {
            Session["userLoggedIn"] = userid;
            System.Diagnostics.Debug.Write("New Session Login: " + Session["userLoggedIn"].ToString() + "\n");
        }
        else
        {

            Session["userLoggedIn"] = userid;
            System.Diagnostics.Debug.Write("Session Login Already Made: " + Session["userLoggedIn"].ToString() + "\n");
        }

        Response.Redirect("Home.aspx");
    }

    /*
     * Creates a new cookie containing user information
     * 
     * params:
     * mycookie - The cookie that will be created
     * userid - The user's unique key
     * pwd - The hash of the user's password
     * 
     * returns: Nothing
     */ 
    protected void newUserCookie(HttpCookie mycookie, string userid, string pwd)
    {
        mycookie = new HttpCookie("userInfo");

        mycookie["userid"] = userid;
        mycookie["pw"] = pwd;
        mycookie.Expires = DateTime.Now.AddHours(2.00);
        Response.Cookies.Add(mycookie);
    }
}