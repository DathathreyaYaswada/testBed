<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>List accounts</h2>

<div class="content-with-sidebar">
    <div class="sidebar"></div>
    <div class="main-content">
        <table class="tiger-table" width="100%">
            <thead>
                <tr>
                    <th>
                        Name
                    </th>
                    <th>
                        Balance
                    </th>
                    <th style="width: 15%">
                        &nbsp;
                    </th>
                </tr>
            </thead>
            <tbody>
            <% foreach (TheVulnBank.Models.Data.Account account in Model) {  %>
                <tr>
                    <td><%: account.Name %></td>
                    <td><%: account.Amount %></td>
                    <td style="text-align: right;"><%: Html.ActionLink("Show transfers", "Transfers", new { id = account.Id }) %></td>
                </tr>
            <% } %>
            </tbody>
        </table>

        <a href="<%: Url.Action("Transfer", "Account") %>" class="link-with-icon" style="float: right; margin-top: 10px;"><img src="<%: Url.Content("~/") %>Resources/Images/Icons/add.png" /> New transfer</a>
    </div>
</div>

</asp:Content>
