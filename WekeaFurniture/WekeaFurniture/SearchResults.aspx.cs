using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        string name = Request.QueryString["name"];
        string minPrice = Request.QueryString["minPrice"];
        string maxPrice = Request.QueryString["maxPrice"];
        string room = Request.QueryString["room"];
        string category = Request.QueryString["category"];


    }
}