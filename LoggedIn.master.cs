﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoggedIn : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
