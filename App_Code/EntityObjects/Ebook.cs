using eBdb.EpubReader;
using System;
using System.Collections.Generic;
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
    public List<EbookChapter> Chapters = new List<EbookChapter>();

    public Ebook(string filePath)
    {
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

        foreach (EpubChapter chapter in epub.Chapters) 
        {
            EbookChapter chptr = new EbookChapter();
            chptr.Title = chapter.Title;
            chptr.ChapterContent = chapter.HtmlContent;
            this.Chapters.Add(chptr);
        }
    }

}