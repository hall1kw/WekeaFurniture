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

        if (cbSameAsBilling.Checked.ToString().Equals("False"))
        {
            ClearBilling();
            txtBillName.Text = "";
            txtBillAddOne.Text = "";
            txtBillAddTwo.Text = "";
            txtBillCity.Text = "";
            ddlBillState.SelectedIndex = 0;
            txtBillZip.Text = "";
        }
        if (!IsPostBack)
        {
            lblTax.Text = shippingInfo[6];
            lblTotal.Text = shippingInfo[7];
            lblShipping.Text = shippingInfo[9];
            dlCartSummary.DataSource = thisCart.Items;
            dlCartSummary.DataBind();
            lblSubtotal.Text = string.Format("Item's Subtotal: {0,19:C}", thisCart.GrandTotal);
            DisplayPaymentInput(false);
            PopulateStateDDL();
            PopulatePymtMethodsDDL();
        }
    }

    protected void ChoosePaymentAction(object sender, EventArgs e)
    {
        if (ddlPaymentMethod.SelectedItem.ToString().Equals("Credit Card"))
        {           
            lblCardName.Text = "Full name on card: ";
            lblCardNum.Text = "Card Number: ";
            lblExpDat.Text = "Card Exp Date: ";
            lblCardCVV.Text = "Card CVV / CVC: ";
            DisplayPaymentInput(true);
            imgPaypal.Visible = false;
        }
        if (ddlPaymentMethod.SelectedItem.ToString().Equals("PayPal"))
        {
            DisplayPaymentInput(false);
            imgPaypal.Visible = true;
        }
        if (ddlPaymentMethod.SelectedItem.ToString().Equals("WeKea Store Gift Card"))
        {
            DisplayPaymentInput(false);

            lblCardNum.Visible = true;
            lblCardNum.Text = "Gift Card Number: ";
            txtCardNum.Visible = true;
        }
    }

    protected void ClearBilling()
    {
        txtBillName.Text = "";
        txtBillAddOne.Text = "";
        txtBillAddTwo.Text = "";
        txtBillCity.Text = "";
        ddlBillState.SelectedIndex = 0;
        txtBillZip.Text = "";
    }

    protected void PopulatePymtMethodsDDL()
    {
        ddlPaymentMethod.DataSource = DataAccess.selectQuery("SELECT * FROM PaymentMethods");
        ddlPaymentMethod.DataTextField = "METHOD_NAME";
        ddlPaymentMethod.DataValueField = "ID";
        ddlPaymentMethod.DataBind();
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
        imgPaypal.Visible = input;
        lblBillingName.Visible = input; 
        lblCardName.Visible = input;
        lblCardNum.Visible = input;
        lblCity.Visible = input;
        lblExpDat.Visible = input;
        lblStAddOne.Visible = input;
        lblStAddTwo.Visible = input;
        lblState.Visible = input;
        lblZip.Visible = input;
        lblCardCVV.Visible = input;
        txtCVV.Visible = input;
        lblBillingInfo.Visible = input;
        txtCardName.Visible = input;
        txtCardNum.Visible = input;
        txtExpMo.Visible = input;
        txtExpYr.Visible = input;
        lblSlash.Visible = input;
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

    protected void btnChange_Click(object sender, EventArgs e)
    {
        Response.Redirect("/CheckoutStepOne.aspx");
    }

    protected void btnConfirmOrder_Click(object sender, EventArgs e)
    {
        string[] paymentInfo = new string[6];
        if (ddlPaymentMethod.SelectedItem.ToString().Equals("Credit Card"))
        {
            paymentInfo[0] = txtCardName.Text;
            paymentInfo[1] = txtCardNum.Text;
            paymentInfo[2] = txtExpMo.Text;
            paymentInfo[3] = txtExpYr.Text;
            paymentInfo[4] = "0";
            paymentInfo[5] = txtCVV.Text;
        } else
        {
            paymentInfo[0] = "0";
            paymentInfo[1] = "0";
            paymentInfo[2] = "0";
            paymentInfo[3] = "0";
            paymentInfo[4] = "1";
            paymentInfo[5] = "0";
        }
        Session["paymentInfo"] = paymentInfo;
        Response.Redirect("/Confirmation.aspx");
    }
}