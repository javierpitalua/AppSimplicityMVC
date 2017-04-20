using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSimplicity.MVC.WebControls
{
    /// <summary>
    /// Deserializes form control information
    /// </summary>
    public class FormControlsBinder : System.Web.Mvc.IModelBinder
    {
        public object BindModel(System.Web.Mvc.ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            WebControlsDictionary controls = new WebControlsDictionary();
            string serializedData = controllerContext.RequestContext.HttpContext.Request.Form[bindingContext.ModelName];

            if (!string.IsNullOrEmpty(serializedData))
            {
                controls = WebControlsDictionary.DeserializeFromString(serializedData);
            }

            return controls;
        }
    }
}
