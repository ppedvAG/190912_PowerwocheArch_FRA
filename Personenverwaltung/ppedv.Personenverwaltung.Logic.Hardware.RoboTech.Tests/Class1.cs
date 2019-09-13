using NUnit.Framework;
using ppedv.PersonenVerwaltung.Logic.Hardware.RoboTech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Personenverwaltung.Logic.Hardware.RoboTech.Tests
{
    [TestFixture]
    public class XingRecruiter3000Tests
    {
        [Test]
        public void Can_Create_Person()
        {
            var recruiter = new XingRecruiter3000();
            var person = recruiter.RecruitPerson();
            Assert.NotNull(person);
        }
    }
}
