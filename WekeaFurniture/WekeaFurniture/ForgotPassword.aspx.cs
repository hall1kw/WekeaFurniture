﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using SendGrid;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;
using System.Text;
using System.Data;

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text;

        //check that the user with that email exists, get their UID
        string query = "SELECT ID FROM Users WHERE EMAIL ='" + email + "';";
        DataTable dt = DataAccess.selectQuery(query);
        if(dt.Rows.Count == 1)
        {
            string UID = dt.Rows[0]["ID"].ToString();

            //removes all other reset keys that may exist for the user
            string delete = "DELETE FROM Password_Resets WHERE UID = '" + UID + "';";
            DataAccess.selectQuery(delete);

            //generate a random 50 character string
            string key = RandomString(50, false);
            string now = DateTime.Now.ToString();

            //insert recovery key into the database
            string addKey = "INSERT INTO Password_Resets (query_string, UID, TIME)" +
                " VALUES ('" + key + "','" + UID + "','" + now + "');";
            DataAccess.selectQuery(addKey);


            //send email with link
            SendResetLink.sendResetLink(email, key);

            lblMessage.Text = "A reset link has been sent to your email";
            
        } else
        {
            lblMessage.Text = "invalid email address";
        }

        

    }

    public string RandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        if (lowerCase)
            return builder.ToString().ToLower();
        return builder.ToString();
    }
}