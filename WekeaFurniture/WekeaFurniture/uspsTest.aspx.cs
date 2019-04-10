using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartyStreets;
using SmartyStreets.USStreetApi;

public partial class uspsTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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
            Street = "510 South University AVE",
            Street2 = "closet under the stairs",
            Secondary = "APT 2",
            Urbanization = "", // Only applies to Puerto Rico addresses
            City = "Mount Pleasant",
            State = "MI",
            ZipCode = "48858",
            MaxCandidates = 3,
            MatchStrategy = Lookup.INVALID // "invalid" is the most permissive match
        };

        try
        {
            client.Send(lookup);
        }
        catch (SmartyException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
        catch (System.IO.IOException ex)
        {
            Console.WriteLine(ex.StackTrace);
        }

        var candidates = lookup.Result;

        if (candidates.Count == 0)
        {
            System.Diagnostics.Debug.Write("No candidates. This means the address is not valid.");
            return;
        }

        var firstCandidate = candidates[0];

        System.Diagnostics.Debug.Write("Address is valid. (There is at least one candidate)\n");
        System.Diagnostics.Debug.Write("Delivery Point: " + firstCandidate.Components.PrimaryNumber + firstCandidate.Components.StreetPredirection + firstCandidate.Components.StreetName);
        System.Diagnostics.Debug.Write("Street: " + firstCandidate.Components.StreetPredirection);
        System.Diagnostics.Debug.Write("City: " + firstCandidate.Components.ZipCode);
        System.Diagnostics.Debug.Write("ZIP Code: " + firstCandidate.Components.ZipCode);
        System.Diagnostics.Debug.Write("County: " + firstCandidate.Metadata.CountyName);
        System.Diagnostics.Debug.Write("Latitude: " + firstCandidate.Metadata.Latitude);
        System.Diagnostics.Debug.Write("Longitude: " + firstCandidate.Metadata.Longitude);
    }
}
