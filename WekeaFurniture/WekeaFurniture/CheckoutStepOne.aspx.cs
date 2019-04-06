using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CheckoutNew : System.Web.UI.Page
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
            Session["shippingInfo"] = new string[6];
            shippingInfo = (string[]) Session["shippingInfo"];
        }
        else
        {
            shippingInfo = (string[])Session["shippingInfo"];
        }
        FindFocus();
        if (!IsPostBack)
        {
            CheckShippingInfo();
            lblTax.Text = "";
            lblTotal.Text = "";
            dlCartSummary.DataSource = thisCart.Items;
            dlCartSummary.DataBind();

            ddlState.DataSource = DataAccess.selectQuery("SELECT * FROM SalesTax");
            ddlState.DataTextField = "STATENAME";
            ddlState.DataBind();

            lblSubtotal.Text = string.Format("Item's Subtotal: {0,19:C}", thisCart.GrandTotal);
        }
    }

    protected void CheckShippingInfo()
    {
        if (shippingInfo[0] != null)
        {
            txtFullName.Text = shippingInfo[0];
        }
        if (shippingInfo[1] != null)
        {
            txtAddressLn1.Text = shippingInfo[1];
        }
        if (shippingInfo[2] != null)
        {
            txtAddressLn2.Text = shippingInfo[2];
        }
        if (shippingInfo[3] != null)
        {
            txtCity.Text = shippingInfo[3];
        }
        if (shippingInfo[4] != null)
        {
            ddlState.SelectedIndex = Int32.Parse(shippingInfo[4]);
        }
        if (shippingInfo[5] != null)
        {
            txtZip.Text = shippingInfo[5];
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        txtFullName.Text = "";
        txtAddressLn1.Text = "";
        txtAddressLn2.Text = "";
        txtCity.Text = "";
        txtZip.Text = "";
        ddlState.SelectedIndex = 0;
        lblTax.Text = "";
        lblTotal.Text = "";
    }
    protected void CalcTax(object sender, EventArgs e)
    {
        if (ddlState.SelectedItem.ToString().Equals("--- Select state ---"))
        {
            Response.Write("<script>alert('Please select state!')</script>");
            lblTax.Text = "";
            lblTotal.Text = "";
            return;
        }
        else
        {
            DataTable dt = DataAccess.selectQuery("SELECT TAXRATE FROM SalesTax WHERE STATENAME = '" + ddlState.SelectedItem + "'");
            double tax = thisCart.GrandTotal * Double.Parse(dt.Rows[0][0].ToString());
            lblTax.Text = string.Format(ddlState.SelectedItem + " Tax: {0,19:C}", tax);
            lblTotal.Text = string.Format("Grand Total: {0,19:C}", tax + thisCart.GrandTotal);
            shippingInfo[4] = ddlState.SelectedIndex.ToString();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }

    protected void ShipNameChanged(object sender, EventArgs e)
    {
        shippingInfo[0] = "";
        shippingInfo[0] = txtFullName.Text;
    }
    protected void ShipAddLineOneChanged(object sender, EventArgs e)
    {
        shippingInfo[1] = "";
        shippingInfo[1] = txtAddressLn1.Text;
    }
    protected void ShipAddLineTwoChanged(object sender, EventArgs e)
    {
        shippingInfo[2] = "";
        shippingInfo[2] = txtAddressLn2.Text;
    }
    protected void ShipCityChanged(object sender, EventArgs e)
    {
        shippingInfo[3] = "";
        shippingInfo[3] = txtCity.Text;
    }
    protected void ShipZipChanged(object sender, EventArgs e)
    {
        shippingInfo[5] = "";
        shippingInfo[5] = txtZip.Text;
    }

    protected void FindFocus()
    {
        if (txtFullName.Text.Equals("")){
            txtFullName.Focus();
        } else if (txtAddressLn1.Text.Equals(""))
        {
            txtAddressLn1.Focus();
        } else if (txtAddressLn2.Text.Equals("") && txtCity.Text.Equals(""))
        {
            txtAddressLn2.Focus();
        } else if (txtCity.Text.Equals(""))
        {
            txtCity.Focus();
        } else if (ddlState.SelectedItem.ToString().Equals("--- Select state ---"))
        {
            ddlState.Focus();
        }
        else if (txtZip.Equals(""))
        {
            txtZip.Focus();
        }
        
    }
}