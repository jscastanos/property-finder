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
        [SessionTimeout]
        public ActionResult UserProfile()
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
                Session["fullName"] = fullName(userInfo.Firstname, userInfo.Lastname);
                Session["Role"] = t.AccountTypeId;
                Session["userImg"] = userInfo.ProfileImg;
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
                Session["fullName"] = fullName(userInfo.Firstname, userInfo.Lastname);
                Session["Role"] = t.AccountTypeId;
            }
            return RedirectToAction("Index", "Home");
        }

        public string fullName(string a, string c)
        {
            return a + "  " + c;
        }
        public ActionResult logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult RetrieveImage(string id, int facingType)
        {
            byte[] img = null;
            if (facingType == 2)
            {
                var data = db.tPersonInfoes.SingleOrDefault(p => p.UserId == id);

                img = data.ProfileImg;

                return File(img, "image/jpeg");

            } else {
                var data = db.tUserValidationIds.Where(x => x.PersonId == id).ToArray();

                switch (facingType)
                {
                    case 0:
                        img = data[0].Image;
                        break;
                    case 1:
                        img = data[1].Image;
                        break;
                }

                if (img != null)
                {
                    return File(img, "image/jpeg");
                }
                else
                {
                    return File("../img/nophoto.png", "image/png");
                }
            }
        }
    }
}