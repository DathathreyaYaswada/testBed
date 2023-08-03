<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TheVulnBank.Models.Data.Article>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2><%= Model.Title %></h2>

<%= Model.Text %>

</asp:Content>
