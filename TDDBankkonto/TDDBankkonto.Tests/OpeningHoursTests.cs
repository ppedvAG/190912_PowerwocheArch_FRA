using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pose;
using System;
using System.Collections.Generic;
using System.IO;
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
            Assert.AreEqual(expectedResult, oh.IsOpen(new DateTime(year, month, day, hour, minutes, 00)));
        }

        [TestMethod]
        public void IsNowOpen_returns_true_FakesFramework()
        {
            // Problemstellung: DateTime.Now liefert immer ein anderes Ergebnis

            // Fakes-Framework
            using (ShimsContext.Create()) // Hier drinnen gilt "mein" DateTime.Now
            {
                //Konfiguration: 
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(1848, 3, 13, 13, 44, 12); //Montag

                OpeningHours oh = new OpeningHours();
                var fakeDatum = DateTime.Now;

                // Feste Abhängigkeiten testen
                System.IO.Fakes.ShimFile.ExistsString = x => true;

                Assert.IsTrue(File.Exists("7:\\/%//$SADASDß???.txt"));

                Assert.IsTrue(oh.IsNowOpen());
            }
            var echteDatum = DateTime.Now;
        }

        [TestMethod]
        public void IsNowOpen_returns_true_Pose()
        {
            // Konfig-Objekt
            Shim dateShim = Shim.Replace(() => DateTime.Now).With(() => new DateTime(2020, 1, 1, 12, 12, 12));

            // https://github.com/tonerdo/pose

            DateTime datum;
            PoseContext.Isolate(() =>
            {
                datum = DateTime.Now;
            }, dateShim);
        }
    }
}
