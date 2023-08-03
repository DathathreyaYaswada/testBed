<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Change my password</h2>

<form action="<%: Url.Action("ChangePassword", "User") %>" method="post">

    New password: <input type="password" name="password" /><br />
    <input type="submit" />

</form>

</asp:Content>
