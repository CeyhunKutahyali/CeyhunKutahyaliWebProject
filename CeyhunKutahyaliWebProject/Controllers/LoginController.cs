using CeyhunKutahyaliWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CeyhunKutahyaliWebProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string userName, string _password)
        {

            Login _login = new Login();
            _login.UserName = userName;
            _login.Password = _password;

            if (_login.UserLogin())
            {
                Session["user_"] = userName;
                Session["authority"] = "Admin";
                return RedirectToAction("Index", "Admin");
            }

            return View();

        }

    }
}