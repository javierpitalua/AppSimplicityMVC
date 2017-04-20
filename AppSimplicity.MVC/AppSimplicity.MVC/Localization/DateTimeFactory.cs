using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.UI.Extensions;

namespace AppSimplicity.MVC.Localization
{
    public class DateTimeFactory
    {
        private static IDateHandlerProvider _CurrentInstance;
        /// <summary>
        /// Instantiates the dateformat localization provider
        /// </summary>
        /// <returns></returns>
        public static IDateHandlerProvider Provider
        {
            get
            {
                if (_CurrentInstance == null)
                {
                    _CurrentInstance = DependencyInjection.Factory.CreateInstance<IDateHandlerProvider>(Properties.Settings.Default.DateHandlerProvider);
                }
                return _CurrentInstance;
            }
        }

        /// <summary>
        /// Formats a date value using the current provider
        /// </summary>
        /// <param name="value">The date value to be formatted</param>
        /// <returns></returns>
        public static string FormatDateTime(DateTime value)
        {
            if (value == DateTime.MinValue)
            {
                return "";
            }

            return string.Format(Provider.GetDateTimeFormat(), value);
        }

        /// <summary>
        /// Formats a nullable date value using the current localization provider
        /// </summary>
        /// <param name="value">The date value to be formatted</param>
        /// <returns></returns>
        public static string FormatDateTime(DateTime? value, bool removeTimeIfNotPresent = true)
        {
            if (value.HasValue)
            {
                if (removeTimeIfNotPresent)
                {
                    if (value.Value.ContainsTimeInformation())
                    {
                        return FormatDateTime(value.Value);
                    }
                    else
                    {
                        return string.Format(Provider.GetDateFormat(), value.Value);
                    }
                }
                else
                {
                    return FormatDateTime(value.Value);
                }
            }

            return "";
        }
    }

}
