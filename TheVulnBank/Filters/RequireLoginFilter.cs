using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheVulnBank.Filters
{
    public class RequireLoginFilter : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isAuthenticated = false;

            var request = filterContext.HttpContext.Request;
            if (request.Cookies["Authorized"] != null)
            {
                bool cookieAuthValue;
                if (bool.TryParse(request.Cookies["Authorized"].Value, out cookieAuthValue))
                {
                    isAuthenticated = cookieAuthValue;
                }
            }
            if (!isAuthenticated)
            {
                filterContext.Result = new RedirectResult("/Login");
            }
        }
    }
}