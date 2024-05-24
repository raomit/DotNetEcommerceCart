using System.Web;
using System.Web.Optimization;

namespace EcommCart
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new Bundle("~/Content/DatatableCss").Include("~/Content/Assets/DataTable/datatables.min.css"));
            bundles.Add(new ScriptBundle("~/Content/DatatableJs").Include("~/Content/Assets/DataTable/datatables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new Bundle("~/Content/Assets/Js/main").Include("~/Content/Assets/Js/main.js"));
            bundles.Add(new Bundle("~/Content/Assets/Js/GuestCart").Include("~/Content/Assets/Js/GuestCart.js"));

        }
    }
}
