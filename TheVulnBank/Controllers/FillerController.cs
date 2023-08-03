using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheVulnBank.Controllers
{
    public class FillerController : BaseController
    {
        //
        // GET: /Filler/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Loan()
        {
            return View("Index");
        }

        public ActionResult Savings()
        {
            return View("Index");
        }

        public ActionResult Pension()
        {
            return View("Index");
        }

        public ActionResult Insurance()
        {
            return View("Index");
        }

        public ActionResult Services()
        {
            return View("Index");
        }
    }
}
