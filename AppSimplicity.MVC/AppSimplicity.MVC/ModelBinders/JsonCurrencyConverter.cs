using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppSimplicity.MVC.ModelBinders
{
    public class JsonCurrencyConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            var returnValue = false;

            if (objectType == typeof(decimal))
            {
                returnValue = true;
            }

            if (objectType == typeof(double))
            {
                returnValue = true;
            }

            if (objectType == typeof(int))
            {
                returnValue = true;
            }

            return returnValue;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (CanConvert(value.GetType()))
            {
                writer.WriteValue(Utils.FormatCurrency(value));
            }
        }
    }
}
