using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace propertyfinder.Controllers
{
    public class ExtensionMethods : Controller
    {

        public ActionResult goToRegister(string id)
        {
            return RedirectToAction("Register", "Account", new { id = id });
        }

        public string generateCode(int length)
        {
            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).Replace("+", string.Empty).Substring(0, length).ToUpper();
            return guid;
        }

    }
}