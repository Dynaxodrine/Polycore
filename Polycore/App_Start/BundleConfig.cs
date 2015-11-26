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
                        "~/Scripts/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/style.css",
                "~/Content/layerslider.css",
                "~/Content/fonts.css"));
        }
    }
}
