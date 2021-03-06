﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using System.Diagnostics;
using SendGrid;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;

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
            SendConfirmEmail.SendEmail();
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
        System.Diagnostics.Debug.WriteLine(user);
        if (string.IsNullOrEmpty(user))
        {
            user = "1";
        }

        //TODO: check if exact info is already saved. if not ->
        //save shipping info
        System.Diagnostics.Debug.WriteLine("before insert shipping");
        string addShippingQuery = "INSERT INTO Shipping_Info (UID,SHIP_TO_NAME,ADDRESS_ONE,ADDRESS_TWO,CITY,STATE,ZIP) " +
            "VALUES ('" + user + "','" + shippingInfo[0] + "','" + shippingInfo[1] + "','" + shippingInfo[1] +
            "','" + shippingInfo[3] + "','" + shippingInfo[8] + "','" + shippingInfo[5] + "');";
        DataAccess.selectQuery(addShippingQuery);

        string getKey = "SELECT ID FROM Shipping_Info WHERE UID ='" + user + "' and SHIP_TO_NAME ='" + shippingInfo[0] + "' and ADDRESS_ONE ='" + shippingInfo[1] + "' and ADDRESS_TWO ='" + 
            shippingInfo[1] + "' and CITY ='" + shippingInfo[3]+ "' and STATE ='" + shippingInfo[8] + "' and ZIP ='" + shippingInfo[5] + "';";
        DataTable dt = DataAccess.selectQuery(getKey);
        string shippingKey = dt.Rows[0]["ID"].ToString();

        //save payment info

        string[] paymentInfo = (string[])Session["paymentInfo"];
        string addPaymentQuery;
        System.Diagnostics.Debug.WriteLine("before insert payment");
        addPaymentQuery = "INSERT INTO Payment_Info (UID,NAME_ON_CARD,CARD_NUM,EXP_MO,EXP_YR,GIFT_CARD,CVV)" +
        " VALUES ('" + user + "','" + paymentInfo[0] +"','" + paymentInfo[1] + "','" + paymentInfo[2] + "','"
        + paymentInfo[3] + "','" + paymentInfo[4] + "','" + paymentInfo[5] + "');";
        DataAccess.selectQuery(addPaymentQuery);

        getKey = "SELECT ID FROM Payment_Info WHERE UID='" + user + "' and NAME_ON_CARD='" + paymentInfo[0] + "' and CARD_NUM='" 
        + paymentInfo[1] + "' and EXP_MO='" + paymentInfo[2] + "' and EXP_YR='"
        + paymentInfo[3] + "' and GIFT_CARD='" + paymentInfo[4] + "' and CVV='" + paymentInfo[5] + "';";
        DataTable dt2 = DataAccess.selectQuery(getKey);
        string paymentKey = dt2.Rows[0]["ID"].ToString();


        int loc = shippingInfo[7].LastIndexOf("$");
        string total = shippingInfo[7].Substring(loc + 1);
        System.Diagnostics.Debug.WriteLine("before insert order " + user);
        string addOrderQuery = "INSERT INTO Orders (UID,PYMT_INFO,ORDER_DATE,AMMT,SHIP_INFO,FULLFILLED)" +
            " VALUES ('" + user + "','" + paymentKey + "','" + date + "','" + total
            + "','" + shippingKey + "','0');";

        DataAccess.selectQuery(addOrderQuery);

        getKey = "SELECT ID FROM Orders WHERE UID='" + user + "' and PYMT_INFO='" + paymentKey +"' and ORDER_DATE='" + date + "' and AMMT='" +
            total + "' and SHIP_INFO='" + shippingKey + "' and FULLFILLED='0';";
        DataTable dt3 = DataAccess.selectQuery(getKey);
        string orderKey = dt3.Rows[0]["ID"].ToString();

        //add to order products

        string orderProductsQuery = "";
        foreach (CartItem item in thisCart.Items)
        {
            orderProductsQuery = "INSERT INTO Order_Products (PID,OID,QTY)" +
                " VALUES ('" + item.ID + "','" + orderKey + "','" + item.Quantity + "');";
            DataAccess.selectQuery(orderProductsQuery);
        }
    }

    protected void PopulateShippingInfo()
    {
        lblShipName.Text = shippingInfo[0];
        lblShipAddOne.Text = shippingInfo[1];
        lblShipAddTwo.Text = shippingInfo[2];
        lblShipCity.Text = shippingInfo[3] + ", " + shippingInfo[8] + " " + shippingInfo[5];
    }
}