using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartyStreets;
using SmartyStreets.USStreetApi;

public partial class AddressVerification : System.Web.UI.Page
{
    protected string[] shippingInfo;
    protected string city;
    protected string state;
    protected string zip;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        shippingInfo = (string[])Session["shippingInfo"];
        if (IsPostBack && shippingInfo != null)
        {
            VerifyAddress();
            PopulateOriginal();
        }
    }

    protected void PopulateOriginal()
    {
        lblName.Text = shippingInfo[0];
        lblAddOne.Text = shippingInfo[2];
        lblAddTwo.Text = shippingInfo[1];
        lblCityState.Text = shippingInfo[3] + ", " + shippingInfo[8];
        lblZip.Text = shippingInfo[5];
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
            lblName0.Text = (ex.Message);
            lblAddOne0.Text = (ex.StackTrace);
        }
        catch (System.IO.IOException ex)
        {
            lblName0.Text = "There was an error validating your address";
        }

        var candidates = lookup.Result;

        if (candidates.Count == 0)
        {
            lblName0.Text = "The USPS could not verify your address";
        }

        var firstCandidate = candidates[0];

        lblName0.Text = shippingInfo[0];
        lblAddOne0.Text = firstCandidate.Components.SecondaryDesignator + " " + firstCandidate.Components.SecondaryNumber;
        lblAddTwo0.Text = firstCandidate.Components.PrimaryNumber + " " + firstCandidate.Components.StreetPredirection + " " + firstCandidate.Components.StreetName + " " + firstCandidate.Components.StreetSuffix + " " + firstCandidate.Components.StreetPostdirection;

        lblCityState0.Text = firstCandidate.Components.CityName + ", " + firstCandidate.Components.State;

        lblZip0.Text = firstCandidate.Components.ZipCode + "-" + firstCandidate.Components.Plus4Code;
        state = firstCandidate.Components.State;
        city = firstCandidate.Components.CityName;
        zip = firstCandidate.Components.ZipCode + "-" + firstCandidate.Components.Plus4Code;
    }

    protected void UseNew(object sender, EventArgs e)
    {
        shippingInfo[1] = lblAddOne0.Text;
        shippingInfo[2] = lblAddTwo0.Text;
        shippingInfo[3] = city;
        shippingInfo[8] = state;
        shippingInfo[5] = zip;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
    }
}