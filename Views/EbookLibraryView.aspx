<%@ Page Language="C#" MasterPageFile="~/Views.master" AutoEventWireup="true" CodeFile="EbookLibraryView.aspx.cs" Inherits="Views_EbookLibraryView" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../Scripts/bookshelf.js" type="text/javascript"></script>
    <script type="text/javascript">
        var books = [

        <%
        List<Ebook> uploadedBooks = (List<Ebook>)Session["AllUploadesEbooks"];
        string tobeEchoed ="";
        foreach (var ebook in uploadedBooks)
        {
           tobeEchoed+= "{\n" +
                    "title: 'The Adventures of Sherlock Holmes',\n" +
                    "image: '/Images/" +ebook.PathToCoverImage+ "',\n" +
                    "link: '/Views/EbookView?EbookName="+ebook.Title+"'\n" +
                    "},\n";
        }
        Response.Write(tobeEchoed);
        %>
			
        ];

        $(function () {
            var bookshelfSubtitle = new VirtualBookshelf.FadeTransition($('#bookshelf-subtitle'), 100, 300);

            var bookshelf = new VirtualBookshelf.Carousel('#bookshelf', {
                itemAspect: 0.8,
                spacing: 1.15,
                perspective: 0.65,
                tilt: -0.02,
                stream: new VirtualBookshelf.ArrayStream(books),
                onItemFocused: function (book) {
                    bookshelfSubtitle.show($('<div>').text(book.title));
                }
            });

            $('#bookshelf-prev')
				.click(function () {
				    bookshelf.step(-1);
				});
            $('#bookshelf-next')
				.click(function () {
				    bookshelf.step(1);
				});
        });
    </script>

    <div style="width: 702px; margin: 0 auto">
        <div id="bookshelf" style="width: 700px; height: 300px; border: 1px solid #ccc; margin-top: 20px" margin-bottom: 5px" ></div>
        <div id="bookshelf-subtitle" style="text-align: center; height: 0; margin: 0 7em"></div>
        <p class="text-center">
            <button id="bookshelf-prev" style="margin-top: 3px"" onclick="return false;" Class="btn btn-primary">Prev</button>
            <button id="bookshelf-next" style="margin-top: 3px"" onclick="return false;" Class="btn btn-primary">Next</button>
        </p>
    </div>
    
</asp:Content>
