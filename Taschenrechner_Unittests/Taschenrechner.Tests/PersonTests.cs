using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Equals_with_null_returns_false()
        {
            Person p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            Person p2 = null;

           Assert.IsFalse(p1.Equals(p2));
        }

        [TestMethod]
        public void Equals_with_shallow_copy_returns_true()
        {
            Person p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            Person p2 = p1; // Referenzkopie

            Assert.IsTrue(p1.Equals(p2));
        }

        [TestMethod]
        public void Equals_with_hard_copy_returns_true()
        {
            Person p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            Person p2 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };

            Assert.IsTrue(p1.Equals(p2));
        }
        [TestMethod]
        public void Equals_with_wrong_person_returns_false()
        {
            Person p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            Person p2 = new Person { Vorname = "Anna", Nachname = "Nass", Alter = 10, Kontostand = 100 };

            Assert.IsFalse(p1.Equals(p2));
        }
        [TestMethod]
        public void Equals_with_wrong_type_returns_false()
        {
            Person p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            StringBuilder sb = new StringBuilder();

            Assert.IsFalse(p1.Equals(sb));
        }
    }
}
