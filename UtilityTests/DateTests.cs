using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Tests
{
    [TestClass()]
    public class DateTests
    {
        [TestMethod()]
        public void DateTimeForSQLTest()
        {
            string sqlFormattedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            DateTime myDate = DateTime.ParseExact(Date.DateTimeForSQL(), "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None);

            Assert.AreEqual(sqlFormattedDate, myDate.ToString("yyyy-MM-dd HH:mm"));
            System.Threading.Thread.Sleep(2000);
            Assert.AreNotEqual(sqlFormattedDate, Date.DateTimeForSQL());
        }

        [TestMethod()]
        public void ConvertDateToDatetimeTest()
        {
            DateTime dateTime;
            DateTime.TryParseExact(24 + "/" + 10 + "/" + 1991, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);

            Assert.AreEqual(dateTime, Date.ConvertDateToDatetime("24", "10", "1991"));
            Assert.AreNotEqual(dateTime, Date.ConvertDateToDatetime("24", "10", "2018"));
        }

        [TestMethod()]
        public void ConvertDateToDatetimeTest1()
        {
            DateTime dateTime;
            DateTime.TryParseExact(24 + "/" + 10 + "/" + 1991, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);

            Assert.AreEqual(dateTime, Date.ConvertDateToDatetime(24, 10, 1991));
            Assert.AreNotEqual(dateTime, Date.ConvertDateToDatetime("24", "10", "2018"));
        }
    }
}