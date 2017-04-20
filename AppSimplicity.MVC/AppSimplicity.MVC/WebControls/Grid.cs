using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppSimplicity.MVC.WebControls
{
    public class Grid
    {
        /// <summary>
        /// Renders a link to sort a grid table
        /// </summary>
        /// <param name="displayName">The display name to be presented</param>
        /// <param name="propertyName">The name of the property that maps the sorting to</param>
        /// <param name="sortedBy">The current sorting value</param>
        /// <param name="sortDirection">If current grid state is sorted, determines which direction is sorted by</param>
        /// <returns></returns>
        public static MvcHtmlString GridHeaderLink(string displayName, string propertyName, string sortedBy, string sortDirection)
        {
            string icon = "";
            string directionAttr = "asc";
            //set icon direction if applies:
            if (sortedBy == propertyName)
            {
                if (sortDirection.ToLower() == "desc")
                {
                    icon = @"&nbsp;<span class=""fa fa-arrow-down""></span>";
                    directionAttr = "asc";
                }
                else
                {
                    icon = @"&nbsp;<span class=""fa fa-arrow-up""></span>";
                    directionAttr = "desc";
                }
            }

            string contenido = string.Format("<div>{0}{1}</div>", displayName, icon);
            string raw = string.Format(@"<a href=""#"" grid-action=""sortby"" property-name=""{1}"" sort-direction=""{2}"">{0}</a>", contenido, propertyName, directionAttr);

            return System.Web.Mvc.MvcHtmlString.Create(raw);
        }
    }
}
