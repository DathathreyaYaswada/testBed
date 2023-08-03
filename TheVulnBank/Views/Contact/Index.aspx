<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TheVulnBank.Models.View.Questions>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Wondering about something?</h2>
        <div class="contact-info">
            <p><b>Plz contact us at:</b></p>
            <p>Testgatan 12</p>
            <p>12271 Barnaby</p>
            <p>Phone: 123-345 67 89</p>
            <p>E-mail: test@test.ru</p>
        </div>
        <hr />
        <div class="question-textbox">
            <b>Or use the form below!</b>
            <p>we will answer asap.</p>
            <% using (Html.BeginForm("Index", "Contact", FormMethod.Post)) %>
            <% { %>
            <textarea name="q" rows="5"></textarea>
            <button type="submit">Send!</button>
            <% } %>
            <div class="clear">
                <!-- -->
            </div>
        </div>
        <% foreach (TheVulnBank.Models.Data.Question q in Model.Items)
           { %>
            <div class="question-item-container">
                <div class="question-item">
                    <div class="question-title"><span class="question-circle">?</span><span class="question-text"><%= q.Text %></span></div>
                    <div class="question-answer">
                        <span style="font-weight: bold;">Answer: </span>
                        <span><%: string.IsNullOrEmpty(q.Answer) ? "Pending..." : q.Answer %></span>                        
                        <% if(!string.IsNullOrEmpty(q.Answer)) { %>                        
                            <span>Best regards // Banking guys</span>
                        <% } %>
                    </div>
                </div>
            </div>
        <% } %>
    </div>
</asp:Content>
