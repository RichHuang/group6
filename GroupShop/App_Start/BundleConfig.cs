using System.Web;
using System.Web.Optimization;

namespace GroupShop
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/typeahead").Include(
                      "~/Scripts/typeahead.js",
                      "~/Scripts/hogan-2.0.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/project-common").Include(
                      "~/Scripts/project-common.js"));
            

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui-1.10.3.custom").Include(
                      "~/Scripts/jquery-ui-1.10.3.custom.js"));



            bundles.Add(new ScriptBundle("~/bundles/select2-js").Include(
                      "~/Scripts/select2.js",
                      "~/Scripts/select2_locale_zh-TW.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-spin").Include(
                "~/Scripts/spin.js",
                "~/Scripts/jquery.spin.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*")
);

            //bundles.Add(new ScriptBundle("~/bundles/jquery.tablesorter").Include(
            //          "~/Scripts/jquery.tablesorter.js",
            //          "~/Scripts/jquery.tablesorter.widgets.js",
            //          "~/Scripts/jquery.tablesorter.pager.js"));


            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/typeahead-js-bootstrap").Include(
                        "~/Content/typeahead.js-bootstrap.css"));

            //bundles.Add(new StyleBundle("~/Content/smoothness/jquery-ui-1.10.3.custom").Include(
            //          "~/Content/smoothness/jquery-ui-1.10.3.custom.css"));

            //bundles.Add(new StyleBundle("~/Content/tablesorter").Include(
            //          "~/Content/tablesorter/theme.bootstrap.css",
            //          "~/Content/tablesorter-pager/jquery.tablesorter.pager.css"));

            bundles.Add(new StyleBundle("~/bundles/pagedlist").Include(
                        "~/Content/PagedList.css"));


            bundles.Add(new StyleBundle("~/bundles/select2").Include(
            "~/Content/select2/select2.css",
            "~/Content/select2/select2-bootstrap.css"));


        }
    }
}
