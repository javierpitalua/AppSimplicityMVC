using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppSimplicity.MVC.WebControls
{
    public class ControlSummary 
    {
        public FormControl Control { get; set; }        

        public ControlSummary(FormControl control)  
        {
            Control = control;
        }

        public System.Web.Mvc.MvcHtmlString Render()
        {
            StringBuilder sb = new StringBuilder();
            MvcHtmlString returnValue = MvcHtmlString.Create("");

            if (Control.ErrorDetails.Count > 0)
            {
                foreach (string errorDetail in Control.ErrorDetails)
                {
                    sb.AppendFormat("<li><span class='label label-danger'>{0}</span></li>", errorDetail);
                }

                returnValue = MvcHtmlString.Create(string.Format("<div style='padding-top:5px;'><ul class='list-inline'>{0}</ul></div>", sb.ToString()));
            }

            return returnValue;
        }
    }
}
