using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AppSimplicity.MVC.Extensions
{
    public static partial class WebControlHelper
    {

        public static MvcHtmlString FormColorPickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, WebControls.FormControl formControl)
        {
            WebControls.TextBoxControl control = new WebControls.TextBoxControl(formControl);
            control.Attributes.Add("data-control", "colorpicker");
            return control.Render(htmlHelper, expression);            
        }

        public static MvcHtmlString FormIconPickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, WebControls.FormControl formControl)
        {
            WebControls.TextBoxControl control = new WebControls.TextBoxControl(formControl);
            control.Attributes.Add("data-control", "iconpicker");
            return control.Render(htmlHelper, expression);
        }

        public static MvcHtmlString FormTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, WebControls.FormControl formControl)
        {
            WebControls.TextBoxControl control = new WebControls.TextBoxControl(formControl);
            return control.Render(htmlHelper, expression);
        }

        /// <summary>
        /// Displays a validation summary for a given control
        /// </summary>
        /// <param name="htmlhelper"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public static MvcHtmlString ControlSummary(this HtmlHelper htmlhelper, WebControls.FormControl control)
        {
            WebControls.ControlSummary summary = new WebControls.ControlSummary(control);
            return summary.Render();
        }

        /// <summary>
        /// Returns an HTML select element for each property in the object that is represented by the specified expression using the specified list items and HTML attributes.        
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="form"></param>
        /// <param name="sourceUrl"></param>
        /// <returns></returns>
        public static MvcHtmlString Select2For<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, WebControls.FormControl control, string sourceUrl, string defaultSelectedValue)
        {
            WebControls.Select2 ddl = new WebControls.Select2(control, defaultSelectedValue, sourceUrl);
            return ddl.Render<TModel, TValue>(helper, expression);
        }

        /// <summary>
        /// Renders a date picker box
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expresion"></param>
        /// <param name="formControl"></param>
        /// <returns></returns>
        public static MvcHtmlString DatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expresion, WebControls.FormControl formControl)
        {
            WebControls.DatePicker dt = new WebControls.DatePicker(formControl);
            return dt.Render<TModel, TProperty>(htmlHelper, expresion);
        }

        public static MvcHtmlString FormCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expresion, WebControls.FormControl formControl)
        {
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            
            if (formControl.DisplayHint && !string.IsNullOrEmpty(formControl.Hint))
            {
                attributes.Add("data-toggle", "tooltip");
                attributes.Add("data-placement", "right");
                attributes.Add("title", formControl.Hint);                
            }

            if (!formControl.IsEnabled)
            {
                attributes.Add("disabled", "disabled");
            }

            //Add icheck attr:
            attributes.Add("data-control", "icheck");

            var chkBox = htmlHelper.CheckBoxFor(expresion, attributes);

            return MvcHtmlString.Create(chkBox.ToHtmlString());
        }
    }
}