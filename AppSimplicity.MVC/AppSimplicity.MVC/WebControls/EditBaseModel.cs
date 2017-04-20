using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSimplicity.MVC.WebControls
{
    public enum EditModes
    {
        Add,
        Edit
    }

    public abstract class EditBaseModel
    {
        public List<KeyValuePair<string, string>> ErrorDetails { get; set; }

        public string ErrorSummary { get; set; }

        public bool AddAnother { get; set; }

        public bool DisplayAddAnother { get; set; }

        public EditModes EditMode { get; set; }

        public EditBaseModel()
        {
            ErrorDetails = new List<KeyValuePair<string, string>>();
            AddAnother = false;
            DisplayAddAnother = false;
            EditMode = EditModes.Add;
        }
    }
}
