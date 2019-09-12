using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Taschenrechner.Tests
{
    [TestClass]
    public class RechnerTests
    {
        [TestMethod]
        public void Add_2_and_3_results_5()
        {
            // Arrange
            Rechner rechner = new Rechner();

            // Action
            var result = rechner.Add(2, 3);

            // Assert
            Assert.AreEqual(5, result);
        }
    }
}
