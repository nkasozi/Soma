using Microsoft.AspNet.Identity;
using System;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using TestAspNet;

public partial class Account_Register : Page
{
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        AppUser appUser = new AppUser();
        appUser.Name = TextBoxName.Text;
        appUser.AppUserId = UserName.Text;
        appUser.AppUserPassword = Password.Text;
        if (appUser.IsValid())
        {
            appUser.Save();
            ErrorMessage.Text = appUser.StatusDescription;
            Response.Redirect("Login.aspx");
        }
        else 
        {

            ErrorMessage.Text = appUser.StatusDescription;
        }
    }
}