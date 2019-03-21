using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["ID"];
            dlProductDetail.DataSource = DataAccess.selectQuery("SELECT * FROM PRODUCTS WHERE ID=" + id);
            dlProductDetail.DataBind();

            dlDetailFeat.DataSource = DataAccess.selectQuery("SELECT TOP 2 * FROM PRODUCTS WHERE FEATURED = 1 ORDER BY NEWID()");
            dlDetailFeat.DataBind();
        }
    }
}