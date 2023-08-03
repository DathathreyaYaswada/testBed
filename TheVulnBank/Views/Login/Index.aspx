<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="login-box">
        <form action="<%: Url.Action("Index", "Login") %>" method="post">
            <b>Username:</b>
            <input type="text" name="username" />
            <b>Password:</b>
            <input type="password" name="password" />

            <% if (TempData["Message"] != null) { %>
            <div class="alert-box">
                <%: TempData["Message"] %>
            </div>
            <% } %>

            <button type="submit">Sign in!</button>
            <div class="clear"><!-- --></div>
        </form>
    </div>

</asp:Content>
