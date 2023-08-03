using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheVulnBank.Filters;
using TheVulnBank.Models.Data;
using TheVulnBank.Models.View;
using TheVulnBank.Repositories;

namespace TheVulnBank.Controllers
{
    public class ContactController : BaseController
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            var questions = new Questions() { Items = GetQuestionRepo().GetQuestions(this.userId) };
            return View(questions);
        }

        [HttpPost]
        [RequireLoginFilter]
        [ValidateInput(false)]
        public ActionResult Index(string q)
        {
            var questions = new Questions();

            if (!string.IsNullOrEmpty(q))
            {
                GetQuestionRepo().AddQuestion(this.userId, q);
            }

            questions.Items = GetQuestionRepo().GetQuestions(this.userId);

            return View(questions);
        }

        [HttpGet]
        [RequireLoginFilter]
        public ActionResult Clear()
        {
            var questions = new Questions();
            GetQuestionRepo().RemoveQuestions(this.userId);
            questions.Items = GetQuestionRepo().GetQuestions(this.userId);
            return View("Index", questions);
        }

        [HttpGet]
        [RequireLoginFilter]
        public ActionResult ClearAll()
        {
            var questions = new Questions();
            GetQuestionRepo().RemoveAllQuestions();
            questions.Items = GetQuestionRepo().GetQuestions(this.userId);
            return View("Index", questions);
        }

        private QuestionsRepository GetQuestionRepo()
        {
            return new QuestionsRepository(new SqlConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDB"].ConnectionString));
        }
    }
}
