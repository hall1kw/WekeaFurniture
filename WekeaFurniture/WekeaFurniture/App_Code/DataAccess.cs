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

    public static void insertQuery(string query)
    {
        SqlConnection cnn = new SqlConnection(myConnectionString);
        cnn.Open();
        SqlCommand cmd = new SqlCommand(query, cnn);
        cmd.ExecuteNonQuery();
        cnn.Close();
    }
}

