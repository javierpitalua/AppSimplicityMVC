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
        #region Provider
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
        #endregion

        /// <summary>
        /// Formats a date value using the current provider
        /// </summary>
        /// <param name="value">The date value to be formatted</param>
        /// <returns></returns>
        public static string FormatDateTime(DateTime value, bool isUTC = true)
        {
            if (value == DateTime.MinValue)
            {
                return "";
            }

            DateTime localeTime = value;

            if (isUTC)
            {
                if (Properties.Settings.Default.UseCultureForDateFormatting)
                {
                    localeTime = TimeZone.CurrentTimeZone.ToLocalTime(value);
                }
            }

            return string.Format(Provider.GetDateTimeFormat(), localeTime);
        }

        /// <summary>
        /// Formats a nullable date value using the current localization provider
        /// </summary>
        /// <param name="value">The date value to be formatted</param>
        /// <returns></returns>
        public static string FormatDateTime(DateTime? value, bool isUTC = true)
        {
            if (value.HasValue)
            {
                return FormatDateTime(value.Value, isUTC);
            }
            return "";
        }

        /// <summary>
        /// Formats a date value using the current provider
        /// </summary>
        /// <param name="value">The date value to be formatted</param>
        /// <returns></returns>
        public static string FormatDate(DateTime value, bool isUTC = true)
        {
            if (value == DateTime.MinValue)
            {
                return "";
            }

            DateTime localeTime = value;
            if (isUTC)
            {
                if (Properties.Settings.Default.UseCultureForDateFormatting)
                {
                    localeTime = TimeZone.CurrentTimeZone.ToLocalTime(value);
                }
            }

            return string.Format(Provider.GetDateFormat(), localeTime);
        }

        /// <summary>
        /// Formats a nullable date value using the current localization provider
        /// </summary>
        /// <param name="value">The date value to be formatted</param>
        /// <returns></returns>
        public static string FormatDate(DateTime? value, bool isUTC = true)
        {
            if (value.HasValue)
            {
                return FormatDate(value.Value);
            }
            return "";
        }
    }

}
