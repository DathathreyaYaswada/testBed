<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TheVulnBank.Models.View.Search>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <h2>Search results</h2>        
        <div class="search-box">
            <div class="large-search">
                <form action="" method="get" accesskey="s" accept-charset="utf-8">
                    <input type="text" name="q" value="<%= Model.Query %>" autocomplete="false" />
                    <input type="hidden" name="noOfItems" value="5" />
                    <input type="submit" value="Search" />
                </form>
            </div>
        </div>
        <% if (ViewData["Error"] != null) { %>
            <p style="color:red;"><%: ViewData["Error"] %></p>
        <% } else if (Model.Articles.Count == 0) { %>
            <p>No search results for <b><%= Model.Query %></b></p>
        <% } else { %>
            <p>Search results for <b><%= Model.Query %></b>:</p>
            <% foreach(TheVulnBank.Models.Data.Article article in Model.Articles) { %>
                <hr />
                <b><a href="<%: Url.Action("Index", "Article", new { id = article.Id }) %>"><%: article.Title %></a></b>
                <p><%: Html.SearchDescription(article.Text, Model.Query) %></p>
            <% } %>
        <% } %>

    <script type="text/html">
        <!-- TODO: Add DOM-based example -->
    </script>

</asp:Content>
