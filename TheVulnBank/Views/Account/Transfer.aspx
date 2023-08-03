<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TheVulnBank.Models.View.Transfer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>New transfer</h2>

<form action="<%= Request.RawUrl %>" method="post">
    <table class="table-first-column-bold" id="transfer-table">
        <tbody>
            <tr>
                <td>
                    From:
                </td>
                <td>
                    <select name="fromAccountId">
                    <% foreach (TheVulnBank.Models.Data.Account fromAccount in Model.FromAccounts) { %>
                        <option value="<%: fromAccount.Id %>"><%: fromAccount.Name %> - <%: fromAccount.Amount %></option>
                    <% } %>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    To:
                </td>
                <td>
                    <select name="toAccountId">
                    <% foreach (TheVulnBank.Models.Data.Account toAccount in Model.ToAccounts) { %>
                        <option value="<%: toAccount.Id %>"><%: toAccount.Name %></option>
                    <% } %>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    Amount:
                </td>
                <td>
                    <input type="text" name="amount" />
                </td>
            </tr>
            <tr>
                <td>
                    Message:
                </td>
                <td>
                    <input type="text" name="message" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <button type="submit">Transfer</button>
                </td>
            </tr>
        </tbody>
    </table>
</form>

</asp:Content>
