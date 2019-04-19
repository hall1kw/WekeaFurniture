using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GiftCard
/// </summary>
public class GiftCard
{
    public GiftCard()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static double GetGCbal(string cardNum)
    {
        DataTable dt = DataAccess.selectQuery("SELECT * FROM GiftCards WHERE GCnum = '" + cardNum + "';");
        DataRow row = dt.Rows[0];
        double gcBal = Double.Parse(row["Balance"].ToString());
        return gcBal;
    }

        // Returns 0 if the query returns the correct new balance
        // Returns -1 if it returns any other value
    public static int ModifyBalance(string cardNum, double amount)
    {
        DataTable dt = DataAccess.selectQuery("SELECT * FROM GiftCards WHERE GCnum = '" + cardNum + "';");
        DataRow row = dt.Rows[0];
        double gcBal = Double.Parse(row["Balance"].ToString());
        double newBal = gcBal + amount;
        string query = "UDPATE GiftCards SET Balance = " + newBal + " WHERE GCnum = '" + cardNum + "';");
        DataAccess.selectQuery(query);
        DataTable dtNew = DataAccess.selectQuery("SELECT * FROM GiftCards WHERE GCnum = '" + cardNum + "';");
        DataRow rowNew = dt.Rows[0];
        double gcBalNew = Double.Parse(row["Balance"].ToString());
        if (gcBalNew == gcBal + amount)
        {
            return 0;
        } else
        {
            return -1;
        }

    }
}