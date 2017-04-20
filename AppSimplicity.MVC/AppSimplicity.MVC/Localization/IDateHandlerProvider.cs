using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSimplicity.MVC.Localization
{
    public interface IDateHandlerProvider
    {
        /// <summary>
        /// Gets the format string for date time presentation
        /// </summary>
        /// <returns></returns>
        string GetDateTimeFormat();

        /// <summary>
        /// Gets the format string for date presentation
        /// </summary>
        /// <returns></returns>
        string GetDateFormat();

        /// <summary>
        /// Gets the format string for date client presentation
        /// </summary>
        /// <returns></returns>
        string GetClientDateFormat();

        /// <summary>
        /// Gets the format string for date time client presentation
        /// </summary>        
        string GetClientDateTimeFormat();

        /// <summary>
        /// Parses a date from a string value
        /// </summary>        
        DateTime Parse(string value);
    }
}
