using System;
using System.Data;
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
            if (id == null) id = "";
            string name = Request.QueryString["Name"];
            if (name == null) name = "";
            string minPrice = Request.QueryString["minP"];
            if (minPrice == null) minPrice = "";
            string maxPrice = Request.QueryString["maxP"];
            if (maxPrice == null) maxPrice = "";
            string room = Request.QueryString["Rm"];
            if (room == null) room = "";
            string category = Request.QueryString["Cat"];
            if (category == null) category = "";

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
            if (room.Contains("Kitchen") && command.ToString().Equals("SELECT * FROM PRODUCTS WHERE "))
            {
                command.Append("IDROOM = 1");
            } else if (room.Contains("Kitchen"))
            {
                command.Append("AND IDROOM = 1 ");
            }
            if (room.Contains("LivingRoom") && command.ToString().Equals("SELECT * FROM PRODUCTS WHERE "))
            {
                command.Append("IDROOM = 2 ");
            }
            else if (room.Contains("LivingRoom") && ((room.Contains("Kitchen") || (room.Contains("BedRoom")))))
            {
                command.Append("OR IDROOM = 2 ");
            }
            else if (room.Contains("LivingRoom"))
            {
                command.Append("AND IDROOM = 2 ");
            }
            if (room.Contains("Bedroom") && command.ToString().Equals("SELECT * FROM PRODUCTS WHERE "))
            {
                command.Append("IDROOM = 3 ");
            }
            else if (room.Contains("Bedroom") && ((room.Contains("Kitchen") || (room.Contains("LivingRoom")))))
            {
                command.Append("OR IDROOM = 3 ");
            }
            else if (room.Contains("Bedroom"))
            {
                command.Append("AND IDROOM = 3");
            }
            if (category != "")
            {
                if (!(command.ToString().Equals("SELECT * FROM PRODUCTS WHERE ")))
                {
                    command.Append("AND (");
                }
                if (category.Contains("Chairs") && (command.ToString().EndsWith("AND (") || command.ToString().EndsWith("WHERE ")))
                {
                    command.Append(" IDCAT=1");
                } 
                if (category.Contains("Couches") && (command.ToString().EndsWith("AND (") || command.ToString().EndsWith("WHERE ")))
                {
                    command.Append(" IDCAT=2");
                } else if (category.Contains("Couches"))
                {
                    command.Append(" OR IDCAT=2");
                }
                if (category.Contains("Tables") && (command.ToString().EndsWith("AND (") || command.ToString().EndsWith("WHERE ")))
                {
                    command.Append(" IDCAT=3");
                }
                else if (category.Contains("Tables"))
                {
                    command.Append(" OR IDCAT=3");
                }
                if (category.Contains("Dressers") && (command.ToString().EndsWith("AND (") || command.ToString().EndsWith("WHERE ")))
                {
                    command.Append(" IDCAT=4");
                }
                else if (category.Contains("Dressers"))
                {
                    command.Append(" OR IDCAT=4");
                }
                if (category.Contains("Beds") && (command.ToString().EndsWith("AND (") || command.ToString().EndsWith("WHERE ")))
                {
                    command.Append(" IDCAT=5");
                }
                else if (category.Contains("Beds"))
                {
                    command.Append(" OR IDCAT=5");
                }
                if (category.Contains("Lamps") && (command.ToString().EndsWith("AND (") || command.ToString().EndsWith("WHERE ")))
                {
                    command.Append(" IDCAT=6");
                }
                else if (category.Contains("Lamps"))
                {
                    command.Append(" OR IDCAT=6");
                }
                if (category.Contains("Desks") && (command.ToString().EndsWith("AND (") || command.ToString().EndsWith("WHERE ")))
                {
                    command.Append(" IDCAT=7");
                }
                else if (category.Contains("Desks"))
                {
                    command.Append(" OR IDCAT=7");
                }
                if (command.ToString().Contains("AND ("))
                    command.Append(")");
            }

            dlSearchResults.DataSource = DataAccess.selectQuery(command.ToString());
            dlSearchResults.DataBind();

            float count = dlSearchResults.Items.Count;
            int finalCount;
            if (count <= 5) finalCount = 1;
            else if (count % 5 == 0) finalCount = (int) count / 5;
            else finalCount = (int) count / 5 + 1;

            dlSearchResFeat.DataSource = DataAccess.selectQuery("SELECT TOP " + finalCount + " * FROM PRODUCTS WHERE FEATURED = 1 ORDER BY NEWID()");
            dlSearchResFeat.DataBind();





        }
    }
}