using System.Web;
using System.Web.Optimization;

namespace Polycore
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Bundles/scripts").Include(
                        "~/Scripts/jquery.js",
                        "~/Scripts/jquery.cookie.pack.js",
                        "~/Scripts/jquery-ui.js",
                        "~/Scripts/jquery-migrate.min.js",
                        "~/Scripts/jquery.fancybox.js",
                        "~/Scripts/jquery.elastic.source.js",
                        "~/Scripts/jquery.carouFredSel-6.2.1-packed.js",
                        "~/Scripts/jquery-ui-1.10.3.custom.min.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/login-with-ajax.js",
                        "~/Scripts/bootstrap-button.js",
                        "~/Scripts/bootstrap-carousel.js",
                        "~/Scripts/bootstrap-collapse.js",
                        "~/Scripts/bootstrap-modal.js",
                        "~/Scripts/bootstrap-tab.js",
                        "~/Scripts/bootstrap-tooltip.js",
                        "~/Scripts/bootstrap-transition.js",
                        "~/Scripts/bootstrap-popover.js",
                        "~/Scripts/easing.js",
                        "~/Scripts/global.js",
                        "~/Scripts/imagescale.js",
                        "~/Scripts/login-with-ajax.source.js",
                        "~/Scripts/main.js",
                        "~/Scripts/theme.min.js",
                        "~/Scripts/tinymce.min.js",
                        "~/Scripts/transit.js",
                        "~/Scripts/admin.js",
                        "~/Scripts/greensock.js",
                        "~/Scripts/layerslider.transitions.js",
                        "~/Scripts/layerslider.kreaturamedia.jquery.js",
                        "~/Scripts/tabs.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/style.css",
                "~/Content/layerslider.css",
                "~/Content/fonts.css"));
        }
    }
}
