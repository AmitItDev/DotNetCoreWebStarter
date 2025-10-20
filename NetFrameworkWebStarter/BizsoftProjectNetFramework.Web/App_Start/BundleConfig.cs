using System.Web;
using System.Web.Optimization;

namespace NetFrameworkWebStarter.Web
{
    public class BundleConfig
    {
        //// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        //public static void RegisterBundles(BundleCollection bundles)
        //{
        //    bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
        //                "~/Scripts/jquery-{version}.js"));

        //    bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
        //                "~/Scripts/jquery.validate*"));

        //    // Use the development version of Modernizr to develop with and learn from. Then, when you're
        //    // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
        //    bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
        //                "~/Scripts/modernizr-*"));

        //    bundles.Add(new Bundle("~/bundles/bootstrap").Include(
        //              "~/Scripts/bootstrap.js"));

        //    bundles.Add(new StyleBundle("~/Content/css").Include(
        //              "~/Content/bootstrap.css",
        //              "~/Content/site.css"));
        //}

        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts

            bundles.Add(new ScriptBundle("~/bundles/jsTheme").Include(
                "~/assets/node_modules/jquery/jquery-3.2.1.min.js",
                "~/assets/node_modules/popper/popper.min.js",
                "~/assets/node_modules/bootstrap/dist/js/bootstrap.min.js",
                      "~/dist/js/perfect-scrollbar.jquery.min.js",
                      "~/dist/js/waves.js",
                      "~/dist/js/sidebarmenu.js",
                      "~/assets/node_modules/sticky-kit-master/dist/sticky-kit.min.js",
                      "~/assets/node_modules/sparkline/jquery.sparkline.min.js",
                      "~/dist/js/pages/validation.js",
                      "~/assets/node_modules/sweetalert/sweetalert.min.js",
                      "~/Scripts/jquery-ui.js",
                      "~/dist/js/custom.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jsDataTableTheme").Include(
                      "~/assets/node_modules/datatables/datatables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/common")
                     .Include("~/Scripts/common.js"));

            bundles.Add(new ScriptBundle("~/bundles/capturePanelScripts").Include(
                      "~/assets/node_modules/toast-master/js/jquery.toast.js",
                      "~/Scripts/business_scripts/capture-panel.js"));

            #endregion

            #region Styles

            bundles.Add(new StyleBundle("~/Content/cssTheme").Include(
                       "~/assets/node_modules/sweetalert/sweetalert.css",
                      "~/dist/css/style.min.css",
                      "~/dist/css/jquery-ui.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/captureCssTheme").Include(
                       "~/assets/node_modules/sweetalert/sweetalert.css",
                      "~/capture_content/style.min.css",
                      "~/dist/css/jquery-ui.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/cssDataTableTheme").Include(
                      "~/assets/node_modules/datatables/media/css/dataTables.bootstrap4.css"));

            bundles.Add(new StyleBundle("~/Content/capturePanelStyles").Include(
                      "~/assets/node_modules/toast-master/css/jquery.toast.css"));

            #endregion
        }
    }
}
