using Facebook;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using TestAspNet;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void LogInUsingFacebook(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("LoginUsingFacebook.aspx");
            }
            catch (Exception ex)
            {
                FailureText.Text = ex.Message;
            } 
        }

        protected void LogIn(object sender, EventArgs e)
        {
            try
            {
                AppUser user = new AppUser();
                user.AppUserId = txtUserName.Text.Trim();
                user.AppUserPassword = txtPassword.Text.Trim();

                if (user.UserCredentialsAreValid())
                {
                    Session["AppUser"] = user;
                    Response.Redirect("../Default.aspx");
                }
                else 
                {
                    FailureText.Text = user.StatusDescription;
                }
            }
            catch (Exception ex)
            {
                FailureText.Text = ex.Message;
            }
        }

       
}