using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AppSimplicity.MVC.WebControls
{
    public class Select2 : BaseControl
    {
        public string DefaultSelectedValue { get; set; }
        public string SourceUrl { get; set; }

        public override System.Web.Mvc.MvcHtmlString Render<TModel, TValue>(System.Web.Mvc.HtmlHelper<TModel> helper, System.Linq.Expressions.Expression<Func<TModel, TValue>> expression)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                Func<TModel, TValue> method = expression.Compile();
                //string value = method(helper.ViewData.Model) as string;

                string value = "";
                if (ModelMetadata.FromLambdaExpression(expression, helper.ViewData) != null)
                {
                    if (ModelMetadata.FromLambdaExpression(expression, helper.ViewData).Model != null)
                    {
                        value = ModelMetadata.FromLambdaExpression(expression, helper.ViewData).Model.ToString();
                    }
                }

                if (!string.IsNullOrEmpty(value))
                {
                    list.Add(new SelectListItem() { Value = value, Text = DefaultSelectedValue, Selected = true });
                }

                Attributes.Add("class", "form-control");
                Attributes.Add("data-control", "select2");
                Attributes.Add("data-source", SourceUrl);
                Attributes.Add("style", "width: 100%;");

                if (!string.IsNullOrEmpty(Control.Placeholder))
                {
                    Attributes.Add("placeholder", Control.Placeholder);
                }

                if (!Control.IsEnabled)
                {
                    Attributes.Add("disabled", "disabled");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error while rendering Select2 component: {0}", ex.ToString()));
            }

            return helper.DropDownListFor(expression, list, Attributes);
        }

        public Select2(FormControl control, string defaultSelectedValue, string sourceUrl)
            : base(control)
        {
            this.DefaultSelectedValue = defaultSelectedValue;
            this.SourceUrl = sourceUrl;
        }
    }
}
