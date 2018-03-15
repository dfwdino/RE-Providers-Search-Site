using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace RE.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                           "~/Scripts/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css",
                                        "~/Content/bootstrap.css",
                                        "~/Content/bootstrap-theme.css",
                                        "~/Content/site.css",
                                        "~/Content/bootstrap-responsive.css"));

            bundles.Add(new ScriptBundle("~/bundles/GPS").Include("~/Scripts/GPS.js"));

        }
    }
}