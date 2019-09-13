using ppedv.Personenverwaltung.Logik;
using ppedv.PersonenVerwaltung.Logic.Hardware.RoboTech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ppedv.Personenverwaltung.Logic.Tests
{
    public class CoreTests
    {
        [Fact]
        public void RecruitPersonForDepartment_Can_Recruit_5_Persons()
        {
            Core core = new Core(new XingRecruiter3000());

            var result = core.RecruitPersonForDepartment(5);

            Assert.Equal(5, result.Count());
        }
    }
}
