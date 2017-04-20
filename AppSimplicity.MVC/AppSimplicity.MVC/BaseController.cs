using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Mvc;

namespace AppSimplicity.MVC
{
    public class BaseController : System.Web.Mvc.Controller
    {
        private string _userIdentity = "";
        public string UserIdentity
        {
            get
            {
                if (string.IsNullOrEmpty(_userIdentity))
                {
                    if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        _userIdentity = System.Web.HttpContext.Current.User.Identity.Name;
                    }
                }
                return _userIdentity;
            }
        }

        /// <summary>
        /// Serializes an object to a Json Instance
        /// </summary>
        /// <param name="data">The instance of the object to be serialized</param>
        /// <returns></returns>
        public JsonNetResult ToJson(object data)
        {
            return new JsonNetResult() { Instance = data };
        }

        /// <summary>
        /// Takes a given model and render contents of a view to a string
        /// </summary>
        /// <typeparam name="T">The type of the Model</typeparam>
        /// <param name="viewPath">The path to the url</param>
        /// <param name="model">The instance of the model</param>
        /// <returns></returns>
        protected string RenderViewToString<T>(string viewPath, T model)
        {
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewPath);
                var vdd = new ViewDataDictionary<T>(model);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, vdd, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}