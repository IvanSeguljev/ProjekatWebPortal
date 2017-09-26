using System.Web;
using System.Web.Optimization;

namespace Projekat
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

            //dodato za upload fajla
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/hamburger.js",
                        "~/Scripts/VracanjeID.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jsFile").Include(
                        "~/Scripts/uploadNaziv.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/smer").Include(
                        "~/Scripts/modalOpisSmer.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/materijal").Include(
                        "~/Scripts/kontroleRespMaterijaliPrikaz.js",
                        "~/Scripts/brisanjeMaterijala.js",
                        "~/Scripts/jquery-ui.min.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      //"~/Scripts/bootbox.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/reset.css",
                      "~/Content/bootstrap.css",
                      "~/Content/css/bootstrap-flatly.css",
                      "~/Content/css/site.css",
                      "~/Content/css/izgled.css",
                      "~/Content/css/stil.css",
                      "~/Content/css/simplebar.css"
                      ));
            bundles.Add(new StyleBundle("~/Content/select2").Include(
                      "~/Content/css/select2.min.css"
                      ));
            bundles.Add(new StyleBundle("~/Content/select2izgled").Include(
                      "~/Content/css/select2izgled.css"
                      ));
        }
    }
}
