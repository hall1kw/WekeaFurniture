using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

public partial class SignUp : System.Web.UI.Page
{ 
    
    private const string table = "UserTable";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[table].ToString());
        con.Open();
       
        string query = "Select Count(*) from User where user_name='" + userName.Text + "'";

        SqlCommand command = new SqlCommand(query, con);
        SqlDataReader data = command.ExecuteReader();
        string output = "";

        Trace.Write("Data: " + data);

        while(data.Read())
        {
            output = output + data.GetValue(0) + " - " + data.GetValue(1);
            
        }

        Trace.Write("Output: " +output);
        data.Close();
        command.Dispose();
        con.Close();
      
        
    }
}