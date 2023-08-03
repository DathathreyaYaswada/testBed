<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TheVulnBank.Models.View.Account>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>List transfers</h2>

<div class="content-with-sidebar">
    <div class="sidebar"></div>
    <div class="main-content">
        <table class="tiger-table" width="100%">
            <thead>
                <tr>
                    <th>
                        Id
                    </th>
                    <th>
                        From account
                    </th>
                    <th>
                        To account
                    </th>
                    <th>
                        Amount
                    </th>
                    <th>
                        Message
                    </th>
                </tr>
            </thead>
            <tbody>
            <% if (Model.Transfers.Count == 0) { %>
                <tr><td colspan="5">No transfers to show</td></tr>
            <% }else { %>
                <% foreach (TheVulnBank.Models.Data.Transfer transfer in Model.Transfers) {  %>
                    <tr>
                        <td><%: transfer.Id %></td>
                        <td><%: Model.Accounts.First(a => a.Id == transfer.FromAccountId).Name %></td>
                        <td><%: Model.Accounts.First(a => a.Id == transfer.ToAccountId).Name %></td>
                        <td><%: transfer.Amount %></td>
                        <td><%: transfer.Message %></td>
                    </tr>
                <% } %>
            <% } %>
            </tbody>
        </table>

        <a href="<%: Url.Action("Transfer", "Account") %>" class="link-with-icon" style="float: right; margin-top: 10px;"><img src="<%: Url.Content("~/") %>Resources/Images/Icons/add.png" /> New transfer</a>
    </div>
</div>
</asp:Content>
