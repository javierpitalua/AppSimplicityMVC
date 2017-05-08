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
        /// Determines if a given type is a Date
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public static bool IsADateTimeType(Type objectType)
        {
            var returnValue = false;

            if (objectType == typeof(DateTime))
            {
                returnValue = true;
            }

            if (objectType == typeof(DateTime?))
            {
                returnValue = true;
            }

            return returnValue;
        }

        /// <summary>
        /// Determines if a given object is a DateTime value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsADateTimeValue(object value)
        {
            return IsADateTimeType(value.GetType());
        }

        /// <summary>
        /// Formats a date value into a human readable string
        /// </summary>
        /// <param name="date">For the nullable version</param>
        /// <returns></returns>
        public static string FormatDateTime(DateTime? date, bool isUTC = true)
        {
            return Localization.DateTimeFactory.FormatDateTime(date);
        }

        /// <summary>
        /// Formats a date value into a human readable string
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string FormatDateTime(DateTime date, bool isUTC = true)
        {
            return Localization.DateTimeFactory.FormatDateTime(date);
        }

        /// <summary>
        /// Formats a date value into a human readable string
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string FormatDate(DateTime date, bool isUTC = true)
        {
            return Localization.DateTimeFactory.FormatDate(date);
        }

        /// <summary>
        /// Formats a date value into a human readable string
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string FormatDate(DateTime? date, bool isUTC = true)
        {
            return Localization.DateTimeFactory.FormatDate(date);
        }

        /// <summary>
        /// Formats a value using the given global currency format
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FormatCurrency(object value)
        {
            return string.Format(Properties.Settings.Default.GlobalCurrencyFormat, value);
        }
    }
}
