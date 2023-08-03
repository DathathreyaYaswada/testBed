using System.Web.Mvc;

namespace TheVulnBank.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["UserId"] = userId;
            return View();
        }

    }
}
