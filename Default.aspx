<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background:transparent !important" class="jumbotron vertical-center">
        <div class="row">
            <div class="text-center">
                <h2>One Library To Rule Them All</h2>
                <p>
                    To Get Started Upload An Ebook
                </p>
                <p>
                    <asp:FileUpload ID="FileUploadControl" runat="server" CssClass="hidden" onChange="uploadFile();" />
                    <asp:Button runat="server" ID="BrowseButton" Text="Browse" CssClass="btn btn-primary btn-large" OnClientClick="openfileDialog(); return false;" Height="44px" OnClick="BrowseButton_Click" Width="172px" />
                </p>
            </div>
        </div>
    </div>
    <script>
        function uploadFile() {
                __doPostBack('<%= BrowseButton.ClientID %>', 'OnClick');
        }

        function openfileDialog() {
            document.getElementById('<%= FileUploadControl.ClientID %>').click();
        }
    </script>
</asp:Content>

