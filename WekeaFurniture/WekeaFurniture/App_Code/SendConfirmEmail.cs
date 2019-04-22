using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;

/// <summary>
/// Summary description for SendConfirmEmail
/// </summary>
public static class SendConfirmEmail
{
    private static EmailAddress from = new EmailAddress("rowla1m@cmich.edu", "WeKea Furniture");
    private static EmailAddress to;
    private static string fName = "";
    private static string lName = "";

    private static string subject = "";
    private static string body = "";

    public static void SendEmail()
    {
        System.Diagnostics.Debug.WriteLine("Starting email script");
        subject = "Thank you for your purchase!";
        Body();

        System.Diagnostics.Debug.WriteLine("Calling execute");
        SendConfirm();
    }

    private static void Body()
    {
        int lineCount = 1;

        foreach (var item in (ShoppingCart)HttpContext.Current.Session["thisCart"])
        {
            body += lineCount + ". " + item.Name + "\t" + item.Quantity + "\t" + item.Price + Environment.NewLine;
            lineCount++;
        }

        body += "Thank you for your order!" + Environment.NewLine + "\t -WeKea Support Team";
    }

    private static async void SendConfirm()
    {
        var apiKey = "";
        var client = new SendGridClient(apiKey);

        var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);
        System.Diagnostics.Debug.WriteLine("Final step in mail send");
        var response = await client.SendEmailAsync(msg);
    }
}

