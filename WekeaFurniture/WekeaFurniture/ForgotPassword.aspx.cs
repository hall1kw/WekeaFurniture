using System;
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

            //generate a random 50 character string
            string key = RandomString(50, false);
            string now = DateTime.Now.ToString();

            //insert recovery key into the database
            string addKey = "INSERT INTO Reset_Password (UID,Query_String,Creation_Time) " +
                "VALUES ('" + UID + "','" + key + "','" + now + "');";
            DataAccess.insertQuery(addKey);


            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("hall1kw@cmich.edu", "WeKea Furniture");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("paul.cappaert@gmail.com", "To Test User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
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