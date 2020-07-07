using OpenCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OpenCMS.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            if(!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password))
            {
                if (model.Email.ToString() == "admin" && model.Password.ToLower() == "admin")
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    Response.Redirect("/Admin/Index");
                }
            }
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            FormsAuthentication.RedirectToLoginPage();

            return RedirectToAction("Login", "Account");
        }
    }
}