using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSimplicity.MVC.Navigation
{
    public interface IMenuLoader
    {
        NavigationModel LoadNavigationModel(string culture, string currentPath);
    }
}
