using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_EbookView : System.Web.UI.Page
{
    private Ebook selectedEbook;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.selectedEbook = (Ebook)Session["SelectedEbook"];
        DisplayEbookContent();
    }

    private void DisplayEbookContent()
    {
        try
        {
            //parse html and display right content
            string text = selectedEbook.Chapters[selectedEbook.CurrentChapterIndex].ChapterContent;
            string decodedText = "";
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.OptionFixNestedTags = true;
            htmlDoc.LoadHtml(text);
            // ParseErrors is an ArrayList containing any errors from the Load statement
            if (htmlDoc.ParseErrors != null && htmlDoc.ParseErrors.Count() > 0)
            {
                // Handle any parse errors as required

            }
            else
            {

                if (htmlDoc.DocumentNode != null)
                {
                    HtmlNode bodyNode = htmlDoc.DocumentNode.SelectSingleNode("//body");

                    if (bodyNode != null)
                    {
                        decodedText = bodyNode.InnerText;
                    }
                }
            }
            decodedText = decodedText.Replace(Environment.NewLine, "<br/>");
            chapterTextlbl.InnerHtml = decodedText;
        }
        catch (Exception ex)
        {
            chapterTextlbl.InnerHtml = ex.Message;
        }
    }
    protected void BtnNext_Click(object sender, EventArgs e)
    {
        try
        {
            selectedEbook.CurrentChapterIndex++;
            Session["SelectedEbook"] = selectedEbook;
            DisplayEbookContent();
        }
        catch (Exception ex)
        {
            chapterTextlbl.InnerHtml = ex.Message;
        }
    }
    protected void BtnPrevious_Click(object sender, EventArgs e)
    {
        try
        {
            selectedEbook.CurrentChapterIndex--;
            Session["SelectedEbook"] = selectedEbook;
            DisplayEbookContent();
        }
        catch (Exception ex)
        {
            chapterTextlbl.InnerHtml = ex.Message;
        }
    }
}