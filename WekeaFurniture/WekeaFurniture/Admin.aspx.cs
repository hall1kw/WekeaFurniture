using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Admin : System.Web.UI.Page
{
    private static string myConnectionString;

    static Admin()
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

    protected void GridView1_PagingIndexChanging (object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        UpdateGridView();
    }

    protected void SelectEvent(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex >= 0)
        {
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            string id = GridView1.SelectedRow.Cells[1].Text.ToString();
            DetailsView1.DataSource = DataAccess.selectQuery("SELECT * FROM PRODUCTS WHERE ID = " + id);
            DetailsView1.DataBind();
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

        string id = GridView1.SelectedRow.Cells[1].Text.ToString();
        DetailsView1.DataSource = DataAccess.selectQuery("SELECT * FROM PRODUCTS WHERE ID = " + id);
        DetailsView1.DataBind();
    }

    protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        string name = ((TextBox)DetailsView1.FindControl("txtName")).Text;
        string image = "example.jpg";
        double price = Convert.ToDouble(((TextBox)DetailsView1.FindControl("txtPrice")).Text);
        string description = ((TextBox)DetailsView1.FindControl("txtDescription")).Text;
        int idcat = Convert.ToInt32(((DropDownList)DetailsView1.FindControl("ddlCat")).SelectedIndex + 1);
        int idroom = Convert.ToInt32(((DropDownList)DetailsView1.FindControl("ddlRoom")).SelectedIndex + 1);
        int featured = Convert.ToInt32(((TextBox)DetailsView1.FindControl("txtFeatured")).Text);
        bool taxable = Convert.ToBoolean(((CheckBox)DetailsView1.FindControl("cbTaxableEdit")).Checked);
        
        System.Diagnostics.Debug.WriteLine(((TextBox)DetailsView1.FindControl("txtName")).Text.ToString());
        System.Diagnostics.Debug.WriteLine("example.jpg");
        System.Diagnostics.Debug.WriteLine(((TextBox)DetailsView1.Rows[3].Cells[0].FindControl("txtPrice")).Text);
        System.Diagnostics.Debug.WriteLine(((TextBox)DetailsView1.Rows[4].Cells[0].FindControl("txtDescription")).Text);
        System.Diagnostics.Debug.WriteLine(((DropDownList)DetailsView1.Rows[5].Cells[0].FindControl("ddlCat")).SelectedIndex + 1);
        System.Diagnostics.Debug.WriteLine(((DropDownList)DetailsView1.Rows[6].Cells[0].FindControl("ddlRoom")).SelectedIndex + 1);
        System.Diagnostics.Debug.WriteLine(((TextBox)DetailsView1.Rows[7].Cells[0].FindControl("txtFeatured")).Text);
        System.Diagnostics.Debug.WriteLine(((CheckBox)DetailsView1.Rows[8].Cells[0].FindControl("cbTaxableEdit")).Checked);

        DetailsView1.DataBind();
        string query = "INSERT INTO PRODUCTS (NAME, IMAGE, PRICE, DESCRIPTION, IDCAT, IDROOM, FEATURED, TAXABLE) values (@name, @image, @price, @description, @idcat, @idroom, @featured, @taxable)";
        using (SqlConnection cnn = new SqlConnection(myConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@image", image);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@idcat", idcat);
                cmd.Parameters.AddWithValue("@idroom", idroom);
                cmd.Parameters.AddWithValue("@featured", featured);
                cmd.Parameters.AddWithValue("@taxable", taxable);
                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script language='javascript'>alert('Product added to the Database.');</script>");
                }
                catch (SqlException ex)
                {
                    //Response.Write("<script language='javascript'>alert('Problem adding to Database:\n " + ex.Message + "');</script>");
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                finally
                {
                    cnn.Close();
                    UpdateGridView();
                }
            }
        }
        
    }

    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        
    }

    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        int id = Convert.ToInt32(((Label)DetailsView1.FindControl("lblId")).Text);
        string name = ((TextBox)DetailsView1.FindControl("txtName")).Text;
        string image = "example.jpg";
        double price = Convert.ToDouble(((TextBox)DetailsView1.FindControl("txtPrice")).Text);
        string description = ((TextBox)DetailsView1.FindControl("txtDescription")).Text;
        int idcat = Convert.ToInt32(((DropDownList)DetailsView1.FindControl("ddlCat")).SelectedIndex + 1);
        int idroom = Convert.ToInt32(((DropDownList)DetailsView1.FindControl("ddlRoom")).SelectedIndex + 1);
        int featured = Convert.ToInt32(((TextBox)DetailsView1.FindControl("txtFeatured")).Text);
        bool taxable = Convert.ToBoolean(((CheckBox)DetailsView1.FindControl("cbTaxableEdit")).Checked);

        string query = "UPDATE PRODUCTS SET @NAME = @name, IMAGE = @image, PRICE = @price, DESCRIPTION = @description, IDCAT = @idcat, IDROOM = @idroom, FEATURED = @featured, TAXABLE = @taxable WHERE ID = @id";
        using (SqlConnection cnn = new SqlConnection(myConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@image", image);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@idcat", idcat);
                cmd.Parameters.AddWithValue("@idroom", idroom);
                cmd.Parameters.AddWithValue("@featured", featured);
                cmd.Parameters.AddWithValue("@taxable", taxable);
                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script language='javascript'>alert('Product updated within Database.')</script>");
                }
                catch (Exception er)
                {
                    Response.Write("<script language='javascript'>alert('Error has occured.')</script>");
                    System.Diagnostics.Debug.WriteLine(er.Message);
                }
                finally
                {
                    cnn.Close();
                    UpdateGridView();
                    DetailsView1.DataBind();
                }
            }
        }
    }

    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        
    }

    protected void DetailsView1_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {
        //Response.Write("<script language='javascript'>confirm('Are you sure?')</script>");
        string query = "DELETE FROM PRODUCTS WHERE ID = " + (((Label)DetailsView1.FindControl("lblId")).Text.ToString());
        using (SqlConnection cnn = new SqlConnection(myConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script language='javascript'>alert('Product removed from Database.')</script>");
                }
                catch (Exception er)
                {
                    Response.Write("<script language='javascript'>alert('Error has occured.')</script>");
                    System.Diagnostics.Debug.WriteLine(er.Message);
                }
                finally
                {
                    cnn.Close();
                    UpdateGridView();
                    DetailsView1.DataBind();
                }
            }
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        /*  if (((Button)DetailsView1.Rows[3].Cells[1].FindControl("Button1")).Text == "New Image")
          {
              ((FileUpload)DetailsView1.Rows[3].Cells[1].FindControl("fuImage")).Enabled = true;
              ((Button)DetailsView1.Rows[3].Cells[1].FindControl("Button1")).Text = "Cancel";
          }*/
        //System.Diagnostics.Debug.WriteLine(((FileUpload)DetailsView1.FindControl("fuImage")).Text);
        if (((Button)DetailsView1.FindControl("Button1")).Text.Equals("New Image"))
        {
            ((Button)DetailsView1.FindControl("Button1")).Text = "Cancel";
        }
    }

    private void UpdateGridView()
    {
        GridView1.DataSource = DataAccess.selectQuery("SELECT * FROM PRODUCTS");
        GridView1.DataBind();
    }
}