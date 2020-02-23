using propertyfinder.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace propertyfinder.Controllers
{
    [SessionTimeout]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AccountValidation()
        {

            return View();
        }
    }
}