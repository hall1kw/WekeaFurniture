using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.HttpContext;

public partial class Checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = "5";
            dlProductDetail.DataSource = DataAccess.selectQuery("SELECT * FROM PRODUCTS WHERE ID=" + id);
            dlProductDetail.DataBind();
        }
    }
    
    protected void submitFormButton_Click(object sender, EventArgs e)
    {
        cardnumber.Replace("/\\D/","");
        string sub_num = "";
        bool rValue = false;

        //MasterCard Check
        sub_num = cardnumber.SubString(0, 2);
        if(cardnumber.Length == 16 && ( sub_num == "51" || 
            sub_num == "52" || sub_num == "53" || sub_num == "54" 
            || sub_num == "55"))
        {
            rValue = luhn_check(cardnumber);
        }

        //Visa
        sub_num = cardnumber.SubString(0, 1);

        if((cardnumber.Length == 13 || cardnumber.Length == 16)
            && sub_num == "4")
        {
            rValue = luhn_check(cardnumber);
        }

        //Amex
        sub_num = cardnumber.SubString(0, 2);
        if(cardnumber.Length == 15 && 
            ( sub_num == "34" || sub_num == "37"))
        {
            rValue = luhn_check(cardnumber);
        }

        //Discover
        string sub_num = cardnumber.SubString(0, 4);
        string sub_num2 = cardnumber.SubString(0, 12);
        string sub_num3 = cardnumber.SubString(0, 6);
        string sub_num4 = cardnumber.SubString(0, 2);
        if(cardnumber.Length == 16 && ( sub_num == "6011" || 
            sub_num2 == "622126622925" || sub_num3 == "644649"
            || sub_num4 == "65"))
        {
            rValue = luhn_check(cardnumber);
        }

       HttpContext.Current.Session["rValue"] = rValue;
    }

    protected bool luhn_check(int number)
    {
        int number_length = number.Length;
        int parity = number_length % 2;
        var num_arr;
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