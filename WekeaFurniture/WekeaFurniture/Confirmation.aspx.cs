using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using System.Diagnostics;

public partial class Confirmation : System.Web.UI.Page
{
    protected ShoppingCart thisCart;
    protected string[] shippingInfo;
    protected double tax;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["thisCart"] == null)
        {
            Response.Write("<script>alert('There was an error loading your shopping cart!')</script>");
            Response.Redirect("/Home.aspx");
        }
        else
        {
            thisCart = (ShoppingCart)Session["thisCart"];
        }
        if (thisCart.Items.Count == 0)
        {
            Response.Write("<script>alert('Your shopping cart is empty!')</script>");
            Response.Redirect("/Home.aspx");
        }
        if (Session["shippingInfo"] == null)
        {
            Response.Redirect("/CheckoutStopOne.aspx");
        }
        else
        {
            shippingInfo = (string[])Session["shippingInfo"];
            PopulateShippingInfo();
            EmailConfirmation();
        }

        if (!IsPostBack)
        {
            lblTax.Text = shippingInfo[6];
            lblTotal.Text = shippingInfo[7];
            dlCartSummary.DataSource = thisCart.Items;
            dlCartSummary.DataBind();
            lblSubtotal.Text = string.Format("Item's Subtotal: {0,19:C}", thisCart.GrandTotal);

            BackOrderMessage();
            UpdateStock();
            SaveOrder();

            Session["thisCart"] = null;
        }
    }

    protected void EmailConfirmation()
    {
        SmtpClient client = new SmtpClient();
        MailMessage mail = new MailMessage("wekeafurniture@gmail.com", "contact.mjrowland@gmail.com"); 
        mail.Subject = "Test";
        mail.Body = "This is a test of the public service announcement. This is only a test.";

        try
        {
            client.Send(mail);
        }
        catch (System.Exception)
        {
            Response.Write("<script>alert('Email could not be sent, please retry at a later time.')</script>");
        }
    }

    protected void BackOrderMessage()
    {
        String BackOrderMessage = "";
        foreach (CartItem item in thisCart.Items)
        {
            int itemInventory = Int32.Parse(DataAccess.selectQuery("SELECT INVENTORY FROM PRODUCTS WHERE ID =" + item.ID).Rows[0]["INVENTORY"].ToString());
            if (item.Quantity > itemInventory)
            {
                int BackOrder = item.Quantity - itemInventory;
                BackOrderMessage += "The product: " + item.Name + " only has " + itemInventory + " in stock. The remaining " + item.Name + "(s) will be back ordered. We are sorry for the inconvenience.\n";
            }
        }
        BackOrderWarning.Text = BackOrderMessage;
    }

    protected void UpdateStock()
    {
        foreach (CartItem item in thisCart.Items)
        {
            int itemInventory = Int32.Parse(DataAccess.selectQuery("SELECT INVENTORY FROM PRODUCTS WHERE ID =" + item.ID).Rows[0]["INVENTORY"].ToString());
            if (item.Quantity > itemInventory)
            {
                int inventory = 0;
                DataAccess.selectQuery("UPDATE Products SET INVENTORY=" + inventory + " WHERE ID=" + item.ID);
            }
            else
            {
                int inventory = itemInventory - item.Quantity;
                DataAccess.selectQuery("UPDATE Products SET INVENTORY=" + inventory + " WHERE ID=" + item.ID);
            }
        }
    }

    protected void SaveOrder()
    {
        string date = DateTime.Now.ToString();
        string user = (string) Session["userLoggedIn"];
        if (string.IsNullOrEmpty(user))
        {
            user = "1";
        }

        //TODO: check if exact info is already saved. if not ->
        //save shipping info
        string addShippingQuery = "INSERT INTO Shipping_Info (UID,SHIP_TO_NAME,ADDRESS_ONE,ADDRESS_TWO,CITY,STATE,ZIP) " +
            "VALUES ('" + user + "','" + shippingInfo[0] + "','" + shippingInfo[1] + "','" + shippingInfo[1] +
            "','" + shippingInfo[3] + "','" + shippingInfo[4] + "','" + shippingInfo[5] + "');";
        DataAccess.insertQuery(addShippingQuery);

        string getKey = "SELECT ID FROM Shipping_Info WHERE UID ='" + user + "' and SHIP_TO_NAME ='" + shippingInfo[0] + "' and ADDRESS_ONE ='" + shippingInfo[1] + "' and ADDRESS_TWO ='" + 
            shippingInfo[1] + "' and CITY ='" + shippingInfo[3]+ "' and STATE ='" + shippingInfo[4] + "' and ZIP ='" + shippingInfo[5] + "';";
        DataTable dt = DataAccess.selectQuery(getKey);
        string orderKey = dt.Rows[0]["ID"].ToString();

        //save payment info

        string[] paymentInfo = (string[])Session["paymentInfo"];
        string addPaymentQuery;
        addPaymentQuery = "INSERT INTO Payment_Info (UID,NAME_ON_CARD,CARD_NUM,EXP_MO,EXP_YR,GIFT_CARD,CVV)" +
        " VALUES ('" + user + "','" + paymentInfo[0] +"','" + paymentInfo[1] + "','" + paymentInfo[2] + "','"
        + paymentInfo[3] + "','" + paymentInfo[4] + "','" + paymentInfo[5] + "');";
        DataAccess.insertQuery(addPaymentQuery);

        getKey = "SELECT ID FROM Payment_Info WHERE UID='" + user + "' and NAME_ON_CARD='" + paymentInfo[0] + "' and CARD_NUM='" 
        + paymentInfo[1] + "' and EXP_MO='" + paymentInfo[2] + "' and EXP_YR='"
        + paymentInfo[3] + "' and GIFT_CARD='" + paymentInfo[4] + "' and CVV='" + paymentInfo[5] + "';";
        DataTable dt2 = DataAccess.selectQuery(getKey);
        string paymentKey = dt2.Rows[0]["ID"].ToString();



        string total = shippingInfo[7].Substring(26);
        string addOrderQuery = "INSERT INTO Orders (UID,PYMT_INFO,ORDER_DATE,AMMT,SHIP_INFO,FULLFILLED)" +
            "VALUES ('" + user + "','" + paymentKey + "','" + date + "','" + total
            + "','" + orderKey + "','0');";

        DataAccess.insertQuery(addOrderQuery);

        //add to order products
    }

    protected void PopulateShippingInfo()
    {
        lblShipName.Text = shippingInfo[0];
        lblShipAddOne.Text = shippingInfo[1];
        lblShipAddTwo.Text = shippingInfo[2];
        lblShipCity.Text = shippingInfo[3] + ", " + shippingInfo[8] + " " + shippingInfo[5];
    }
}