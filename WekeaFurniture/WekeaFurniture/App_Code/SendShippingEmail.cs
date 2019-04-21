using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

/// <summary>
/// Summary description for SendShippingEmail
/// </summary>
public class SendShippingEmail
{
    public static EmailAddress from = new EmailAddress("hall1kw@cmich.edu", "WeKea Furniture");
    public static EmailAddress to;
    public static string fName;
    public static string lName;

    public static string shipToName;
    public static string lineOne;
    public static string lineTwo;
    public static string city;
    public static string state;
    public static string zip;
    public static string method;

    public static string subject;
    public static string body;
    public static string expected;

    public static void SendShipEmail(int OID)
    {
        System.Diagnostics.Debug.WriteLine("Starting email script");
        DataTable dt = DataAccess.selectQuery("SELECT TOP 1 * FROM Orders WHERE ID ='" + OID.ToString() + "';");
        DataRow row = dt.Rows[0];
        int orderUser = Int32.Parse(row["UID"].ToString());
        SetRecipientInfo(orderUser);
        int shippingInfo = Int32.Parse(row["SHIP_INFO"].ToString());
        SetShippingInfo(shippingInfo);
        subject = "A subject";
        subject = fName + ", your order (Order ID: " + OID.ToString() + ") has shipped!";
        if (row["SHIPPING_METHOD"].ToString().Equals("1")){
            method = "Express 2-Day Shipping";
            expected = DateTime.Today.AddDays(2).ToString();
        } else
        {
            method = "FREE Standard Shipping";
            expected = DateTime.Today.AddDays(7).ToString();
        }
        body = Body(OID);
        
        System.Diagnostics.Debug.WriteLine("Calling execute");
        Execute();
    }

    protected static string Body(int OID)
    {
        return
            "Hello " + fName + "," + Environment.NewLine +
            "\t Great News!!!  Your order (Order #: " + OID.ToString() + ") was shipped on " +
            DateTime.Now.ToString() + "! " + Environment.NewLine + 
            "Ship to:" + Environment.NewLine +
            lineOne + Environment.NewLine +
            lineTwo + Environment.NewLine +
            city + ", " + state + " " + zip + Environment.NewLine +
            "During the checkout process you selected " + method +
            ".  You should receive your order by " + expected + "." + Environment.NewLine + Environment.NewLine +
            "Thank you for your order!" + Environment.NewLine + "\t -WeKea Support Team";
    }

    protected static void SetSubject(int OID)
    {
        subject = fName + ", your order (Order ID: " + OID.ToString() + ") has shipped!";
    }

    protected static void SetRecipientInfo(int UID)
    {
        DataTable dt = DataAccess.selectQuery("SELECT TOP 1 * FROM USERS WHERE ID = '" + UID.ToString() + "';");
        DataRow user = dt.Rows[0];
        fName = user["FIRST_NAME"].ToString();
        lName = user["LAST_NAME"].ToString();
        to = new EmailAddress(user["EMAIL"].ToString(), (fName + " " + lName));
    }

    protected static void SetShippingInfo(int SHIP_INFO)
    {
        DataTable dt = DataAccess.selectQuery("SELECT TOP 1 * FROM Shipping_Info WHERE ID = '" + SHIP_INFO.ToString() + "';");
        DataRow shippingDeets = dt.Rows[0];
        shipToName = shippingDeets["SHIP_TO_NAME"].ToString();
        lineOne = shippingDeets["ADDRESS_ONE"].ToString();
        lineTwo = shippingDeets["ADDRESS_TWO"].ToString();
        city = shippingDeets["CITY"].ToString();
        state = shippingDeets["STATE"].ToString();
        zip = shippingDeets["ZIP"].ToString();        
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