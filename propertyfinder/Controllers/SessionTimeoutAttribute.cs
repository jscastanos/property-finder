using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace propertyfinder.Controllers
{
    public class SessionTimeoutAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            try
            {
                if (HttpContext.Current.Session["userId"] == null)
                {
                    filterContext.Result = new RedirectResult("~/Account/logout");
                    return;
                }
            }

            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Account/logout");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}