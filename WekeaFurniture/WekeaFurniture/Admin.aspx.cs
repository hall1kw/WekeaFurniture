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

    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        
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
        string sql = "DELETE FROM PRODUCTS WHERE ID = " + (((Label)DetailsView1.Rows[0].Cells[0].FindControl("lblId")).Text.ToString());
        DataAccess.deleteQuery(sql);
        UpdateGridView();
        DetailsView1.DataBind();
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        /*  if (((Button)DetailsView1.Rows[3].Cells[1].FindControl("Button1")).Text == "New Image")
          {
              ((FileUpload)DetailsView1.Rows[3].Cells[1].FindControl("fuImage")).Enabled = true;
              ((Button)DetailsView1.Rows[3].Cells[1].FindControl("Button1")).Text = "Cancel";
          }*/
        ((FileUpload)DetailsView1.Rows[3].Cells[1].FindControl("fuImage")).Enabled = true;
        if (((Button)DetailsView1.Rows[0].FindControl("Button1")).Text.Equals("New Image"))
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