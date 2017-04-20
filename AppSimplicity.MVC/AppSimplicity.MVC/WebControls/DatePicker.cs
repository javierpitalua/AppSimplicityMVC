using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AppSimplicity.MVC.WebControls
{
    public class DatePicker : BaseControl 
    {
        public override System.Web.Mvc.MvcHtmlString Render<TModel, TValue>(System.Web.Mvc.HtmlHelper<TModel> helper, System.Linq.Expressions.Expression<Func<TModel, TValue>> expression)
        {
            this.AddGenericTextBoxAttributes();
            this.Attributes.Add("data-control", "calendar");            
            //render using dateformat
            return helper.TextBoxFor(expression, Localization.DateTimeFactory.Provider.GetDateFormat(), this.Attributes);
        }

        public DatePicker(FormControl control) : base(control)
        {

        }
    }
}
