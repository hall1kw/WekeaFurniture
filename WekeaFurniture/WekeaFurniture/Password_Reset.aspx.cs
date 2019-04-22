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
        string newPass = txtPass.Text;
        string newPass2 = txtPass2.Text;

        if (newPass == newPass2 && newPass != "")
        {
            string getKey = "SELECT * FROM Password_Resets WHERE KEY = '" + resetKey + "';";
            DataTable dt = DataAccess.selectQuery(getKey);
            int expr = DateTime.Compare(DateTime.Now, DateTime.Parse(dt.Rows[0]["TIME"].ToString()));
            if (expr < 30)
            {
                //run password through hashing algorithm
                //update password hash and salt on user table
                //email confirmation to user that password is changed
            }
        } else
        {

        }


        

    }
}