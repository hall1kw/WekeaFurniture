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
    {/*
        string name = ((TextBox)DetailsView1.Rows[1].Cells[0].FindControl("txtName")).Text;
        string image = "example.jpg";
        double price = Convert.ToDouble(((TextBox)DetailsView1.Rows[3].Cells[0].FindControl("txtPrice")).Text);
        string description = ((TextBox)DetailsView1.Rows[4].Cells[0].FindControl("txtDescription")).Text;
        int idcat = Convert.ToInt16(((TextBox)DetailsView1.Rows[5].Cells[0].FindControl("txtCat")).SelectedValue);
        int idroom = Convert.ToInt16(((TextBox)DetailsView1.Rows[6].Cells[0].FindControl("txtRoom")).Text);
        int featured = Convert.ToInt16(((TextBox)DetailsView1.Rows[7].Cells[0].FindControl("txtFeatured")).Text);
        bool taxable = Convert.ToBoolean(((CheckBox)DetailsView1.Rows[8].Cells[0].FindControl("txtTaxable")).Checked);
        */
        
        //System.Diagnostics.Debug.WriteLine(e.Values["ID"].ToString());
        System.Diagnostics.Debug.WriteLine(((TextBox)DetailsView1.FindControl("txtName2")).Text.ToString());
        System.Diagnostics.Debug.WriteLine("example.jpg");
        System.Diagnostics.Debug.WriteLine(((TextBox)DetailsView1.Rows[3].Cells[0].FindControl("txtPrice")).Text);
        System.Diagnostics.Debug.WriteLine(((TextBox)DetailsView1.Rows[4].Cells[0].FindControl("txtDescription")).Text);
        System.Diagnostics.Debug.WriteLine(((DropDownList)DetailsView1.Rows[5].Cells[0].FindControl("ddlCat")).SelectedIndex + 1);
        System.Diagnostics.Debug.WriteLine(((DropDownList)DetailsView1.Rows[6].Cells[0].FindControl("ddlRoom")).SelectedIndex + 1);
        System.Diagnostics.Debug.WriteLine(((TextBox)DetailsView1.Rows[7].Cells[0].FindControl("txtFeatured")).Text);
        System.Diagnostics.Debug.WriteLine(((CheckBox)DetailsView1.Rows[8].Cells[0].FindControl("cbTaxableEdit")).Checked);

        //e.Values.
        //DataAccess.insertQuery(name, image, price, description, idcat, idroom, featured, taxable);
        //DataAccess.insertQuery("Temp", "temp.png", 22.22, "desc temp", 2, 3, 1, false);
        Response.Write("<script language='javascript'>alert('Product added to the Database.');</script>");
        DetailsView1.DataBind();
    }

    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        if (e.Exception != null)
        {
            lblError.Text = "A database error has occurred. " + "Message: " + e.Exception.Message;
            lblError.EnableViewState = true;
            e.ExceptionHandled = true;
        }
        else if (e.AffectedRows == 0)
        {
            lblError.Text = "Another user may have updated that product. Please try again.";
            lblError.EnableViewState = true;
        }
        else
        {
            lblError.EnableViewState = false;
            DetailsView1.DataBind();
            UpdateGridView();
        }
    }

    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        DataAccess.updateQuery(1, "NewTemp", "Newtemp.png", 12.34, "desc temp", 2, 3, 1, false);
        Response.Write("<script language='javascript'>alert('Product updated within Database.');</script>");
        DetailsView1.DataBind();
        UpdateGridView();
    }

    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            lblError.Text = "A database error has occurred. " + "Message: " + e.Exception.Message;
            lblError.EnableViewState = true;
            e.ExceptionHandled = true;
        }
        else if (e.AffectedRows == 0)
        {
            lblError.Text = "Another user may have updated that product. Please try again.";
            lblError.EnableViewState = true;
        }
        else
        {
            lblError.EnableViewState = false;
            DetailsView1.DataBind();
            UpdateGridView();
        }
    }

    protected void DetailsView1_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {
        //Response.Write("<script language='javascript'>confirm('Are you sure?')</script>");
        string sql = "DELETE FROM PRODUCTS WHERE ID = " + (((Label)DetailsView1.Rows[0].Cells[0].FindControl("lblId")).Text.ToString());
        DataAccess.deleteQuery(sql);
        UpdateGridView();
        DetailsView1.DataBind();
        Response.Write("<script language='javascript'>alert('Product removed from Database.')</script>");
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