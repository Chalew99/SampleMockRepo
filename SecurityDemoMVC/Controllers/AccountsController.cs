using SecurityDemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SecurityDemoMVC.Controllers
{
    public class AccountsController : Controller
    {
         // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User model)
        {
            using (MVC_DBEntities context = new MVC_DBEntities())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }

            return RedirectToAction("Login");
        }


        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(user model)
        {
            using (MVC_DBEntities context = new MVC_DBEntities())
            {
                bool IsValidUser = context.Users.Any(user => user.UserName.ToLower() ==
                     model.UserName.ToLower() && user.UserPassword == model.UserPassword);
                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Employees");
                }
                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}