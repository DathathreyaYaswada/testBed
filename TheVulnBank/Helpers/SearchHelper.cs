using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace TheVulnBank.Helpers
{
    public static class SearchHelper
    {
        public static MvcHtmlString SearchDescription(this HtmlHelper helper, string text, string query) 
        {
            string clean = Regex.Replace(text, "<.*?>", string.Empty);

            int padding = 25;
            int startPos = clean.IndexOf(query, StringComparison.CurrentCultureIgnoreCase);

            if (startPos < 0) // Search match is in the title ...
            {
                if ((padding * 2) >= clean.Length)
                {
                    return new MvcHtmlString(clean);
                }
                else
                {
                    return new MvcHtmlString(clean.Substring(0, padding * 2) + "...");
                }
            }

            string result = (startPos < padding ? "" : "...") + 
                clean.Substring((startPos < padding ? 0 : startPos - padding), (startPos < padding ? startPos : padding)) +
                "<b>" + clean.Substring(startPos, query.Length) + "</b>" +
                ((startPos + query.Length + padding) > clean.Length ? clean.Substring(startPos + query.Length) : clean.Substring(startPos + query.Length, padding) + "...");

            return new MvcHtmlString(result);
        }
    }
}