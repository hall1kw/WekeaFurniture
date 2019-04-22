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
    public static void sendResetLink(string email, string resetKey)
    {

    }

    static async Task Execute()
    {
        var apiKey = "<<<REPLACE WITH SENDGRID APIKEY FROM KENS EMAIL>>>";
        var client = new SendGridClient(apiKey);

        //var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);
        System.Diagnostics.Debug.WriteLine("Final step in mail send");
        //var response = await client.SendEmailAsync(msg);
    }
}