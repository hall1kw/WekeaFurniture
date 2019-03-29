using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;

public partial class Cart : System.Web.UI.Page
{
    string newQ;
    ShoppingCart thisCart;
    private bool isEditMode = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["thisCart"] == null)
        {
            Session["thisCart"] = new ShoppingCart();
        }
        thisCart = (ShoppingCart)Session["thisCart"];

        if (!Page.IsPostBack)
        {
            FillData();
        }

    }

    protected bool IsInEditMode
    {

        get { return this.isEditMode; }

        set { this.isEditMode = value; }

    }


    private void FillData()
    {
        gvShoppingCart.DataSource = thisCart.Items;
        gvShoppingCart.DataBind();
        if (thisCart.Items.Count == 0)
        {
            lblGrandTotal.Visible = false;
        }
        else
        {
            lblGrandTotal.Text = string.Format("Grand Total = {0,19:C}", thisCart.GrandTotal);
            lblGrandTotal.Visible = true;
        }
    }

    protected void gvShoppingCart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvShoppingCart.EditIndex = -1;
        FillData();
    }

    protected void gvShoppingCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        thisCart.Delete(e.RowIndex);    
        FillData();
    }

    protected void gvShoppingCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {        
        TextBox txtQuantity = gvShoppingCart.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox;
        int quantity = Int32.Parse(txtQuantity.Text);       
        thisCart.Update(e.RowIndex, quantity);
        gvShoppingCart.EditIndex = -1;
        FillData();        
    }

    protected void gvShoppingCart_RowEditing(object sender, GridViewEditEventArgs e)
    {
        isEditMode = true;
        gvShoppingCart.EditIndex = e.NewEditIndex;
        FillData();
    }

    
}
