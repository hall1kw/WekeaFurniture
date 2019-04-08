using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CheckoutStepTwo : System.Web.UI.Page
{
    protected ShoppingCart thisCart;
    protected string[] shippingInfo;
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
        FindFocus();
        if (!IsPostBack)
        {
            lblTax.Text = shippingInfo[6];
            lblTotal.Text = shippingInfo[7];
            dlCartSummary.DataSource = thisCart.Items;
            dlCartSummary.DataBind();
            lblSubtotal.Text = string.Format("Item's Subtotal: {0,19:C}", thisCart.GrandTotal);
            //DisplayPaymentInput(false);
            PopulateStateDDL();
        }
    }

    protected void ChoosePaymentAction(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.Write("In Choose Payment Action");
        lblBillingName.Visible = true;
        lblCardName.Text = "Full name on card";
        DisplayPaymentInput(true);
    }

    protected void PopulateStateDDL()
    {
        ddlBillState.DataSource = DataAccess.selectQuery("SELECT * FROM SalesTax");
        ddlBillState.DataTextField = "STATENAME";
        ddlBillState.DataBind();
    }

    protected void SameAsBilling(object sender, EventArgs e)
    {
        txtBillName.Text = shippingInfo[0];
        txtBillAddOne.Text = shippingInfo[1];
        txtBillAddTwo.Text = shippingInfo[2];
        txtBillCity.Text = shippingInfo[3];
        ddlBillState.SelectedIndex = (Int32.Parse(shippingInfo[4]) - 1);
        txtBillZip.Text = shippingInfo[5];
    }

    protected void DisplayPaymentInput(bool input)
    {
        lblBillingName.Visible = input;        
        lblCardNum.Visible = input;
        lblCity.Visible = input;
        lblExpDat.Visible = input;
        lblStAddOne.Visible = input;
        lblStAddTwo.Visible = input;
        lblState.Visible = input;
        lblZip.Visible = input;
        txtBillAddOne.Visible = input;
        txtBillAddTwo.Visible = input;
        txtBillCity.Visible = input;
        txtBillName.Visible = input;
        txtBillZip.Visible = input;
        ddlBillState.Visible = input;
        cbSameAsBilling.Visible = input;
    }

    protected void PopulateShippingInfo()
    {
        lblShipName.Text = shippingInfo[0];
        lblShipAddOne.Text = shippingInfo[1];
        lblShipAddTwo.Text = shippingInfo[2];
        lblShipCity.Text = shippingInfo[3] + ", " + shippingInfo[8] + " " + shippingInfo[5];       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {

    }

    

    protected void FindFocus()
    {
        

    }

    protected void btnChange_Click(object sender, EventArgs e)
    {
        Response.Redirect("/CheckoutStepOne.aspx");
    }
}