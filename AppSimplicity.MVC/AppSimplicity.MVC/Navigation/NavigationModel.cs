using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSimplicity.MVC.Navigation
{
    public class NavigationModel
    {
        public List<MenuItem> MenuItems { get; set; }

        public NavigationModel()
        {
            MenuItems = new List<MenuItem>();
        }
    }
}
