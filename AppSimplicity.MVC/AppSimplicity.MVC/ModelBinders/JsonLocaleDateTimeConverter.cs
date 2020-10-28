using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppSimplicity.MVC.ModelBinders
{

    #region DateConverter
    /// <summary>
    /// The intended purpose of this class is to be used as attribute to serialize timeStamps from UTC to Local culture values
    /// </summary>
    public class JsonLocaleDateConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return Utils.IsADateTimeType(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value.GetType() == typeof(DateTime))
            {
                writer.WriteValue(Utils.FormatDate((DateTime)value, true));
            }
        }
    }


    /// <summary>
    /// The intended purpose of this class is to be used as attribute to serialize timeStamps from UTC to Local culture values
    /// </summary>
    public class JsonLocaleDateTimeConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
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

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value.GetType() == typeof(DateTime))
            {
                writer.WriteValue(Utils.FormatDateTime((DateTime)value, true));
            }
        }
    }
    #endregion


    /// <summary>
    /// The intended purpose of this class is to be used as attribute to serialize timeStamps from UTC to Local culture values
    /// </summary>
    public class JsonDateTimeConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
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

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value.GetType() == typeof(DateTime))
            {
                writer.WriteValue(Utils.FormatDateTime((DateTime)value, false));
            }
        }
    }
}
