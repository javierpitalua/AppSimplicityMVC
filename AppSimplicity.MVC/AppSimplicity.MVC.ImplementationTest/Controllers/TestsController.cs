using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppSimplicity.MVC.ModelBinders;

namespace AppSimplicity.MVC.ImplementationTest.Controllers
{
    public class DataToSerialize
    {
        public string Descripcion { get; set; }

        [JsonConverter(typeof(JsonLocaleDateTimeConverter))]
        public DateTime NormalDateTime { get; set; }

        [JsonConverter(typeof(JsonLocaleDateConverter))] //utc
        public DateTime? NullableDateTime { get; set; }

        [JsonConverter(typeof(JsonLocaleDateTimeConverter))] //utct
        public DateTime NormalDate { get; set; }

        [JsonConverter(typeof(JsonLocaleDateConverter))]
        public DateTime? NullableDate { get; set; }

        [JsonConverter(typeof(JsonCurrencyConverter))]
        public Decimal CurrencyValue { get; set; }

        [JsonConverter(typeof(JsonCurrencyConverter))]
        public Decimal? CurrencyNullable { get; set; }

        public DataToSerialize(string descripcion, DateTime normalDate, DateTime? nullableDate)
        {
            this.Descripcion = descripcion;
            this.NormalDate = normalDate;
            this.NullableDate = nullableDate;
        }
    }

    public class TestsController : AppSimplicity.MVC.BaseController
    {
        // GET: Tests
        public ActionResult DateTimeLocalization()
        {
            return View();
        }

        [HttpGet]
        public JsonNetResult SerializeModelToLocale()
        {
            var list = new List<DataToSerialize>();
            list.Add(new DataToSerialize("Testing nullable date", DateTime.UtcNow, DateTime.Now)
            {   
                CurrencyValue = 10055.3332M,
                NormalDate = DateTime.UtcNow,
                NormalDateTime = DateTime.Now
            });
            //list.Add(new DataToSerialize("Testing nullable date", DateTime.UtcNow, DateTime.Now) { CurrencyValue = 10332055.3332M });
            //list.Add(new DataToSerialize("Testing nullable date", DateTime.UtcNow, DateTime.Now) { CurrencyValue = 1.3332M });
            //list.Add(new DataToSerialize("Testing nullable date", DateTime.UtcNow, DateTime.Now) { CurrencyValue = 1.83M });
            //list.Add(new DataToSerialize("Testing nullable date", DateTime.UtcNow, DateTime.Now) { CurrencyValue = 1.99M });
            //list.Add(new DataToSerialize("Testing nullable date", DateTime.UtcNow, DateTime.Now) { CurrencyValue = 1.000001M });
            return ToJson(new { @data = list });
        }
    }
}