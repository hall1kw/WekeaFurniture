using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProductDetail : System.Web.UI.Page
{
    static String id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            id = Request.QueryString["ID"];
            dlProductDetail.DataSource = DataAccess.selectQuery("SELECT * FROM PRODUCTS WHERE ID=" + id);
            dlProductDetail.DataBind();

            dlDetailFeat.DataSource = DataAccess.selectQuery("SELECT TOP 2 * FROM PRODUCTS WHERE FEATURED = 1 ORDER BY NEWID()");
            dlDetailFeat.DataBind();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ShoppingCart thisCart = (ShoppingCart)Session["thisCart"];
        if (thisCart == null)
        {
            thisCart = new ShoppingCart();
            Session["thisCart"] = thisCart;
        }
        CartItem item = new CartItem();

        DataTable dt = DataAccess.selectQuery("SELECT * FROM PRODUCTS WHERE ID =" + id);

        DataRow row = dt.Rows[0];

        thisCart.Insert(new CartItem(Int32.Parse(id),
        row["NAME"].ToString(),
        row["Image"].ToString(),
        row["DESCRIPTION"].ToString(),
        Double.Parse(row["PRICE"].ToString()), 1));

    }
}