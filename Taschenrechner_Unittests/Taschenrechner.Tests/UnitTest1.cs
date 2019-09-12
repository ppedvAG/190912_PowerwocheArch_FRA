﻿using System;
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

        // Normalfall
        // Null-Fall (Parameter: null, 0)
        // Grenz/Extremfälle

        [TestMethod]
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
        public void Add_MAXInt_and_1_throws_OverflowException()
        {
            Rechner rechner = new Rechner();

            Assert.ThrowsException<OverflowException>(() =>
            {
                rechner.Add(1, Int32.MaxValue);
            });
        }

        [TestMethod]
        public void Add_MINInt_and_N1_throws_OverflowException()
        {
            Rechner rechner = new Rechner();

            Assert.ThrowsException<OverflowException>(() =>
            {
                rechner.Add(-1, Int32.MinValue);
            });
        }

    }
}
