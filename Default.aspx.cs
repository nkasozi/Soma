using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    private const string UPLOAD_FILE_DIR = @"D:\UploadedFiles\";
    private List<string> AllowedFileExtensions = new List<string>() { ".epub" };
    BussinessLogic bll = new BussinessLogic();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            string target = Request.Params["__EVENTTARGET"];
            //string args = Request.Params["__EVENTARGUMENT"];
            if (target.Contains("Browse"))
            {
                BrowseButton_Click(sender, e);
            }
        }

    }
    protected void BrowseButton_Click(object sender, EventArgs e)
    {
        if (FileUploadControl.HasFile)
        {
            try
            {
                string ext = Path.GetExtension(FileUploadControl.FileName);
                if (AllowedFileExtensions.Contains(ext))
                {
                    string fileName = UPLOAD_FILE_DIR + FileUploadControl.FileName;
                    //Save file
                    FileUploadControl.SaveAs(fileName);

                    Ebook ebook = new Ebook(fileName);
                    Session["Ebook"] = ebook;
                    Response.Redirect("Views/EbookLibraryView");
                }
                else
                {
                    //display error msg
                    string Msg = "Please Upload a valid File";
                    bll.ShowText(Msg, true, Master);
                }

            }
            catch (Exception ex)
            {
                //display error msg
                string Msg = "Error: " + ex.Message;
                bll.ShowText(Msg, true, Master);
            }
        }
        else
        {
            //display error msg
            string Msg = "Please Specify a File to Upload";
            bll.ShowText(Msg, true, Master);
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}