using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSimplicity.MVC.Navigation
{
    public class MenuItem
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public bool Selected { get; set; }
        public string Icon { get; set; }
        public string Roles { get; set; }
        public string Target { get; set; }

        public string Class { get; set; }   

        public List<MenuItem> MenuItems { get; set; }

        public MenuItem()
        {
            MenuItems = new List<MenuItem>();
        }
    }
}
