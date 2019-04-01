using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

public static class DataAccess
{
    private static string myConnectionString;

    static DataAccess()
    {
        myConnectionString = WebConfigurationManager.ConnectionStrings["ProductsConnection"].ConnectionString;
    }
    public static DataTable selectQuery(string query)
    {
        DataTable dt = new DataTable();
        SqlConnection cnn = new SqlConnection(myConnectionString);
        cnn.Open();
        SqlCommand cmd = new SqlCommand(query, cnn);
        dt.Load(cmd.ExecuteReader());
        cnn.Close();
        return dt;
    }

    public static void deleteQuery(string query)
    {
        SqlConnection cnn = new SqlConnection(myConnectionString);
        cnn.Open();
        SqlCommand cmd = new SqlCommand(query, cnn);
        cmd.ExecuteNonQuery();
        cnn.Close();
    }

    public static void insertQuery(string name, string image, double price, string description, int idcat, int idroom, int featured, bool taxable)
    {
        string sql = "INSERT INTO PRODUCTS (NAME, IMAGE, PRICE, DESCRIPTION, IDCAT, IDROOM, FEATURED, TAXABLE) values (@name, @image, @price, @description, @idcat, @idroom, @featured, @taxable)";
        using (SqlConnection cnn = new SqlConnection(myConnectionString))
        {
            using (SqlCommand cmm = new SqlCommand())
            {
                cmm.Connection = cnn;
                cmm.CommandType = CommandType.Text;
                cmm.CommandText = sql;
                cmm.Parameters.AddWithValue("@name", name);
                cmm.Parameters.AddWithValue("@image", image);
                cmm.Parameters.AddWithValue("@price", price);
                cmm.Parameters.AddWithValue("@description", description);
                cmm.Parameters.AddWithValue("@idcat", idcat);
                cmm.Parameters.AddWithValue("@idroom", idroom);
                cmm.Parameters.AddWithValue("@featured", featured);
                cmm.Parameters.AddWithValue("@taxable", taxable);
                try
                {
                    cnn.Open();
                    cmm.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine("\n");
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }
    }

    public static void updateQuery(int id, string name, string image, double price, string description, int idcat, int idroom, int featured, bool taxable)
    {
        string sql = "UPDATE PRODUCTS SET name=@name, image=@image, price=@price, description=@description, idcat=@idcat, idroom=@idroom, featured=@featured, taxable=@taxable WHERE id = @id";
        using (SqlConnection cnn = new SqlConnection(myConnectionString))
        {
            using (SqlCommand cmm = new SqlCommand())
            {
                cmm.Connection = cnn;
                cmm.CommandType = CommandType.Text;
                cmm.CommandText = sql;
                cmm.Parameters.AddWithValue("@id", id);
                cmm.Parameters.AddWithValue("@name", name);
                cmm.Parameters.AddWithValue("@image", image);
                cmm.Parameters.AddWithValue("@price", price);
                cmm.Parameters.AddWithValue("@description", description);
                cmm.Parameters.AddWithValue("@idcat", idcat);
                cmm.Parameters.AddWithValue("@idroom", idroom);
                cmm.Parameters.AddWithValue("@featured", featured);
                cmm.Parameters.AddWithValue("@taxable", taxable);
                try
                {
                    cnn.Open();
                    cmm.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine("\n");
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }
    }
 
}

