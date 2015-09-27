using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_EbookView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ebook ebook = (Ebook)Session["Ebook"];
        DisplayEbookContent(ebook);
    }

    private void DisplayEbookContent(Ebook ebook)
    {
        try
        {
            string text=ebook.Chapters[2].ChapterContent;
             Regex regex = new Regex("\\<[^\\>]*\\>");
            string decodedstring=regex.Replace(text,string.Empty);
            chapterTextlbl.InnerText = decodedstring;
        }
        catch (Exception ex)
        {
            
        }
    }
}