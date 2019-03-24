using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductDetail : System.Web.UI.Page
{
    Cart thisCart;
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



    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        if (Session["thisCart"] == null)
        {
            thisCart = new Cart();
            Session["thisCart"] = thisCart;
        }
        string ID = Request.QueryString["ID"];
        thisCart = (Cart)Session["thisCart"];
        DataTable dt = DataAccess.selectQuery("SELECT * FROM PRODUCTS WHERE ID = " + ID);
        DataRow row = dt.Rows[0];
        thisCart.Insert(new CartItem(Int32.Parse(ID),
                row["NAME"].ToString(),
                row["Image"].ToString(),
                row["DESCRIPTION"].ToString(),
                Double.Parse(row["PRICE"].ToString()),
                1)
            );
    }
}