using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using propertyfinder.Models;

namespace propertyfinder.Controllers
{
    public class AccountController : Controller
    {
        private readonly PropertyFinder db = new PropertyFinder();
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult auth(tUser u)
        {
            if(u.UserId != null)
            {
                var t = db.tUsers.Where(x => x.UserId == u.UserId).FirstOrDefault();
                var userInfo = db.tPersonInfoes.Where(p => p.UserId == t.UserId).FirstOrDefault();

                Session["userId"] = t.UserId;
                Session["fullName"] = fullName(userInfo.Firstname, userInfo.Middlename, userInfo.Lastname);
                Session["Role"] = t.AccountTypeId;
            } else
            {
                var t = db.tUsers.Where(x => x.Username == u.Username && x.Password == u.Password).FirstOrDefault();
                var userInfo = db.tPersonInfoes.Where(p => p.UserId == t.UserId).FirstOrDefault();

                if (t == null)
                {
                    t = null;
                    return RedirectToAction("Index", "Home");
                }
                Session["userId"] = t.UserId;
                Session["fullName"] = fullName(userInfo.Firstname, userInfo.Middlename, userInfo.Lastname);
                Session["Role"] = t.AccountTypeId;
            }
            return RedirectToAction("Index", "Home");
        }

        public string fullName(string a, string b, string c)
        {
            return a + " " + b + " " + c;
        }
        public ActionResult logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}