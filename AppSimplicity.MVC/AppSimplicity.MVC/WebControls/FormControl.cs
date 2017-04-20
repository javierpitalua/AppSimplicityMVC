using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppSimplicity.MVC.WebControls
{
    [Serializable]
    public class FormControl
    {
        /// <summary>
        /// The name of the property that maps to the control
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Sets the placeholder text
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>
        /// Determines if control value can be modified
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// Determines if control should be presented on UI
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// Determines if control should be highlighted for user interaction
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// If enabled, hint text will be displayed below of the UI control.
        /// </summary>
        public string Hint { get; set; }

        /// <summary>
        /// Determines if hint text should be rendered on control
        /// </summary>
        public bool DisplayHint { get; set; }

        /// <summary>
        /// Allow to get items that will be used to populate a combo box or to present information in the field.
        /// </summary>
        public string RequestUrl { get; set; }

        public List<string> ErrorDetails { get; set; }

        /// <summary>
        /// Determines whether if control must display a failure status.  It does this by evaluating the ErrorDetails property.
        /// </summary>
        /// <returns></returns>
        public bool HasError() {
            return (this.ErrorDetails.Count > 0);
        }

        public FormControl(string propertyName)
        {
            PropertyName = propertyName;
            IsEnabled = true;
            IsVisible = true;
            IsValid = true;
            ErrorDetails = new List<string>();         
        }
    }
}
