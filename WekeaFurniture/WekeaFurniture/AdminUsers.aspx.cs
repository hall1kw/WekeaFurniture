using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class AdminUsers : System.Web.UI.Page
{
    private static string myConnectionString;
    private static string id;

    static AdminUsers()
    {
        myConnectionString = WebConfigurationManager.ConnectionStrings["ProductsConnection"].ConnectionString;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UpdateGridView();
        }
    }

    protected void GridView1_PagingIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        UpdateGridView();
    }

    protected void GridViewShipping_PagingIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewShipping.PageIndex = e.NewPageIndex;
        GridViewShipping.DataSource = DataAccess.selectQuery("Select * from Shipping_Info where UID=" + id);
        GridViewShipping.DataBind();
    }

    protected void GridViewReviews_PagingIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewReviews.PageIndex = e.NewPageIndex;
        GridViewReviews.DataSource = DataAccess.selectQuery("Select * from Reviews where UID=" + id);
        GridViewReviews.DataBind();
    }
    
    protected void GridViewPaymentInfo_PagingIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewPaymentInfo.PageIndex = e.NewPageIndex;
        GridViewPaymentInfo.DataSource = DataAccess.selectQuery("Select * from Payment_Info where UID=" + id);
        GridViewPaymentInfo.DataBind();
    }
    
    protected void GridViewOrders_PagingIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewOrders.PageIndex = e.NewPageIndex;
        GridViewOrders.DataSource = DataAccess.selectQuery("Select * from Orders where UID=" + id);
        GridViewOrders.DataBind();
    }
    
    protected void SelectEvent(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex >= 0)
        {
            id = GridView1.SelectedRow.Cells[1].Text.ToString();
            GridViewShipping.DataSource = DataAccess.selectQuery("Select * from Shipping_Info where UID=" + id);
            GridViewShipping.DataBind();
            LinkButtonShipping.Visible = true;
            LinkButtonPaymentInfo.Visible = true;
            LinkButtonReviews.Visible = true;
            LinkButtonOrders.Visible = true;
            LinkButtonDelete.Visible = true;
        }
    }

    protected void LinkButtonShipping_Click(object sender, EventArgs e)
    {
        GridViewShipping.DataSource = DataAccess.selectQuery("Select * from Shipping_Info where UID=" + id);
        GridViewShipping.DataBind();
        MultiView1.ActiveViewIndex = 0;
    }

    protected void LinkButtonPaymentInfo_Click(object sender, EventArgs e)
    {
        GridViewPaymentInfo.DataSource = DataAccess.selectQuery("Select * from Payment_Info where UID=" + id);
        GridViewPaymentInfo.DataBind();
        MultiView1.ActiveViewIndex = 1;
    }

    protected void LinkButtonReviews_Click(object sender, EventArgs e)
    {
        GridViewReviews.DataSource = DataAccess.selectQuery("Select * from Reviews where UID=" + id);
        GridViewReviews.DataBind();
        MultiView1.ActiveViewIndex = 2;
    }

    protected void LinkButtonOrders_Click(object sender, EventArgs e)
    {
        GridViewOrders.DataSource = DataAccess.selectQuery("Select * from Orders where UID=" + id);
        GridViewOrders.DataBind();
        MultiView1.ActiveViewIndex = 3;
    }

    protected void LinkButtonDelete_Click(object sender, EventArgs e)
    {
        string sqlUser = "Delete from Users where ID=" + id;
        string sqlShippingInfo = "Delete from Shipping_Info where UID=" + id;
        string sqlPaymentInfo = "Delete from Payment_Info where UID=" + id;
        string sqlReviews = "Delete from Reviews where UID=" + id;
        string sqlOrders = "Delete from Orders where UID=" + id;
        string[] cmdStrings = { sqlOrders, sqlReviews, sqlPaymentInfo, sqlShippingInfo, sqlUser };
        
        SqlConnection conn = new SqlConnection(myConnectionString);
        conn.Open();
        SqlTransaction trans = conn.BeginTransaction();
        try
        {
            for (int i = 0; i < 5; i++)
            {
                SqlCommand cmd = new SqlCommand(cmdStrings[i], conn, trans);
                cmd.ExecuteNonQuery();
            }
            trans.Commit();
        }
        catch (Exception ex)
        {
            trans.Rollback();
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
        finally
        {
            Response.Redirect("AdminUsers.aspx");
        }
    }

    protected void GridView1_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string UserId = GridView1.SelectedRow.Cells[1].ToString();
        System.Diagnostics.Debug.WriteLine(UserId);
    }

    protected string Hide_Card(string card)
    {
        string new_card = "XXXX-XXXX-XXXX-";
        new_card += card.Substring(card.Length - 4);

        return new_card;
    }

    private void UpdateGridView()
    {
        GridView1.DataSource = DataAccess.selectQuery("Select * from Users");
        GridView1.DataBind();
    }

    protected void ProductButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminProducts.aspx");
    }

    protected void CustomerButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminUsers.aspx");
    }

}