<%@ Page Language="C#" MasterPageFile="~/Views.master" AutoEventWireup="true" CodeFile="EbookLibraryView.aspx.cs" Inherits="Views_EbookLibraryView" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../Scripts/bookshelf.js" type="text/javascript"></script>
    <script type="text/javascript">
        var books = [
			{
			    title: 'The Adventures of Sherlock Holmes',
			    image: 'http://covers.openlibrary.org/b/isbn/9780688107826-M.jpg',
			    link: '/Views/EbookView'
			},
			{
			    title: 'A Christmas Carol',
			    image: 'http://covers.openlibrary.org/b/isbn/9781416534785-M.jpg',
			    link: '/Views/EbookView'
			},
			{
			    title: 'Moby Dick',
			    image: 'http://covers.openlibrary.org/b/isbn/9780205514083-M.jpg',
			    link: '/Views/EbookView'
			},
			{
			    title: 'Pride and Prejudice',
			    image: 'http://covers.openlibrary.org/b/isbn/9780140430745-M.jpg',
			    link: '/Views/EbookView'
			},
			{
			    title: "Gulliver's travels",
			    image: 'http://covers.openlibrary.org/b/isbn/9780721417523-M.jpg',
			    link: '/Views/EbookView'
			},
			{
			    title: 'Hamlet',
			    image: 'http://covers.openlibrary.org/b/isbn/9781904271550-M.jpg',
			    link: '/Views/EbookView"'
			}
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
            <button id="bookshelf-prev" style="margin-top: 3px"" onclick="return false;">Previous</button>
            <button id="bookshelf-next" style="margin-top: 3px"" onclick="return false;">Next</button>
        </p>
    </div>
    
</asp:Content>
