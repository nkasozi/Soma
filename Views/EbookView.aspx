<%@ Page Language="C#" MasterPageFile="~/Views.master" AutoEventWireup="true" CodeFile="EbookView.aspx.cs" Inherits="Views_EbookView" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3 class="text-center">ChapterTitle</h3>
    <hr />
    <div class="row">
        <p id="chapterTextlbl" runat="server">Content</p>
        <p class="text-center">
        <asp:Button runat="server" ID="BtnPrevious" Text="Prev Chapter" CssClass="btn btn-primary btn-small" OnClick="BtnPrevious_Click" />
        <asp:Button runat="server" ID="BtnNext" Text="Next Chapter" CssClass="btn btn-primary btn-small" OnClick="BtnNext_Click" />
        </p>
    </div>
</asp:Content>


