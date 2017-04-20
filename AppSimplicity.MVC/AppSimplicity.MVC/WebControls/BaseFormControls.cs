using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace AppSimplicity.MVC.WebControls
{
    public class BaseFormControls : EditBaseModel
    {
        public string ErrorDescription { get; set; }

        public WebControlsDictionary WebControls { get; set; }

        /// <summary>
        /// Gets the control settings based on the given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public FormControl this[string key]
        {
            get
            {
                if (!this.WebControls.ContainsKey(key))
                {
                    throw new Exception(string.Format("Unable to get control [{0}] there is no such key in dictionary.", key));
                }
                return this.WebControls[key];
            }
        }

        /// <summary>
        /// Clears all property errors
        /// </summary>
        private void ResetErrorDetails()
        {
            foreach (string key in this.WebControls.Keys)
            {
                this[key].ErrorDetails.Clear();
            }
        }

        /// <summary>
        /// Sets all summary details for control dictionary
        /// </summary>
        /// <param name="summary"></param>
        public void SetValidationSummary(List<KeyValuePair<string, string>> errorDetails, string errorDescription = "")
        {
            this.ErrorDescription = errorDescription;
            this.ResetErrorDetails();

            foreach (var detail in errorDetails)
            {
                if (this.WebControls.Contains(detail.Key))
                {
                    if (!this[detail.Key].ErrorDetails.Contains(detail.Value))
                    {
                        this[detail.Key].ErrorDetails.Add(detail.Value);
                    }
                }                
            }
        }

        public void SetValidationSummary(string errorDescription)
        {
            this.ErrorDescription = errorDescription;
            this.ErrorDetails.Clear();
        }

        public BaseFormControls()
        {
            WebControls = new WebControlsDictionary();
        }
    }
}
