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
            string minPrice = Request.QueryString["minPrice"];
            string maxPrice = Request.QueryString["maxPrice"];
            string room = Request.QueryString["room"];
            string category = Request.QueryString["category"];

            StringBuilder command = new StringBuilder("SELECT * FROM PRODUCTS WHERE ");

            if (!id.Equals(""))
            {
                command.Append("ID=" + id);
            }
            if (!name.Equals("") && command.ToString().Equals("SELECT * FROM PRODUCTS WHERE "))
            {
                command.Append("NAME LIKE '*" + name + "*'");
            }

            dlSearchResults.DataSource = DataAccess.selectQuery(command.ToString());
            dlSearchResults.DataBind();



        }
    }
}