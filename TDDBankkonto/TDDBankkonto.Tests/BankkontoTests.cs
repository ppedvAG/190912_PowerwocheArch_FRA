﻿using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDBankkonto.Tests
{
    [TestClass]
    public class BankkontoTests
    {
        // Bankkonto startet mit 100
        [TestMethod]
        public void Bankkonto_neues_Konto_hat_einen_Kontostand_von_100()
        {
            Bankkonto k = new Bankkonto(); // Standard 100

            Assert.IsNotNull(k);
            Assert.IsTrue(k.Kontostand == 100m);
        }

        [TestMethod]
        public void Bankkonto_neues_Konto_mit_negativem_Wert_aus_Konstruktor_wirft_ArgumentException()
        {
            decimal value = -250_000m;
            Assert.ThrowsException<ArgumentException>(() => new Bankkonto(value));
        }

        [TestMethod]
        public void Bankkonto_neues_Konto_setzt_den_Kontostand_mit_Wert_aus_Konstruktor()
        {
            decimal value = 250_000m;
            Bankkonto k = new Bankkonto(value);

            Assert.IsNotNull(k);
            Assert.IsTrue(k.Kontostand == value);
        }

        [TestMethod]
        public void Einzahlen_mit_gültigem_Wert_erhöht_Kontostand()
        {
            Bankkonto k = new Bankkonto();

            decimal oldValue = k.Kontostand;
            decimal value = 250m;
            k.Einzahlen(value);

            Assert.AreEqual(oldValue + value, k.Kontostand);

            oldValue = k.Kontostand;
            k.Einzahlen(value);

            Assert.AreEqual(oldValue + value, k.Kontostand);
        }

        [TestMethod]
        public void Einzahlen_mit_negativem_Wert_wirft_ArgumentException()
        {
            Bankkonto k = new Bankkonto();

            decimal oldValue = k.Kontostand;
            decimal value = -250m;

            Assert.ThrowsException<ArgumentException>(() => k.Einzahlen(value));
        }

        [TestMethod]
        public void Einzahlen_mit_0_verändert_den_Kontostand_nicht()
        {
            Bankkonto k = new Bankkonto();

            decimal oldValue = k.Kontostand;
            decimal value = 0;

            k.Einzahlen(value);
            Assert.AreEqual(oldValue, k.Kontostand);
        }

        [TestMethod]
        public void Abheben_mit_gültigem_Wert_verringert_Kontostand()
        {
            Bankkonto k = new Bankkonto(550m);

            decimal oldValue = k.Kontostand;
            decimal value = 250m;
            k.Abheben(value);

            Assert.AreEqual(oldValue - value, k.Kontostand);

            oldValue = k.Kontostand;
            k.Abheben(value);

            Assert.AreEqual(oldValue - value, k.Kontostand);
        }

        [TestMethod]
        public void Abheben_mit_resultierendem_Kontostand_unter_0_wirft_InvalidOperationException()
        {
            Bankkonto k = new Bankkonto(250m);

            decimal value = 300m;
            Assert.ThrowsException<InvalidOperationException>(() => k.Abheben(value));
        }

        [TestMethod]
        public void Abheben_mit_negativem_Wert_wirft_ArgumentException()
        {
            Bankkonto k = new Bankkonto(500m);

            decimal oldValue = k.Kontostand;
            decimal value = -250m;

            Assert.ThrowsException<ArgumentException>(() => k.Abheben(value));
        }

        [TestMethod]
        public void Abheben_mit_0_verändert_den_Kontostand_nicht()
        {
            Bankkonto k = new Bankkonto(500m);

            decimal oldValue = k.Kontostand;
            decimal value = 0;

            k.Abheben(value);
            Assert.AreEqual(oldValue, k.Kontostand);
        }

        [TestMethod]
        public void Bankkonto_FakeTest_Kontostand_ist_50_000_000()
        {
            using(ShimsContext.Create())
            {
                TDDBankkonto.Fakes.ShimBankkonto.AllInstances.KontostandGet = x => 50_000_000;

                var konto = new Bankkonto(); // 100m in Wirklichkeit

                Assert.AreEqual(50_000_000, konto.Kontostand);
            }
        }

        [TestMethod]
        public void Reichtum_Alle_Fälle_Testen()
        {
            using(ShimsContext.Create())
            {
                Bankkonto konto = new Bankkonto(0);

                TDDBankkonto.Fakes.ShimBankkonto.AllInstances.KontostandGet = x => 0;
                Assert.AreEqual(Reichtum.Nichts, konto.Reichtum);

                TDDBankkonto.Fakes.ShimBankkonto.AllInstances.KontostandGet = x => 90;
                Assert.AreEqual(Reichtum.Arm, konto.Reichtum);

                TDDBankkonto.Fakes.ShimBankkonto.AllInstances.KontostandGet = x => 5900;
                Assert.AreEqual(Reichtum.Mittelschicht, konto.Reichtum);

                TDDBankkonto.Fakes.ShimBankkonto.AllInstances.KontostandGet = x => 50_000_000;
                Assert.AreEqual(Reichtum.Obere1Prozent, konto.Reichtum);
            }

        }
    }
}
