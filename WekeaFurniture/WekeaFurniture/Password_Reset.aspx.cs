using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Password_Reset : System.Web.UI.Page
{

    string resetKey;

    protected void Page_Load(object sender, EventArgs e)
    {
        resetKey = Request.QueryString["Key"];
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        lblWarning.Text = "";
        string newPass = txtPass.Text;
        string newPass2 = txtPass2.Text;


        if (newPass == newPass2 && newPass != "")
        {
            string getKey = "SELECT * FROM Password_Resets WHERE query_string = '" + resetKey + "';";
            DataTable dt = DataAccess.selectQuery(getKey);
            string userID = dt.Rows[0]["UID"].ToString();
            TimeSpan span = DateTime.Now.Subtract(DateTime.Parse(dt.Rows[0]["TIME"].ToString()));

            string getEmail = "SELECT EMAIL FROM Users WHERE ID = '" + userID + "';";
            DataTable userInfo = DataAccess.selectQuery(getEmail);
            string email = userInfo.Rows[0]["EMAIL"].ToString();


            if (span.Minutes < 15 && email == txtEmail.Text)
            {
                //run password through hashing algorithm
                String[] hash = Validation.PassHash(newPass);


                //updates the user table
                string update = "UPDATE Users SET PASS_HASH = '" + hash[0] + "', PASS_SALT = '" + hash[1] + "'" +
                    "WHERE ID = '" + userID + "';";
                DataAccess.selectQuery(update);

                string delete = "DELETE FROM Password_Resets WHERE query_string = '" + resetKey + "';";
                DataAccess.selectQuery(delete);

                Response.Redirect("Login.aspx");

            }

            if (email != txtEmail.Text)
                lblWarning.Text = "Invalid email";

        } else
        {
            lblWarning.Text = "Password does not match";
        }


        

    }
}