using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace AppSimplicity.MVC.WebControls
{
    public abstract class BaseControl
    {
        public Dictionary<string , object> Attributes { get; set; }

        public FormControl Control { get; set; }                

        /// <summary>
        /// Renders html for the given control implementation
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public abstract System.Web.Mvc.MvcHtmlString Render<TModel, TValue>(HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression);


        /// <summary>
        /// Adds attributes to control that are applicable to all textboxes.
        /// </summary>
        protected void AddGenericTextBoxAttributes()
        {
            this.Attributes.Add("class", "form-control input-sm");

            if (!Control.IsEnabled)
            {
                this.Attributes.Add("disabled", "disabled");
            }

            if (!string.IsNullOrEmpty(Control.Placeholder))
            {
                this.Attributes.Add("placeholder", Control.Placeholder);
            }

            if (Control.DisplayHint && !string.IsNullOrEmpty(Control.Hint))
            {
                this.Attributes.Add("data-toggle", "tooltip");
                this.Attributes.Add("data-placement", "right");
                this.Attributes.Add("title", Control.Hint);
            }
        }

        public BaseControl(FormControl control)
        {
            this.Control = control;
            this.Attributes = new Dictionary<string, object>();
        }
    }
}
