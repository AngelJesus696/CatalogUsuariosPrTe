using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            ML.Result result = BL.Login.ValidateUser(Username, Password);
            if (result.Correct)
            {
                Session["LoginName"] = Username;
                return RedirectToAction("GetAll", "Usuario");
            }
            else
            {
                Session["LoginBool"] = false;
                return View();
            }
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}