using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Taschenrechner.Tests.XUnit
{
    public class RechnerTests
    {
        [Fact]
        [Trait("XUnit",null)]
        public void Add_2_and_3_results_5()
        {
            // Arrange
            Rechner rechner = new Rechner();

            // Action
            var result = rechner.Add(2, 3);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        [Trait("XUnit",null)]
        public void Add_MINInt_and_N1_throws_OverflowException()
        {
            Rechner rechner = new Rechner();

            Assert.Throws<OverflowException>(() =>
            {
                rechner.Add(-1, Int32.MinValue);
            });
        }

        [Theory]
        [Trait("XUnit",null)]
        [InlineData(12, 3, 15)]
        [InlineData(0, 0, 0)]
        [InlineData(-12, -15, -27)]
        public void Add_TestCasesValues(int z1, int z2, int expectedResult)
        {
            Rechner rechner = new Rechner();

            var result = rechner.Add(z1, z2);

            Assert.Equal(expectedResult, result);
        }
    }
}
