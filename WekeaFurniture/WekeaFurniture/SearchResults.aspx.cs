using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["PID"];
            string name = Request.QueryString["Name"];
            string minPrice = Request.QueryString["minP"];
            string maxPrice = Request.QueryString["maxP"];
            string room = Request.QueryString["Rm"];
            string category = Request.QueryString["Cat"];

            /*
             * KH - Construction of the SQL query.
             * ID and Name are or values and will return all that match either criteria.  
             * Pricing options are and statements and will restrict responses to match their values.
            */
            StringBuilder command = new StringBuilder("SELECT * FROM PRODUCTS WHERE ");
            
            if (!id.Equals(""))
            {
                command.Append("ID=" + id);
            }
            if (!name.Equals("") && command.ToString().Equals("SELECT * FROM PRODUCTS WHERE "))
            {
                command.Append(" NAME LIKE'%" + name +"%'");
            } else if (!name.Equals(""))
            {
                command.Append(" OR NAME LIKE'%" + name + "%'");
            }
            if (!minPrice.Equals("") && command.ToString().Equals("SELECT * FROM PRODUCTS WHERE "))
            {
                command.Append("Price >=" + minPrice);
            } else if (!minPrice.Equals(""))
            {
                command.Append(" AND Price >=" + minPrice);
            }
            if (!maxPrice.Equals("") && command.ToString().Equals("SELECT * FROM PRODUCTS WHERE "))
            {
                command.Append(" Price <=" + maxPrice);
            }
            else if (!maxPrice.Equals(""))
            {
                command.Append(" AND Price <=" + maxPrice);
            }
            if (room.Contains("Kitchen"))

            dlSearchResults.DataSource = DataAccess.selectQuery(command.ToString());
            dlSearchResults.DataBind();



        }
    }
}