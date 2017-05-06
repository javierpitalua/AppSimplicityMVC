using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppSimplicity.MVC.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LocalizationDateFormat()
        {
            var utcTimeStamp = DateTime.UtcNow;
            string output = AppSimplicity.MVC.Utils.FormatDate(utcTimeStamp);
            Console.WriteLine("Utc is: {0}, which converts to: {1}", utcTimeStamp, output);
        }
    }
}
