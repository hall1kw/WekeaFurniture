﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = "5";
            dlProductDetail.DataSource = DataAccess.selectQuery("SELECT * FROM PRODUCTS WHERE ID=" + id);
            dlProductDetail.DataBind();
        }
    }
}