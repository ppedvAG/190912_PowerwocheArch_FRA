using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Taschenrechner.Tests
{
    [TestClass]
    public class RechnerTests
    {
        [TestMethod]
        [TestCategory("MSTest")]
        public void Add_2_and_3_results_5()
        {
            // Arrange
            Rechner rechner = new Rechner();

            // Action
            var result = rechner.Add(2, 3);

            // Assert
            Assert.AreEqual(5, result);
        }

        // Normalfall
        // Null-Fall (Parameter: null, 0)
        // Grenz/Extremfälle

        [TestMethod]
        [TestCategory("MSTest")]
        public void Add_0_and_0_results_0()
        {
            // Arrange
            Rechner rechner = new Rechner();

            // Action
            var result = rechner.Add(0, 0);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("MSTest")]
        public void Add_MAXInt_and_1_throws_OverflowException()
        {
            Rechner rechner = new Rechner();

            Assert.ThrowsException<OverflowException>(() =>
            {
                rechner.Add(1, Int32.MaxValue);
            });
        }

        [TestMethod]
        [TestCategory("MSTest")]
        public void Add_MINInt_and_N1_throws_OverflowException()
        {
            Rechner rechner = new Rechner();

            Assert.ThrowsException<OverflowException>(() =>
            {
                rechner.Add(-1, Int32.MinValue);
            });
        }

        [TestMethod]
        [TestCategory("MSTest")]
        [DataRow(12,3,15)]
        [DataRow(0,0,0)]
        [DataRow(-12,-15,-27)]
        public void Add_TestCasesValues(int z1, int z2, int expectedResult)
        {
            Rechner rechner = new Rechner();

            var result = rechner.Add(z1, z2);

            Assert.AreEqual(expectedResult, result);
        }

    }
}
