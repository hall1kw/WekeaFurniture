﻿<%@ Application Language="C#" %>

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
        HttpCookie user = Request.Cookies["userInfo"];
        System.Diagnostics.Debug.WriteLine("Session Global: \n");
        if (user != null)
        {
            //System.Diagnostics.Debug.WriteLine("Session Global: " + Session["userLoggedIn"].ToString() + "\n");
            Session["userLoggedIn"] = user.Value;
            //System.Diagnostics.Debug.WriteLine("Session Global: " + Session["userLoggedIn"].ToString() + "\n");
        }
        /*
        string userid = null;
        string passHash = null;
        
        if(HttpContext.Current.Response.Cookies.AllKeys.Contains("myCookie"))
        {
            HttpCookie mycookie = Response.Cookies.Get("userInfo");
            mycookie.Expires = DateTime.Now.AddHours(2.00);
            Random r = new Random();
            int rInt = r.Next(0, 1000);
            string uniqueId = this.Session.SessionID;
            string userID = rInt.ToString() + uniqueId;
            HttpContext.Current.Cache[userID] = true;
            Session["userLoggedIn"] = true;
        } else
        {
            Session["userLoggedIn"] = false;
        }
        System.Diagnostics.Debug.WriteLine("User Session: " + Session["userLoggedIn"] + "\n");
        System.Diagnostics.Debug.WriteLine("User Cookie: " + Request.Cookies["userid"] + "\n");
        */


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
            int rInt = r.Next(0, 1000);
            string uniqueId = this.Session.SessionID;
            thisCart = new ShoppingCart();
            cartID = rInt.ToString() + uniqueId;
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
