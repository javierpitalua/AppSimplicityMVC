using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSimplicity.MVC
{
    public class Utils
    {
        /// <summary>
        /// Formats a date value into a human readable string
        /// </summary>
        /// <param name="date">For the nullable version</param>
        /// <returns></returns>
        public static string FormatDate(DateTime? date)
        {
            var returnValue = "";
            returnValue = date.HasValue ? Localization.DateTimeFactory.FormatDateTime((DateTime)date) : "";
            return returnValue;
        }

        /// <summary>
        /// Formats a date value into a human readable string
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string FormatDate(DateTime date)
        {
            var returnValue = "";
            returnValue = Localization.DateTimeFactory.FormatDateTime((DateTime)date);
            return returnValue;
        }
    }
}
