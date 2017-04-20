using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSimplicity.MVC.DependencyInjection
{
    public class Factory
    {
        /// <summary>
        /// Creates an instance given the fully qualified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public static T CreateInstance<T>(string serviceType)
        {
            return (T)Activator.CreateInstance(Type.GetType(serviceType));
        }
    }
}
