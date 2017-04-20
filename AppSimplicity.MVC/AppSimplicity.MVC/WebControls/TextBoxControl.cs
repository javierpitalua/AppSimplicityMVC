using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AppSimplicity.MVC.WebControls
{
    public class TextBoxControl : BaseControl 
    {
        public TextBoxControl(FormControl control) : base (control)
        {

        }

        public override System.Web.Mvc.MvcHtmlString Render<TModel, TValue>(System.Web.Mvc.HtmlHelper<TModel> helper, System.Linq.Expressions.Expression<Func<TModel, TValue>> expression)
        {
            this.AddGenericTextBoxAttributes();
            return helper.TextBoxFor(expression, this.Attributes);            
        }
    }
}
