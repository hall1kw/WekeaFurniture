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

    // Event Handlers

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

    protected void DetailsView1_ModeChanging(Object sender, DetailsViewModeEventArgs e)
    {
        if (e.NewMode == DetailsViewMode.Edit)
        {
            DetailsView1.ChangeMode(DetailsViewMode.Edit);
        }
        if (e.NewMode == DetailsViewMode.Insert)
        {
            DetailsView1.ChangeMode(DetailsViewMode.Insert);
        }
        if (e.NewMode == DetailsViewMode.ReadOnly)
        {
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        }

        UpdateDetailsView();
    }

    // Update method that will also send out email if Fullfilled is changed to 'True'

    protected void DetailsView1_OnItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        string fullfilled = ((DropDownList)DetailsView1.FindControl("ddlFullfilled")).SelectedValue.ToString();
        bool tempVarForEmailControlShowsChangeInFulfilled = fullfilled.ToString().Equals("0");
        string sql = "Update Orders set FULLFILLED=@fullfilled where ID=@id";
        using (SqlConnection cnn = new SqlConnection(myConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@fullfilled", fullfilled);
                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script language='javascript'>alert('Order updated within Database.')</script>");
                    DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                    System.Diagnostics.Debug.WriteLine("checking email script");
                    if (fullfilled.Equals("True") && !tempVarForEmailControlShowsChangeInFulfilled)
                    {
                        System.Diagnostics.Debug.WriteLine("Calling email script " + id);
                        SendShippingEmail.SendShipEmail(Int32.Parse(id));
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('Error has occured.')</script>");
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
                finally
                {
                    UpdateDetailsView();
                    UpdateGridView();
                }
            }
        }
    }

    // Delete Method (Don't know if will use - TBD
    /*
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
    */

    // Updates for GridView / DetailsView

    private void UpdateGridView()
    {
        GridView1.DataSource = DataAccess.selectQuery("Select * from Orders Order By Fullfilled, ID");
        GridView1.DataBind();
    }

    private void UpdateDetailsView()
    {
        DetailsView1.DataSource = DataAccess.selectQuery("Select * from Orders where ID=" + id);
        DetailsView1.DataBind();
    }

    // Get Info for the DetailsView

    protected string Hide_Card()
    {
        DataTable dt = DataAccess.selectQuery("Select Card_Num from Payment_Info where ID=" + GridView1.SelectedRow.Cells[3].Text.ToString());
        DataRow dr = dt.Rows[0];
        string card = dr[0].ToString();
        System.Diagnostics.Debug.WriteLine(card);
        string new_card = "XXXX-XXXX-XXXX-";
        try
        {
            new_card += card.Substring(card.Length - 4);
        }
        catch (Exception ex)
        {
            new_card = "XXXX-XXXX-XXXX-XXXX";
        }

        return new_card;
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

    protected string getProducts()
    {
        string products = ""; int i = 1;
        DataTable dt = DataAccess.selectQuery("Select op.PID, p.NAME from Order_Products op, Products p where op.OID=" + id + " and p.ID=op.PID");
        foreach (DataRow dr in dt.AsEnumerable())
        {
            products += "[Product " + i + "]: " + dr[1].ToString() + " (" + dr[0].ToString() + ")<br />";
            i++;
        }

        return products;
    }

    protected string getQuantity()
    {
        string quantities = ""; int i = 1;
        DataTable dt = DataAccess.selectQuery("Select QTY from Order_Products where OID=" + id);
        foreach (DataRow dr in dt.AsEnumerable())
        {
            quantities += "[Product " + i + "]: " + dr[0].ToString() +  "<br />";
            i++;
        }

        return quantities;
    }


    // Top Buttons to move between Admin pages

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