using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Taschenrechner.Tests.NUnit
{
    [TestFixture] // TestClass
    public class RechnerTests
    {
        [Test]
        [Category("NUnit")]
        public void Add_2_and_3_results_5()
        {
            // Arrange
            Rechner rechner = new Rechner();

            // Action
            var result = rechner.Add(2, 3);

            // Assert
            Assert.AreEqual(5, result);
        }

        [Test]
        [Category("NUnit")]
        public void Add_MINInt_and_N1_throws_OverflowException()
        {
            Rechner rechner = new Rechner();

            Assert.Throws<OverflowException>(() =>
            {
                rechner.Add(-1, Int32.MinValue);
            });
        }

        [Test]
        [Category("NUnit")]
        [TestCase(12, 3, 15)]
        [TestCase(0, 0, 0)]
        [TestCase(-12, -15, -27)]
        public void Add_TestCasesValues(int z1, int z2, int expectedResult)
        {
            Rechner rechner = new Rechner();

            var result = rechner.Add(z1, z2);

            Assert.AreEqual(expectedResult, result);
        }
    }


}
