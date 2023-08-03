using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace TheVulnBank.Controllers
{
    public class BaseController : Controller
    {
        protected bool isAuthenticated = false;
        protected int userId = 0;
        protected string username = String.Empty;

        protected override void Initialize(RequestContext requestContext) 
        {
            base.Initialize(requestContext);
            var request = requestContext.HttpContext.Request;

            if (request.Cookies["Authorized"] != null)
            {
                bool cookieAuthValue;
                if (bool.TryParse(request.Cookies["Authorized"].Value, out cookieAuthValue))
                {
                    isAuthenticated = cookieAuthValue;
                }

                if (isAuthenticated)
                {
                    userId = int.Parse(request.Cookies["UserId"].Value);
                    username = request.Cookies["Username"].Value;
                }
            }

            ViewData.Add("IsAuthenticated", isAuthenticated);
            ViewData.Add("UserId", userId);
            ViewData.Add("Username", username);
        }

    }
}
