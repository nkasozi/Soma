using eBdb.EpubReader;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using VersFx.Formats.Text.Epub;
using VersFx.Formats.Text.Epub.Entities;

/// <summary>
/// Summary description for Ebook
/// </summary>
public class Ebook
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public string FilePath { get; set; }
    public Image CoverImage { get; set; }
    private int _currentChapterIndex;
    public int CurrentChapterIndex
    {
        get { return _currentChapterIndex; } 
        set {
              if (value < 0) //shouldnt drop below 0 or u get index out of range exception
                { _currentChapterIndex = 0; } 
              else
                { _currentChapterIndex = value; }
             }
    }

    public string PathToCoverImage = @"F:\";

    public List<EbookChapter> Chapters = new List<EbookChapter>();

    public Ebook(string filePath)
    {
        this._currentChapterIndex = 2;
        this.FilePath = filePath;
        string fileExtension = Path.GetExtension(filePath);
        OpenEbookAndReadContent(fileExtension);
    }

    private void OpenEbookAndReadContent(string bookType) 
    {
        switch (bookType.ToUpper()) 
        {
            case ".EPUB":
                OpenEpub();
                break;
            default:
                break;
        }
    }

    private void OpenEpub()
    {
        EpubBook epub = EpubReader.OpenBook(FilePath);
        this.Title=epub.Title;
        this.Author = epub.Author;
        this.PathToCoverImage= Path.GetFileName(FilePath).Split('.')[0] + ".png";
        this.PathToCoverImage = PathToCoverImage.Replace(' ', '_').Replace('-', '_');
        this.PathToCoverImage = System.Web.HttpContext.Current.Server.MapPath("~/Images/" +PathToCoverImage);

        File.WriteAllText(PathToCoverImage, "");
        File.Delete(PathToCoverImage);

        Bitmap bmp = new Bitmap(epub.CoverImage);
        bmp.Save(this.PathToCoverImage);

        this.PathToCoverImage = Path.GetFileName(PathToCoverImage);
        //epub.CoverImage.Save(PathToCoverImage);
      

        foreach (EpubChapter chapter in epub.Chapters) 
        {
            EbookChapter chptr = new EbookChapter();
            chptr.Title = chapter.Title;
            chptr.ChapterContent = chapter.HtmlContent;
            this.Chapters.Add(chptr);
        }
    }

}