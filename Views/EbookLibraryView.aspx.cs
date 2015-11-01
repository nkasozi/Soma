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
        try
        {
            if (Session==null)
            {
                string redirectURL = ResolveClientUrl("~/Account/Login.aspx");
                Response.Redirect(redirectURL);
            }
            else
            {
                AppUser user = Session["AppUser"] as AppUser;
                List<Ebook> allUsersEbooks = Ebook.GetAll().Where(item => item.AppUserId == user.AppUserId).ToList();
                Session["AllUploadesEbooks"] = allUsersEbooks;
            }
        }
        catch (Exception ex) 
        {
            string redirectURL = ResolveClientUrl("~/Account/Login.aspx");
            Response.Redirect(redirectURL);
        }

    }
}