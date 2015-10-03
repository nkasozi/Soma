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
            //if (target.Contains("Browse"))
            //{
                BrowseButton_Click(sender, e);
            //}
        }

    }
    protected void BrowseButton_Click(object sender, EventArgs e)
    {
        if (FileUploadControl.HasFiles)
        {
            try
            {
                List<Ebook> uploadedBooks = new List<Ebook>();
                List<string> invalidFiles = new List<string>();

                foreach (var file in FileUploadControl.PostedFiles)
                {
                    string ext = Path.GetExtension(file.FileName);

                    if (AllowedFileExtensions.Contains(ext))
                    {
                        string fileName = UPLOAD_FILE_DIR + file.FileName;

                        FileUploadControl.SaveAs(fileName);

                        Ebook ebook = new Ebook(fileName);

                        uploadedBooks.Add(ebook);

                    }
                    else
                    {
                        //display error msg
                        string errorMsg = "Invalid Ebook Format for :" + file.FileName;

                        invalidFiles.Add(errorMsg);

                    }
                }

                Session["AllUploadesEbooks"] = uploadedBooks;
                Session["ErrorMessages"] = invalidFiles;

                Response.Redirect("Views/EbookLibraryView");

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