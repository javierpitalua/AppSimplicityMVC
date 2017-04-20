using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSimplicity.MVC.Models
{
    public class DetailModel
    {
        public int EntityId { get; set; }
        public bool AllowEdit { get; set; }

        public bool AllowDelete { get; set; }

        public DetailModel()
        {
            this.AllowEdit = true;
            this.AllowDelete = true;
        }
    }

    public abstract class IndexBaseModel
    {
        public bool AllowAdd { get; set; }

        public bool AllowEdit { get; set; }

        public bool AllowDelete { get; set; }

        public IndexBaseModel()
        {
            this.AllowAdd = true;
            this.AllowDelete = true;
            this.AllowEdit = true;
        }
    }
}
