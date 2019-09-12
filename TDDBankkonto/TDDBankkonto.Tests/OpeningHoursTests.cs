using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBankkonto.Tests
{
    [TestClass]
    public class OpeningHoursTests
    {
        [TestMethod]
        [DataRow(7, 1, 2019, 10, 29, false)] // MO
        [DataRow(7, 1, 2019, 10, 30, true)] // MO
        [DataRow(7, 1, 2019, 18, 59, true)] // MO
        [DataRow(7, 1, 2019, 19, 0, false)] // MO
        [DataRow(8, 1, 2019, 10, 29, false)] //DI
        [DataRow(8, 1, 2019, 10, 30, true)] // DI
        [DataRow(8, 1, 2019, 18, 59, true)] // DI
        [DataRow(8, 1, 2019, 19, 0, false)] // DI
        [DataRow(9, 1, 2019, 10, 29, false)] //MI
        [DataRow(9, 1, 2019, 10, 30, true)] // MI
        [DataRow(9, 1, 2019, 18, 59, true)] // MI
        [DataRow(9, 1, 2019, 19, 0, false)] // MI
        [DataRow(10, 1, 2019, 10, 29, false)] //DO
        [DataRow(10, 1, 2019, 10, 30, true)] // DO
        [DataRow(10, 1, 2019, 18, 59, true)] // DO
        [DataRow(10, 1, 2019, 19, 0, false)] // DO
        [DataRow(11, 1, 2019, 10, 29, false)] //FR
        [DataRow(11, 1, 2019, 10, 30, true)] // FR
        [DataRow(11, 1, 2019, 18, 59, true)] // FR
        [DataRow(11, 1, 2019, 19, 0, false)] // FR
        [DataRow(12, 1, 2019, 10, 29, false)] //SA
        [DataRow(12, 1, 2019, 10, 30, true)] // SA
        [DataRow(12, 1, 2019, 13, 59, true)] // SA
        [DataRow(12, 1, 2019, 14, 0, false)] // SA
        [DataRow(13, 1, 2019, 10, 29, false)] //SO
        [DataRow(13, 1, 2019, 10, 30, false)] // SO
        [DataRow(13, 1, 2019, 13, 59, false)] // SO
        [DataRow(13, 1, 2019, 14, 0, false)] // SO
        public void IsOpen_returns_correct_value(int day, int month, int year, int hour, int minutes, bool expectedResult)
        {
            OpeningHours oh = new OpeningHours();
            Assert.AreEqual(expectedResult, oh.IsOpen(new DateTime(year,month,day,hour,minutes,00)));
        }

        [TestMethod]
        public void IsNowOpen_returns_true()
        {
            // Problemstellung: DateTime.Now liefert immer ein anderes Ergebnis
            OpeningHours oh = new OpeningHours();
            Assert.IsTrue(oh.IsNowOpen());
        }
    }
}
