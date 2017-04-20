using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.UI.Extensions
{
    public static class DateExtensions
    {
        /// <summary>
        /// Determines if a given date contains also time information
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ContainsTimeInformation(this DateTime value)
        {
            return (value.TimeOfDay.TotalSeconds > 0);
        }
    }
}
