using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace AppSimplicity.MVC
{
    public class JsonNetResult : System.Web.Mvc.JsonResult
    {
        public object Instance { get; set; }

        public override void ExecuteResult(System.Web.Mvc.ControllerContext context)
        {
            var response = context.HttpContext.Response;
            var dateFormat = Localization.DateTimeFactory.Provider.GetClientDateTimeFormat();

            response.ContentType = "application/json";

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            if (Instance == null) return;

            var writer = new JsonTextWriter(response.Output) { Formatting = Formatting.None };
            var serializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                Formatting = Formatting.None,
                DateFormatString = dateFormat
            });

            serializer.Serialize(writer, Instance);
            writer.Flush();
            writer.Close();
        }
    }
}
