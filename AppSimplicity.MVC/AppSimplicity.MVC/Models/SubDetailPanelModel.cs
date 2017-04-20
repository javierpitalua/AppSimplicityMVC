using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSimplicity.MVC.Models
{
    public class SubDetailPanelModel
    {
        /// <summary>
        /// Determines if panel should be visible to the user
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// Determines if panel should allow to add records in the view
        /// </summary>
        public bool AllowAdd { get; set; }

        /// <summary>
        /// Determines if panel should allow to edit records in the view
        /// </summary>
        public bool AllowEdit { get; set; }

        /// <summary>
        /// Determines if panel should allow to delete records in the view
        /// </summary>
        public bool AllowDelete { get; set; }

        /// <summary>
        /// Sets if a link to detail shoul be presented in grid:
        /// </summary>
        public bool EnableDetailLink { get; set; }

        /// <summary>
        /// Enable report download button
        /// </summary>
        public bool EnableReportDownload { get; set; }

        public SubDetailPanelModel()
        {
            this.IsVisible = true;
            this.AllowAdd = true;
            this.AllowDelete = true;
            this.AllowEdit = true;
            this.EnableDetailLink = true;
            this.EnableReportDownload = true;
        }
    }
}
