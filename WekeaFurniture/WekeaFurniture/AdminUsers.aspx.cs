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
        UpdateGridViewShipping();
    }

    protected void GridViewReviews_PagingIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewReviews.PageIndex = e.NewPageIndex;
        UpdateGridViewReviews();
    }
    
    protected void GridViewPaymentInfo_PagingIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewPaymentInfo.PageIndex = e.NewPageIndex;
        UpdateGridViewPayment();
    }
    
    protected void GridViewOrders_PagingIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewOrders.PageIndex = e.NewPageIndex;
        UpdateGridViewOrders();
    }
    
    protected void SelectEvent(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex >= 0)
        {
            id = GridView1.SelectedRow.Cells[1].Text.ToString();
            UpdateGridViewShipping();
            MultiView1.ActiveViewIndex = 0;
            LinkButtonShipping.Visible = true;
            LinkButtonPaymentInfo.Visible = true;
            LinkButtonReviews.Visible = true;
            LinkButtonOrders.Visible = true;
            LinkButtonDelete.Visible = true;
        }
    }

    protected void LinkButtonShipping_Click(object sender, EventArgs e)
    {
        UpdateGridViewShipping();
        MultiView1.ActiveViewIndex = 0;
    }

    protected void LinkButtonPaymentInfo_Click(object sender, EventArgs e)
    {
        UpdateGridViewPayment();
        MultiView1.ActiveViewIndex = 1;
    }

    protected void LinkButtonReviews_Click(object sender, EventArgs e)
    {
        UpdateGridViewReviews();
        MultiView1.ActiveViewIndex = 2;
    }

    protected void LinkButtonOrders_Click(object sender, EventArgs e)
    {
        UpdateGridViewOrders();
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

    protected void GridViewShipping_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ShippingId = GridViewShipping.Rows[e.RowIndex].Cells[0].Text.ToString();
        string sql = "Delete from Shipping_Info where ID=" + ShippingId;
        using (SqlConnection conn = new SqlConnection(myConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script language='javascript'>alert('Shipping Information removed.')</script>");
                }
                catch(Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('Error has occured.')</script>");
                }
                finally
                {
                    conn.Close();
                    UpdateGridViewShipping();
                }
            }
        }
    }

    protected void GridViewPaymentInfo_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string PaymentInfoId = GridViewPaymentInfo.Rows[e.RowIndex].Cells[0].Text.ToString();
        string sql = "Delete from Payment_Info where ID=" + PaymentInfoId;
        using (SqlConnection conn = new SqlConnection(myConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script language='javascript'>alert('Payment Information removed.')</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('Error has occured. Possible integrity constraint.')</script>");
                }
                finally
                {
                    conn.Close();
                    UpdateGridViewPayment();
                }
            }
        }
    }

    protected void GridViewReviews_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ReviewsId = GridViewReviews.Rows[e.RowIndex].Cells[0].Text.ToString();
        string sql = "Delete from Reviews where ID=" + ReviewsId;
        using (SqlConnection conn = new SqlConnection(myConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script language='javascript'>alert('Review removed.')</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('Error has occured.')</script>");
                }
                finally
                {
                    conn.Close();
                    UpdateGridViewReviews();
                }
            }
        }
    }

    protected void GridViewOrders_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string OrdersId = GridViewOrders.Rows[e.RowIndex].Cells[0].Text.ToString();
        string sql = "Delete from Orders where ID=" + OrdersId;
        using (SqlConnection conn = new SqlConnection(myConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script language='javascript'>alert('Order removed.')</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('Error has occured. Possible integrity constraint.')</script>");
                }
                finally
                {
                    conn.Close();
                    UpdateGridViewOrders();
                }
            }
        }
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

    private void UpdateGridViewShipping()
    {
        GridViewShipping.DataSource = DataAccess.selectQuery("Select * from Shipping_Info where UID=" + id);
        GridViewShipping.DataBind();
    }

    private void UpdateGridViewPayment()
    {
        GridViewPaymentInfo.DataSource = DataAccess.selectQuery("Select * from Payment_Info where UID=" + id);
        GridViewPaymentInfo.DataBind();
    }

    private void UpdateGridViewReviews()
    {
        GridViewReviews.DataSource = DataAccess.selectQuery("Select * from Reviews where UID=" + id);
        GridViewReviews.DataBind();
    }

    private void UpdateGridViewOrders()
    {
        GridViewOrders.DataSource = DataAccess.selectQuery("Select * from Orders where UID=" + id);
        GridViewOrders.DataBind();
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