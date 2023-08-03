using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using TheVulnBank.Models.Data;
using TheVulnBank.Models.View;
using TheVulnBank.Repositories;

namespace TheVulnBank.Controllers
{
    public class SearchController : BaseController
    {
        public ActionResult Index()
        {
            return View(new Search() { Articles = new List<Article>() });
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Index(string q, string noOfItems = "5")
        {
            // Blind SQLI
            var result = new Search() { Articles = new List<Article>() };            

            int noOfItemsParsed;

            if (!int.TryParse(noOfItems, out noOfItemsParsed))
            {
                ViewData["Error"] = "noOfItems must be an integer";
                //return View(result);
            }
            
            if (!string.IsNullOrEmpty(q) && q.Length > 0)
            {
                try
                {
                    result.Query = q;
                    result.Articles = GetArticleRepo().SearchArticles(q, noOfItems);
                }
                catch (System.Exception)
                {
                    // ...
                }
            }

            return View(result);
        }
		
		private ArticleRepository GetArticleRepo()
        {
            return new ArticleRepository(new SqlConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDB"].ConnectionString));
		}
    }
}
