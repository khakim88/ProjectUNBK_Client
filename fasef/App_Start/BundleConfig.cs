using System.Web;
using System.Web.Optimization;

namespace UNBK_Client
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // CSS
            bundles.Add(new StyleBundle("~/CSS/main").Include(
                    "~/Assets/global/css/open-sans.css",
                    "~/Assets/global/plugins/font-awesome/css/font-awesome.min.css",
                    "~/Assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                    "~/Assets/global/plugins/bootstrap/css/bootstrap.min.css",
                    "~/Assets/global/css/components-rounded.min.css"
            ));

            bundles.Add(new StyleBundle("~/CSS/layout").Include(
                    "~/Assets/global/css/plugins.min.css",
                    "~/Assets/global/css/spacing.css",
                    "~/Assets/global/css/utils.css",
                    "~/Assets/layouts/layout3/css/layout.css",
                    "~/Assets/layouts/layout3/css/themes/default.min.css",
                    "~/Assets/layouts/layout3/css/custom.min.css"
            ));

            bundles.Add(new StyleBundle("~/CSS/components").Include(
                    "~/Assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css",
                    "~/Assets/global/plugins/select2/css/select2.min.css",
                    "~/Assets/global/plugins/select2/css/select2-bootstrap.min.css",
                    "~/Assets/global/plugins/datatables/datatables.min.css",
                    "~/Assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css",
                    "~/Assets/global/plugins/bootstrap-sweetalert/sweetalert.css",
                    "~/Assets/global/plugins/icheck/skins/all.css"
            ));
                        
            // JavaScript
            bundles.Add(new ScriptBundle("~/Script/main").Include(
                    "~/Assets/global/plugins/jquery.min.js",
                    "~/Assets/global/plugins/bootstrap/js/bootstrap.min.js",
                    "~/Assets/global/plugins/js.cookie.min.js"
            ));

            bundles.Add(new ScriptBundle("~/Script/components").Include(
                    "~/Assets/global/plugins/jquery.blockui.min.js",
                    "~/Assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js",
                    "~/Assets/global/plugins/select2/js/select2.full.min.js",
                    "~/Assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                    "~/Assets/global/scripts/datatable.js",
	                "~/Assets/global/plugins/datatables/datatables.min.js",
	                "~/Assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js",                        
	                "~/Assets/global/plugins/bootstrap-sweetalert/sweetalert.min.js",      
	                "~/Assets/global/plugins/icheck/icheck.js",
                    "~/Assets/global/scripts/app.js"
            ));

            bundles.Add(new ScriptBundle("~/Script/layout").Include(
                    "~/Assets/global/scripts/general.js",
                    "~/Assets/layouts/layout3/scripts/layout.js",
                    //"~/Assets/layouts/layout3/scripts/demo.min.js",
                    "~/Assets/layouts/global/scripts/quick-nav.js"
            ));

            bundles.Add(new ScriptBundle("~/Script/jqueryval").Include(
                    "~/Assets/global/plugins/jquery-validation/js/jquery.validate.min.js",
                    "~/Assets/global/plugins/jquery-validation/js/additional-methods.min.js"
            ));

            
        }
    }
}
