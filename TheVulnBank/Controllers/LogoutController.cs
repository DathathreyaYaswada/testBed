using System;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Web;
using System.Web.Mvc;
using TheVulnBank.Models.Data;
using TheVulnBank.Repositories;

namespace TheVulnBank.Controllers
{
    public class LogoutController : BaseController
    {
        public ActionResult Index()
        {
            HttpCookie authCookie = new HttpCookie("Authorized");
            authCookie.Value = false.ToString();
            authCookie.Expires = DateTime.Now.AddHours(8);
            Response.SetCookie(authCookie);

            HttpCookie userIdCookie = new HttpCookie("UserId");
            userIdCookie.Expires = DateTime.Now.AddHours(-8);
            Response.SetCookie(userIdCookie);

            HttpCookie userNameCookie = new HttpCookie("Username");
            userNameCookie.Expires = DateTime.Now.AddHours(-8);
            Response.SetCookie(userNameCookie);

            return RedirectToAction("Index", "Home");
        }
    }
}
