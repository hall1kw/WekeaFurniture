using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["ID"];
            dlSearchFeat.DataSource = DataAccess.selectQuery("SELECT TOP 2 * FROM PRODUCTS WHERE FEATURED=1 ORDER BY NEWID()");
            dlSearchFeat.DataBind();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
 
    }
}
