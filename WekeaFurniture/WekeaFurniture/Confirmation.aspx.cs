using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        }

        if (!IsPostBack)
        {
            lblTax.Text = shippingInfo[6];
            lblTotal.Text = shippingInfo[7];
            dlCartSummary.DataSource = thisCart.Items;
            dlCartSummary.DataBind();
            lblSubtotal.Text = string.Format("Item's Subtotal: {0,19:C}", thisCart.GrandTotal);

            Session["thisCart"] = null;
        }
    }

    protected void UpdateItemStock()
    {

    }

    protected void PopulateShippingInfo()
    {
        lblShipName.Text = shippingInfo[0];
        lblShipAddOne.Text = shippingInfo[1];
        lblShipAddTwo.Text = shippingInfo[2];
        lblShipCity.Text = shippingInfo[3] + ", " + shippingInfo[8] + " " + shippingInfo[5];
    }
}