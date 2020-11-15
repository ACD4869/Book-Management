using System.Web;
using System.Web.Optimization;

namespace BookManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            #region Design
            bundles.Add(new ScriptBundle("~/design/js").Include(
                      "~/Scripts/jquery-migrate-1.2.1.min.js",
                      "~/Scripts/scrollspy.js",
                      "~/Scripts/jquery.flexslider.js",
                      "~/Scripts/jquery.reveal.js",
                      "~/Scripts/init.js",
                      "~/Scripts/smoothscrolling.js", 
                      "~/Scripts/jquery-1.10.2.min.js"));

            bundles.Add(new StyleBundle("~/design/css").Include(
                      "~/Content/css/base.css",
                      "~/Content/css/layout.css"));

            #endregion
        }
    }
}
