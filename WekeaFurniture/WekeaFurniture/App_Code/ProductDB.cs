using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ProductDB
/// </summary>
[DataObject]
public class ProductDB
{
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<AdminProduct> GetProducts()
    {
        List<AdminProduct> productList = new List<AdminProduct>();
        string sql = "SELECT ID, NAME, PRICE, IMAGE, IDCAT, IDROOM, FEATURED, TAXABLE FROM Products";

        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                AdminProduct product;
                while (rdr.Read())
                {
                    product = new AdminProduct();
                    product.id = rdr["ID"].ToString();
                    product.name = rdr["NAME"].ToString();
                    product.price = Convert.ToDecimal(rdr["PRICE"]);
                    product.image = rdr["IMAGE"].ToString();
                    product.idcat = rdr["IDCAT"].ToString();
                    product.idroom = rdr["IDROOM"].ToString();
                    product.featured = rdr["FEATURED"].ToString();
                    product.taxable = rdr["TAXABLE"].ToString();
                    productList.Add(product);
                }
                rdr.Close();
                return productList;

            } // dispose of command object
        } // close connection and dispose of object     
    }

    [DataObjectMethod(DataObjectMethodType.Update)]
    public static void UpdateProduct(AdminProduct product)
    {
        string sql =
            "UPDATE Products " +
            "SET name = @name, " +
            "price = @price, " +
            "image = @image, " +
            "idcat = @idcat, " +
            "idroom = @idroom, " +
            "featured = @featured, " +
            "taxable = @taxable " +
            "WHERE id = @id";

        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", product.id);
                cmd.Parameters.AddWithValue("@name", product.name);
                cmd.Parameters.AddWithValue("@image", product.image);
                cmd.Parameters.AddWithValue("@price", product.price);
                cmd.Parameters.AddWithValue("@idcat", product.idcat);
                cmd.Parameters.AddWithValue("@idroom", product.idroom);
                cmd.Parameters.AddWithValue("@featured", product.featured);
                cmd.Parameters.AddWithValue("@taxable", product.taxable);
                con.Open();
                cmd.ExecuteNonQuery();

            } // dispose of command object
        } // close connection and dispose of object     
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings[
            "ProductsConnection"].ConnectionString;
    }
}