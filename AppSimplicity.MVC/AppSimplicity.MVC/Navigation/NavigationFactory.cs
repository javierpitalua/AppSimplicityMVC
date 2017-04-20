using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSimplicity.MVC.Navigation
{
    public class NavigationFactory
    {
        /// <summary>
        /// Returns the instance of the Navigation Loader
        /// </summary>
        /// <returns></returns>
        public static IMenuLoader LoadNavigationProvider()
        {
            return DependencyInjection.Factory.CreateInstance<IMenuLoader>(Properties.Settings.Default.NavigationProvider);
        }
    }
}
