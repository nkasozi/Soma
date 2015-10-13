using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;

public partial class Account_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //CheckAuthoorization();
    }

    private void CheckAuthoorization()
    {
        string appID = "1507872592862305";
        string appSecret = "58410d62e51df6a7ab83c0141deb9bbc";
        string scope="email,public_profile,user_friends";

        if (Request["code"] == null)
        {

            string url = string.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                                        appID, Request.Url.AbsoluteUri, scope);
            Response.Redirect(url);
        }
        else 
        {
            Dictionary<string, string> tokens = new Dictionary<string, string>();
            string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                                        appID, Request.Url.AbsoluteUri, scope,Request["code"].ToString(),appSecret);
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse) 
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string vals = reader.ReadToEnd();
                foreach (string token in vals.Split('&')) 
                {
                    tokens.Add(token.Substring(0, token.IndexOf('=')), token.Substring(token.IndexOf("=")+1, token.Length-token.IndexOf("=") -1));

                }

                string access_token = tokens["access_token"];
                var me = new FacebookClient(access_token);
                
            }
        }
    }
}