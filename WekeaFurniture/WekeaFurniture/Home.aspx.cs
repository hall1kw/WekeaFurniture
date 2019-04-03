using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["ID"];
            dlFeatured.DataSource = DataAccess.selectQuery("SELECT TOP 6 * FROM PRODUCTS WHERE FEATURED = 1 ORDER BY NEWID()");
            dlFeatured.DataBind();
        }
    }
}