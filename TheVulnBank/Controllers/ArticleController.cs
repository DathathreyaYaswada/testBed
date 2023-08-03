using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using TheVulnBank.Models.Data;
using TheVulnBank.Repositories;

namespace TheVulnBank.Controllers
{
    public class ArticleController : BaseController
    {
        public ActionResult Index(int id)
        {
            ArticleRepository articleRepository = new ArticleRepository(new SqlConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDB"].ConnectionString));
            Article article = articleRepository.GetArticle(id);
            return View(article);
        }
    }
}
