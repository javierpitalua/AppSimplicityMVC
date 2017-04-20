using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppSimplicity.MVC.ModelBinders
{
    /// <summary>
    /// Parses date to exact format date mm/dd/yyyy
    /// </summary>
    public class DateTimeModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string unformattedDate = controllerContext.RequestContext.HttpContext.Request.Form[bindingContext.ModelName];

            if (!string.IsNullOrEmpty(unformattedDate))
            {
                //It uses the provider to format date:
                Localization.DateTimeFactory.Provider.Parse(unformattedDate);
            }

            return new DefaultModelBinder().BindModel(controllerContext, bindingContext);
        }
    }
}
