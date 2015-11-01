using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LogOutLinkClick(object sender, EventArgs e) 
    {
        try
        {
            Session.Abandon();
            Response.Redirect("~/Account/Login.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
