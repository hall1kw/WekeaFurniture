using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SmartyStreets;
using SmartyStreets.USStreetApi;

public partial class CheckoutNew : System.Web.UI.Page
{
    protected ShoppingCart thisCart;
    protected string[] shippingInfo;
    protected double tax;
    protected static bool AddressChecked;
    protected static string city;
    protected static string state;
    protected static string zip;
    protected static double shipping;

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
            Session["shippingInfo"] = new string[9];
            shippingInfo = (string[]) Session["shippingInfo"];
        }
        else
        {
            shippingInfo = (string[])Session["shippingInfo"];
        }
        FindFocus();
        if (!IsPostBack)
        {
            AddressChecked = false;
            CheckShippingInfo();
            lblTax.Text = "";
            lblTotal.Text = "";
            dlCartSummary.DataSource = thisCart.Items;
            dlCartSummary.DataBind();

            ddlState.DataSource = DataAccess.selectQuery("SELECT * FROM SalesTax");
            ddlState.DataTextField = "STATENAME";
            ddlState.DataBind();

            lblSubtotal.Text = string.Format("Item's Subtotal: {0,19:C}", thisCart.GrandTotal);
            if (shippingInfo[4] != null)
            {
                CalcTax(this, EventArgs.Empty);
            }
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
        if (shippingInfo[6] != null)
        {
            lblTax.Text = shippingInfo[6];
        }
        if (shippingInfo[7] != null)
        {
            lblTotal.Text = shippingInfo[7];
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
        Session["shippingInfo"] = new string[9];
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
            tax = thisCart.GrandTotal * Double.Parse(dt.Rows[0][0].ToString());
            lblTax.Text = string.Format(ddlState.SelectedItem + " Tax: {0,19:C}", tax);
            lblTotal.Text = string.Format("Grand Total: {0,19:C}", tax + thisCart.GrandTotal + shipping);
            shippingInfo[4] = ddlState.SelectedIndex.ToString();
            shippingInfo[8] = ddlState.SelectedItem.ToString();
            AddressChecked = false;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (!AddressChecked)
        {

        }
        shippingInfo[6] = lblTax.Text.ToString();
        shippingInfo[7] = lblTotal.Text.ToString();
        Response.Redirect("/CheckoutStepTwo.aspx");
    }

    protected void ShipNameChanged(object sender, EventArgs e)
    {
        shippingInfo[0] = "";
        shippingInfo[0] = txtFullName.Text;
        AddressChecked = false;
    }
    protected void ShipAddLineOneChanged(object sender, EventArgs e)
    {
        shippingInfo[1] = "";
        shippingInfo[1] = txtAddressLn1.Text;
        AddressChecked = false;
    }
    protected void ShipAddLineTwoChanged(object sender, EventArgs e)
    {
        shippingInfo[2] = "";
        shippingInfo[2] = txtAddressLn2.Text;
        AddressChecked = false;
    }
    protected void ShipCityChanged(object sender, EventArgs e)
    {
        shippingInfo[3] = "";
        shippingInfo[3] = txtCity.Text;
        AddressChecked = false;
    }
    protected void ShipZipChanged(object sender, EventArgs e)
    {
        shippingInfo[5] = "";
        shippingInfo[5] = txtZip.Text;
        AddressChecked = false;
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

    protected void PopulateOriginal()
    {
        lblNameOrig.Text = shippingInfo[0];
        lblAddOneOrig.Text = shippingInfo[1];
        lblAddTwoOrig.Text = shippingInfo[2];
        lblCityStateOrig.Text = shippingInfo[3] + ", " + shippingInfo[8];
        lblZipOrig.Text = shippingInfo[5];
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        // Need to check that shipping info is filled out...
        // Check to see if Address has been checked, if so, redirect to step two
        if (AddressChecked)
        {
            shippingInfo[6] = lblTax.Text.ToString();
            shippingInfo[7] = lblTotal.Text.ToString();
            Response.Redirect("/CheckoutStepTwo.aspx");
        } else
        {
            // Use the textbox data to verify information
            shippingInfo[0] = txtFullName.Text;
            shippingInfo[1] = txtAddressLn1.Text;
            shippingInfo[2] = txtAddressLn2.Text;
            shippingInfo[3] = txtCity.Text;
            shippingInfo[8] = ddlState.SelectedItem.ToString();
            shippingInfo[5] = txtZip.Text;
            // Call VerifyAddress to get corrected address
            PopulateOriginal();
            VerifyAddress();
            AddressChecked = true;
            mp1.Show();
        }
        // Else...
        // Apply response from USPS to labels in popup
        // Set checked bool to true
        // Call popup
        // Two buttons - Use Original, Use New
        // Use Original... Do nothing to data, return to shipping, enable a button for "Save to user account"
        // Use New... Update data in text fields, enable "Save to user account"
    }

    protected void VerifyAddress()
    {
        //var authId = Environment.GetEnvironmentVariable();
        //var authToken = Environment.GetEnvironmentVariable();

        var client = new ClientBuilder("e38b07fa-c959-cb34-2e18-2751a7a92b6e", "DtZammOdOius2BZC7J3M")
        //.ViaProxy("http://localhost:8080", "username", "password") // uncomment this line to point to the specified proxy.
        .BuildUsStreetApiClient();

        // Documentation for input fields can be found at:
        // https://smartystreets.com/docs/us-street-api#input-fields

        var lookup = new Lookup
        {
            Street = shippingInfo[1],
            Street2 = "",
            Secondary = shippingInfo[2],
            Urbanization = "", // Only applies to Puerto Rico addresses
            City = shippingInfo[3],
            State = shippingInfo[8],
            ZipCode = shippingInfo[5],
            MaxCandidates = 1,
            MatchStrategy = Lookup.INVALID // "invalid" is the most permissive match
        };

        try
        {
            client.Send(lookup);
        }
        catch (SmartyException ex)
        {
            lblNameNew.Text = (ex.Message);
            lblAddOneNew.Text = (ex.StackTrace);
        }
        catch (System.IO.IOException ex)
        {
            lblNameNew.Text = "There was an error validating your address";
        }

        var candidates = lookup.Result;

        if (candidates.Count == 0)
        {
            lblNameNew.Text = "The USPS could not verify your address";
        }

        var firstCandidate = candidates[0];

        lblNameNew.Text = shippingInfo[0];
        lblAddOneNew.Text = firstCandidate.DeliveryLine1;
        lblAddTwoNew.Text = firstCandidate.DeliveryLine2;

        lblCityStateNew.Text = firstCandidate.Components.CityName + ", " + firstCandidate.Components.State;

        lblZipNew.Text = firstCandidate.Components.ZipCode + "-" + firstCandidate.Components.Plus4Code;
        state = firstCandidate.Components.State;
        city = firstCandidate.Components.CityName;
        zip = firstCandidate.Components.ZipCode + "-" + firstCandidate.Components.Plus4Code;
    }

    protected void UseNew(object sender, EventArgs e)
    {
        shippingInfo[1] = lblAddOneNew.Text;
        txtAddressLn1.Text = lblAddOneNew.Text;
        shippingInfo[2] = lblAddTwoNew.Text;
        txtAddressLn2.Text = lblAddTwoNew.Text;
        shippingInfo[3] = city;
        txtCity.Text = city;
        shippingInfo[8] = state;
        shippingInfo[5] = zip;
        txtZip.Text = zip;
        AddressChecked = true;
        Session["shippingInfo"] = shippingInfo;
    }

    protected void UseOrig(object sender, EventArgs e)
    {
        AddressChecked = true;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlShipping.SelectedValue.ToString().Equals("50"))
        {
            lblShipping.Text = "Shipping Cost: $50.00";
            shipping = 50.00;
            if (ddlState.SelectedIndex != 0)
            {
                CalcTax(this, EventArgs.Empty);
            }
        } else
        {
            lblShipping.Text = "Shipping Cost: FREE";
            shipping = 0;
            if (ddlState.SelectedIndex != 0)
            {
                CalcTax(this, EventArgs.Empty);
            }
        }
    }
}