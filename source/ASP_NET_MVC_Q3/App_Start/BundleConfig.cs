using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ASP_NET_MVC_Q3.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").
                Include("~/Scripts/jquery-1.*"));

            bundles.Add(new ScriptBundle("~/bundles/jquerymobile").
                Include("~/Scripts/jquery.mobile*"));

            bundles.Add(new StyleBundle("~/Content/mobilecss").
               Include("~/Content/jquery.mobile*"));

            bundles.Add(new StyleBundle("~/Content/css").
                 Include("~/Content/bootstrap.css","~/Content/Site.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap").
               Include("~/Scripts/bootstrap.js","~/Scripts/respond.js"));



        }
    }
}