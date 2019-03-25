<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        //log in
        //String userid = Request.Cookies["userid"].Value;
        //String passHash = Request.Cookies["passHash"].Value;

        //if it can verify the user
        //Session["userid"] = userid;

        //load the cart

        string cartID = null;
        if(Request.Cookies["cart"] != null)
            cartID = Request.Cookies["cart"].Value;
        ShoppingCart thisCart;
        if(cartID != null)
        {
            thisCart = (ShoppingCart)HttpContext.Current.Cache[cartID];
            if (thisCart == null)
            {
                thisCart = new ShoppingCart();
            }
        } else
        {
            Random r = new Random();
            int rInt = r.Next(0, 100000);
            thisCart = new ShoppingCart();
            cartID = rInt.ToString();
            HttpCookie cookie = new HttpCookie("cart", cartID);
            cookie.Expires = DateTime.Now.AddHours(2);
            Response.Cookies.Add(cookie);

        }

        HttpContext.Current.Cache[cartID] = thisCart;
        Session["thisCart"] = thisCart;



    }

    void Session_End(object sender, EventArgs e)
    {
    }

</script>
