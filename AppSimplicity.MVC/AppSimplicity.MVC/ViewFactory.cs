using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppSimplicity.MVC
{
    public class ViewFactory
    {
        /// <summary>
        /// Uses web.config settings to stablish where to look for the base or custom views.
        /// </summary>
        /// <param name="engines"></param>
        public static void RegisterCustomViewLocations(System.Web.Mvc.ViewEngineCollection engines)
        {
            RazorViewEngine razor = (RazorViewEngine)engines.FirstOrDefault(x => x is RazorViewEngine);

            //Change default locations to custom generated locations:                        
            razor.ViewLocationFormats = Properties.Settings.Default.ViewLocations.Cast<string>().ToArray();
            razor.PartialViewLocationFormats = Properties.Settings.Default.PartialViewLocations.Cast<string>().ToArray();

            engines.Clear();
            engines.Add(razor);
        }
    }
}
