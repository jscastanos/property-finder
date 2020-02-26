using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using propertyfinder.Controllers;

namespace propertyfinder.Controllers
{
    [SessionTimeout]
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }
    }
}