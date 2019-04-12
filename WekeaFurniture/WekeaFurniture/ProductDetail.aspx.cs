using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProductDetail : System.Web.UI.Page
{
    static String id;
    protected static DataTable dt;
    protected static DataRow row;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            id = Request.QueryString["ID"];
            dt = DataAccess.selectQuery("SELECT * FROM PRODUCTS WHERE ID=" + id);
            row = dt.Rows[0];
            dlProductDetail.DataSource = dt;
            dlProductDetail.DataBind();
            
            dlDetailFeat.DataSource = DataAccess.selectQuery("SELECT TOP 2 * FROM PRODUCTS WHERE FEATURED = 1 ORDER BY NEWID()");
            dlDetailFeat.DataBind();            
            lblThankYou.Text = "We've added: " + row["NAME"] + " to your shopping cart!";
            lblOutOfStock.Text = "We're sorry, " + row["NAME"] + " is out of stock.";
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        CartItem item = new CartItem();

        DataTable dt = DataAccess.selectQuery("SELECT * FROM PRODUCTS WHERE ID =" + id);

        DataRow row = dt.Rows[0];

        if (Int32.Parse(row["INVENTORY"].ToString()) != 0)
        {
            ShoppingCart thisCart = (ShoppingCart)Session["thisCart"];
            if (thisCart == null)
            {
                thisCart = new ShoppingCart();
                Session["thisCart"] = thisCart;
            }

            thisCart.Insert(new CartItem(Int32.Parse(id), row["NAME"].ToString(), row["Image"].ToString(), row["DESCRIPTION"].ToString(), Double.Parse(row["PRICE"].ToString()), 1, Int32.Parse(row["INVENTORY"].ToString())));

            mp1.Show();
        } else
        {
            ModalPopupExtender1.Show();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        int stars = RadioButtonList1.SelectedIndex + 1;
        string review = TextBox1.Text;
        string user = "1"; //(string) Session["user"];
        Boolean validation = true;
        if(user != "")
        {
            user = (string) Session["userLoggedIn"];
            string joinquery = "SELECT Order_Products.ID" +
                "FROM ((Order_Products " +
                "INNER JOIN Orders ON Orders.ID = Order_Products.OID) " +
                "INNER JOIN Users ON Users.ID = Order_Products.UID) " +
                "WHERE Users.ID = '" + user + "' AND Order_Products.PID = '" + id + "';" ;
        }

        //validate if a user is logged in and if they have actually ordered this product
        if(stars != 0 && review != "" && validation)
        {
            RadioButtonList1.SelectedIndex = -1;
            TextBox1.Text = "";
            string query = "INSERT INTO Reviews (PID, UID, Rating, Review) VALUES ('"
                + id + "','" + user + "','" + stars + "','" + review + "')";
            DataAccess.insertQuery(query);
        } else
        {

        }
    }

    protected void btnCancelControl_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.Write("at line 46");
        Response.Redirect(Request.RawUrl);
        mp1.Dispose();
    }
}