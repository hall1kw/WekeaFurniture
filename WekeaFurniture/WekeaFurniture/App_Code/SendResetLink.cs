using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

/// <summary>
/// Summary description for SendResetLink
/// </summary>
public class SendResetLink
{

    public static EmailAddress from = new EmailAddress("hall1kw@cmich.edu", "WeKea Furniture");
    public static EmailAddress to;
    public static string subject;
    public static string body;


    public static void sendResetLink(string email, string resetKey)
    {
        to = new EmailAddress(email, "User");
        subject = "password reset WeKea Furniture";
        body = "Reset your password at https://wekeafurniture20190329101320.azurewebsites.net/Password_Reset.aspx?Key=" 
            + resetKey;
        Execute();

    }

    static async Task Execute()
    {
        var apiKey = "<<<REPLACE WITH SENDGRID APIKEY FROM KENS EMAIL>>>";
        var client = new SendGridClient(apiKey);

        var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);
        System.Diagnostics.Debug.WriteLine("Final step in mail send");
        var response = await client.SendEmailAsync(msg);
    }
}