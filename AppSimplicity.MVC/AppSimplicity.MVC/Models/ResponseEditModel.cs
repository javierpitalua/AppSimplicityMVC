using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSimplicity.MVC.Models
{
    public class ResponseEditModel
    {
        public int EntityId { get; set; }

        public string ViewContent { get; set; }

        public bool CloseDialog { get; set; }

        public bool OperationSuccesful { get; set; }

        public string ErrorMessage { get; set; }

        public string ExceptionDetails { get; set; }

        public ResponseEditModel()
        {
            CloseDialog = true;
        }
    }
}
