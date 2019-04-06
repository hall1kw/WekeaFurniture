﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Checkout : System.Web.UI.Page
{
    protected ShoppingCart thisCart;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["thisCart"] == null)
        {
            Response.Write("<script>alert('There was an error loading your shopping cart!')</script>");
            Response.Redirect("/Home.aspx");
        } else
        {
            thisCart = (ShoppingCart)Session["thisCart"];
        }
        if (thisCart.Items.Count == 0)
        {
            Response.Write("<script>alert('Your shopping cart is empty!')</script>");
            Response.Redirect("/Home.aspx");
        }
        
        if (!IsPostBack)
        {
            dlProductDetail.DataSource = thisCart.Items;
            dlProductDetail.DataBind();
        }
    }
    
    protected void submitFormButton_Click(object sender, EventArgs e)
    {
        cardnumber.Text.Replace("/\\D/", "");
        string sub_num = "";
        bool rValue = false;

        //MasterCard Check
        sub_num = cardnumber.Text.Substring(0, 2);
        if(cardnumber.Text.Length == 16 && ( sub_num == "51" || 
            sub_num == "52" || sub_num == "53" || sub_num == "54" 
            || sub_num == "55"))
        {
            rValue = luhn_check(int.Parse(cardnumber.Text));
        }

        //Visa
        sub_num = cardnumber.Text.Substring(0, 1);

        if((cardnumber.Text.Length == 13 || cardnumber.Text.Length == 16)
            && sub_num == "4")
        {
            rValue = luhn_check(int.Parse(cardnumber.Text));
        }

        //Amex
        sub_num = cardnumber.Text.Substring(0, 2);
        if(cardnumber.Text.Length == 15 && 
            ( sub_num == "34" || sub_num == "37"))
        {
            rValue = luhn_check(int.Parse(cardnumber.Text));
        }

        //Discover
        sub_num = cardnumber.Text.Substring(0, 4);
        string sub_num2 = cardnumber.Text.Substring(0, 12);
        string sub_num3 = cardnumber.Text.Substring(0, 6);
        string sub_num4 = cardnumber.Text.Substring(0, 2);
        if(cardnumber.Text.Length == 16 && ( sub_num == "6011" || 
            sub_num2 == "622126622925" || sub_num3 == "644649"
            || sub_num4 == "65"))
        {
            rValue = luhn_check(int.Parse(cardnumber.Text));
        }

       HttpContext.Current.Session["rValue"] = rValue;
    }

    protected bool luhn_check(int number)
    {
        int number_length = number.ToString().Length;
        int parity = number_length % 2;
        char[] num_arr;
        int digit = 0;
        int total = 0;

        num_arr = number.ToString().ToCharArray();
        for (int i = 0; i < number_length; i++)
        {
            digit = num_arr[i];
            if(i % 2 == parity)
            {
                digit *= 2;

                if(digit > 9)
                {
                    digit -= 9;
                }
            }
            total += digit;
        }

        return (total % 10 == 0) ? true : false;
    }

}