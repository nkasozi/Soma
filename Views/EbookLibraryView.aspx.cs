using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_EbookLibraryView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.IsNewSession)
        {
            string redirectURL = "/Default.aspx";
            Response.Redirect(redirectURL);
        }
        else
        {
            List<Ebook> usersEbooks = (List<Ebook>)Session["AllUploadesEbooks"];
        }
        

    }
}