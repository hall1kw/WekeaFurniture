<%@ Application Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

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
        //Try to get the userInfo cookie
        HttpCookie user = Request.Cookies["userInfo"];

        //If the cookie exist
        if (user != null)
        {
            //Check to see if the user exist in the database
            string query = "SELECT * FROM Users WHERE id='" + user["userid"].ToString() + "';";
            DataTable dt = DataAccess.selectQuery(query);


            //if there is one user in the database
            if (dt.Rows.Count == 1)
            {
                DataRow userRow = dt.Rows[0];
                string userid = userRow["ID"].ToString();
                string DBpwd = userRow["PASS_HASH"].ToString();
                
                //If the hash from the cookie is the same as the hash in the database
                if (DBpwd.Equals(user["pw"].ToString()))
                {
                    //The user is valid. Create the session
                    Session["userLoggedIn"] = user["userid"].ToString();
                    System.Diagnostics.Debug.WriteLine("Session Global - User is valid \n");
                } else
                {
                    //The password hash has somehow changed. Remove cookie and delete session
                    Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(-1); 
                    Session["userLoggedIn"] = null;
                    System.Diagnostics.Debug.WriteLine("Session Global - User is not valid: Passhashes don't match \n");
                }
            } else
            {
                //If there's no user in the database, means that user was either removed from the database.
                //Remove cookies and delete Session
                Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(-1); 
                Session["userLoggedIn"] = null;
                System.Diagnostics.Debug.WriteLine("Session Global - User is not valid: User removed from database \n");
            }

        } else
        {
            //There was no cookie, so session should be null
            Session["userLoggedIn"] = null;
            System.Diagnostics.Debug.WriteLine("Session Global - User is not valid: there was no cookie \n");
        }

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
