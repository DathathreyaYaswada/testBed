using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Web;
using System.Web.Mvc;
using TheVulnBank.Models.Data;
using TheVulnBank.Repositories;

namespace TheVulnBank.Controllers
{
    public class LoginController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            //TempData.Add("Message", "POST");
            UserRepository userRepository = new UserRepository(new SqlConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDB"].ConnectionString));
            if (userRepository.UserExists(username)) 
            {
                if (userRepository.LoginUser(username, password)) 
                {
                    User user = userRepository.GetUser(username);

                    TempData.Add("Message", "Logged in: " + user.Username);
                    Session["Authorized"] = true;

                    HttpCookie authCookie = new HttpCookie("Authorized");
                    authCookie.Value = true.ToString();
                    authCookie.Expires = DateTime.Now.AddHours(8);
                    Response.SetCookie(authCookie);

                    HttpCookie userIdCookie = new HttpCookie("UserId");
                    userIdCookie.Value = user.Id.ToString();
                    userIdCookie.Expires = DateTime.Now.AddHours(8);
                    Response.SetCookie(userIdCookie);

                    HttpCookie userNameCookie = new HttpCookie("Username");
                    userNameCookie.Value = user.Username;
                    userNameCookie.Expires = DateTime.Now.AddHours(8);
                    Response.SetCookie(userNameCookie);

                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    TempData.Add("Message", "Password does not match");

                    HttpCookie cookie = new HttpCookie("Authorized");
                    cookie.Value = false.ToString();
                    cookie.Expires = DateTime.Now.AddHours(8);
                    Response.SetCookie(cookie);

                    return View();
                }
            }
            else 
            {
                TempData.Add("Message", "User does not exist");

                HttpCookie cookie = new HttpCookie("Authorized");
                cookie.Value = false.ToString();
                cookie.Expires = DateTime.Now.AddHours(8);
                Response.SetCookie(cookie);

                return View();
            }
        }

    }
}
