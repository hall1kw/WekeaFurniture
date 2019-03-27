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
        string sql = "SELECT ID, NAME, PRICE, IMAGEURL, IDCAT, IDROOM, FEATURED, TAXABLE FROM Products";

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
                    product.ID = rdr["ID"].ToString();
                    product.NAME = rdr["NAME"].ToString();
                    product.PRICE = Convert.ToDecimal(rdr["PRICE"]);
                    product.IMAGEURL = rdr["IMAGE"].ToString();
                    product.IDCAT = rdr["IDCAT"].ToString();
                    product.IDROOM = rdr["IDROOM"].ToString();
                    product.FEATURED = rdr["FEATURED"].ToString();
                    product.TAXABLE = rdr["TAXABLE"].ToString();
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
            "SET name = @name " +
            "SET price = @price" +
            "SET imageurl = @imageurl" +
            "SET idcat = @idcat" +
            "SET idroom = @idroom" +
            "SET featured = @featured" +
            "SET taxable = @taxable" +
            "WHERE ProductID = @original_ProductID";

        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@name", product.NAME);
                cmd.Parameters.AddWithValue("@price", product.PRICE);
                cmd.Parameters.AddWithValue("@imageurl", product.IMAGEURL);
                cmd.Parameters.AddWithValue("@idcat", product.IDCAT);
                cmd.Parameters.AddWithValue("@idroom", product.IDROOM);
                cmd.Parameters.AddWithValue("@featured", product.FEATURED);
                cmd.Parameters.AddWithValue("@taxable", product.TAXABLE);
                cmd.Parameters.AddWithValue("@original_ProductID", product.ID);
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