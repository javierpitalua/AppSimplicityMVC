using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSimplicity.MVC.Models
{
    public class SubDetailPanel
    {
        /// <summary>
        /// Determines if panel should allow adding new child records
        /// </summary>
        public bool AllowAdd { get; set; }

        /// <summary>
        /// Determines if panel should allow adding new child records
        /// </summary>
        public bool AllowEdit { get; set; }

        /// <summary>
        /// Determines if panel should allow adding new child records
        /// </summary>
        public bool AllowDelete { get; set; }

        public SubDetailPanel()
        {
            AllowAdd = true;
            AllowDelete = true;
            AllowEdit = true;
        }
    }
}
