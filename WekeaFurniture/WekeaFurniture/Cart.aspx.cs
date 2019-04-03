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

        if (thisCart != null)
        {
            lblCart.Text = thisCart.getSize().ToString();
        }

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
            lblGrandTotal.Text = string.Format("Your Cart's Total: {0,19:C}", thisCart.GrandTotal);
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
        int quantity;
        if (!Int32.TryParse(txtQuantity.Text, out quantity))
        {
            Response.Write("<script>alert('Please enter a valid number!')</script>");
            return;
        }
        if (thisCart.Items[e.RowIndex].Inventory < quantity)
        {
            string error = "<script>alert('The number you requested, " + quantity + ", exceeds our current inventory of "
                + thisCart.Items[e.RowIndex].Inventory + ". Please enter a lower number.')</script>";
            Response.Write(error);
            return;
        }
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
