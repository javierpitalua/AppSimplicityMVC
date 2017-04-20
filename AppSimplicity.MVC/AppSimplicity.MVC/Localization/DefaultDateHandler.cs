using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace AppSimplicity.MVC.Localization
{
    public class DefaultDateHandler : IDateHandlerProvider
    {
        private Dictionary<string, DateFormatLocalization> Locale;
        public DefaultDateHandler()
        {
            Locale = new Dictionary<string, DateFormatLocalization>();

            // Add english localization:
            Locale.Add("en", new DateFormatLocalization()
            {
                DateFormat = "{0:MM/dd/yyyy}",
                DateTimeFormat = "{0:MM/dd/yyyy hh:mmtt}",
                ParseDateTimeFormat = "0:MM/dd/yyyy hh:mmtt",
                DateClientFormat = "MM/dd/yyyy",
                DateTimeClientFormat = "MM/dd/yyyy hh:mmtt"
            });

            // Add spanish localization:
            Locale.Add("es", new DateFormatLocalization()
            {
                DateFormat = "{0:dd/MM/yyyy}",
                DateTimeFormat = "{0:dd/MM/yyyy hh:mmtt}",
                ParseDateTimeFormat = "dd/MM/yyyy hh:mmtt",
                DateClientFormat = "dd/MM/yyyy",
                DateTimeClientFormat = "dd/MM/yyyy hh:mmtt"
            });
        }

        /// <summary>
        /// This gets the current culture
        /// </summary>
        /// <returns></returns>
        private string getCurrentLocale()
        {
            var returnValue = "en";
            var culture = System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower();

            if (culture.StartsWith("es"))
            {
                returnValue = "es";
            }

            return returnValue;
        }

        public string GetDateTimeFormat()
        {
            return this.Locale[getCurrentLocale()].DateTimeFormat;
        }

        public string GetDateFormat()
        {
            return this.Locale[getCurrentLocale()].DateFormat;
        }

        public string GetClientDateFormat()
        {
            return this.Locale[getCurrentLocale()].DateClientFormat;
        }

        public string GetClientDateTimeFormat()
        {
            return this.Locale[getCurrentLocale()].DateTimeClientFormat;
        }

        public DateTime Parse(string value)
        {
            DateTime returnValue;

            try
            {
                var locale = this.Locale[this.getCurrentLocale()];
                returnValue = DateTime.ParseExact(value, locale.ParseDateTimeFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                returnValue = DateTime.MinValue;
            }

            return returnValue;
        }
    }
}
