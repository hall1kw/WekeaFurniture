using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string searchString = Request.QueryString["search"];
        string minPrice;
        string maxPrice;
        string minStars;
        string maxStars;
    }

    [System.Web.Services.WebMethod]
    public static Product GetProductByName(string n)
    {
        Product product = new Product();

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnection"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Select * From Products Where Name = %" + n + "%", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                product.id = reader["id"].ToString();
                product.name = reader["name"].ToString();
                product.price = Convert.ToDecimal(reader["price"]);
                product.description = reader["description"].ToString();
                product.imageurl = reader["imageurl"].ToString();
                product.quantity = Convert.ToInt32(reader["quantity"]);
            }
        }

        return product;
    }
}