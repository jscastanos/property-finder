using System.Web;
using System.Web.Optimization;

namespace propertyfinder
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
          /////////////////////////////// SCRIPTS ////////////////////////////////////////////////////////

            bundles.Add(new ScriptBundle("~/Scripts/template").Include(
                      "~/Scripts/template/jquery.min.js",
                      "~/Scripts/template/bootstrap.min.js",
                      "~/Scripts/template/material.min.js",
                      "~/Scripts/template/perfect-scrollbar.jquery.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/angular").Include(
                 "~/Scripts/angular/angular.min.js",
                 "~/Scripts/angular/ng-app.js"));


            /////////////////////////////// STYLES ////////////////////////////////////////////////////////

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/material-dashboard98f3.css"));

            bundles.Add(new StyleBundle("~/Content/fonts").Include(
                "~/fonts/font-awesome/css/font-awesome.min.css",
                "~/fonts/material-icons/material-icons.css"));
        }
    }
}
