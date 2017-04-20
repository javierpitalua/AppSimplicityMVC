using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace AppSimplicity.MVC
{
    public class Application
    {
        public static void Initialize()
        {
            //ControllerFactory.RegisterNamespaces();
            ViewFactory.RegisterCustomViewLocations(ViewEngines.Engines);

            // Init datetime binders:
            System.Web.Mvc.ModelBinders.Binders[typeof(DateTime?)] = new ModelBinders.DateTimeModelBinder();
            System.Web.Mvc.ModelBinders.Binders[typeof(DateTime)] = new ModelBinders.DateTimeModelBinder();
            System.Web.Mvc.ModelBinders.Binders[typeof(WebControls.WebControlsDictionary)] = new WebControls.FormControlsBinder();            
        }
    }
}
