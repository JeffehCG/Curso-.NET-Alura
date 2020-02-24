using System.Web;
using System.Web.Optimization;

namespace LojaRazor
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Melhorando o desempenho do sistema

            // Transformando todas folhas de estilo em uma só
            StyleBundle estilos = new StyleBundle("~/bundles/estilos");
            estilos.Include("~/Content/bootstrap/css/bootstrap.css");
            estilos.Include("~/Content/Style.css");
            bundles.Add(estilos);

            // Transformando todos scripts em um só
            ScriptBundle scripts = new ScriptBundle("~/bundles/scripts");
            scripts.Include("~/Scripts/jquery-1.7.1.js");
            scripts.Include("~/Scripts/jquery.validate.js");
            scripts.Include("~/Scripts/jquery.validate.unobtrusive.js");
            bundles.Add(estilos);
        }
    }
}