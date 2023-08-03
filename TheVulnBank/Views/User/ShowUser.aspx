<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TheVulnBank.Models.Data.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>My profile</h2>

<table class="tiger-table table-first-column-bold">
    <tbody>
        <tr>
            <td>
                Username
            </td>
            <td>
                <%: Model.Username %>
            </td>
        </tr>
        <tr>
            <td>
                First name
            </td>
            <td>
                <%: Model.FirstName %>
            </td>
        </tr>
        <tr>
            <td>
                Last name
            </td>
            <td>
                <%: Model.LastName %>
            </td>
        </tr>
    </tbody>
</table>

<a href="<%: Url.Action("ChangePassword", "User") %>">Change my password</a>

</asp:Content>
