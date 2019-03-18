using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder("SearchResults.aspx?"
                    + "ID=" + tbId.Text + "?"
                    + "name=" + tbName.Text + "?"
                    + "minPrice=" + tbMinPrice.Text + "?"
                    + "maxPrice=" + tbMaxPrice.Text);


        if (cbBedroom.Checked || cbLivingRoom.Checked || cbKitchen.Checked)
            sb.Append("?room=");
        if (cbBedroom.Checked)
            sb.Append("Bedroom");
        if (cbLivingRoom.Checked)
            sb.Append("LivingRoom");
        if (cbKitchen.Checked)
            sb.Append("Kitchen");

        Response.Redirect(sb.ToString());
    }
}
