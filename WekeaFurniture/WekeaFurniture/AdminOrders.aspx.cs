using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class AdminOrders : System.Web.UI.Page
{
    private static string myConnectionString;
    private static string id;

    static AdminOrders()
    {
        myConnectionString = WebConfigurationManager.ConnectionStrings["ProductsConnection"].ConnectionString;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Session["userLoggedIn"] as string))
            {
                DataTable dt = DataAccess.selectQuery("Select Permission from Users where ID=" + Session["userLoggedIn"]);
                DataRow dr = dt.Rows[0];
                if (!dr[0].ToString().Equals("1")) // If current Session User is authorized to enter
                {
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            // Update GridView if authenticated
            UpdateGridView();
        }
    }

    protected void GridView1_PagingIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        UpdateGridView();
    }

    protected void SelectEvent(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex >= 0)
        {
            id = GridView1.SelectedRow.Cells[1].Text.ToString();
            System.Diagnostics.Debug.WriteLine("Select * from Orders where ID=" + id);
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            UpdateDetailsView();
        }
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        UpdateGridView();
        GridView1.SelectedIndex = e.NewEditIndex;
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string perm = ((DropDownList)GridView1.SelectedRow.FindControl("ddlPermission")).SelectedIndex.ToString();
        string userId = GridView1.SelectedRow.Cells[1].Text.ToString();
        string sql = "Update Users set PERMISSION=@permission where ID=@id";
        using (SqlConnection cnn = new SqlConnection(myConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.Parameters.AddWithValue("@permission", perm);
                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script language='javascript'>alert('Order updated within Database.')</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('Error has occured.')</script>");
                }
                finally
                {
                    GridView1.EditIndex = -1;
                    UpdateGridView();
                    GridView1.SelectedIndex = -1;
                }
            }
        }
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        UpdateGridView();
        GridView1.SelectedIndex = -1;
    }


    protected void GridView1_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string userId = GridView1.Rows[e.RowIndex].Cells[1].Text.ToString();
        string sqlOrders = "Delete from Orders where ID=" + userId;

        using (SqlConnection conn = new SqlConnection(myConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    UpdateGridView();
                }
            }
        }
    }

    

    protected string Hide_Card()
    {
        DataTable dt = DataAccess.selectQuery("Select Card_Num from Payment_Info where ID=" + GridView1.SelectedRow.Cells[3].Text.ToString());
        DataRow dr = dt.Rows[0];
        string card = dr[0].ToString();
        System.Diagnostics.Debug.WriteLine(card);
        string new_card = "XXXX-XXXX-XXXX-";
        new_card += card.Substring(card.Length - 4);

        return new_card;
    }

    private void UpdateGridView()
    {
        GridView1.DataSource = DataAccess.selectQuery("Select * from Orders");
        GridView1.DataBind();
    }

    private void UpdateDetailsView()
    {
        DetailsView1.DataSource = DataAccess.selectQuery("Select * from Orders where ID=" + id);
        DetailsView1.DataBind();
    }

    protected string getName()
    {
        DataTable dt = DataAccess.selectQuery("Select First_Name, Last_Name from Users where ID=" + GridView1.SelectedRow.Cells[2].Text.ToString());
        DataRow dr = dt.Rows[0];
        return dr[0].ToString() + " " + dr[1].ToString();
    }

    protected string getShippingInfo()
    {
        DataTable dt = DataAccess.selectQuery("Select Address_One, City, State, Zip from Shipping_Info where ID=" + GridView1.SelectedRow.Cells[6].Text.ToString());
        DataRow dr = dt.Rows[0];
        return dr[0].ToString() + ",<br />" + dr[1].ToString() + ",<br />" + dr[2].ToString() + " " + dr[3].ToString();
    }

    protected void ProductButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminProducts.aspx");
    }

    protected void CustomerButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminUsers.aspx");
    }


    protected void OrderButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminOrders.aspx");
    }
}