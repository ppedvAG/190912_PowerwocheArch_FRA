using Moq;
using ppedv.Personenverwaltung.Domain;
using ppedv.Personenverwaltung.Domain.Interfaces;
using ppedv.Personenverwaltung.Logik;
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
        // https://github.com/Moq/moq4/
        // https://github.com/Moq/moq4/wiki/Quickstart
        [Fact]
        public void RecruitPersonForDepartment_Can_Recruit_5_Persons()
        {
            var hardwareMock = new Mock<IDevice>(); // erfindet er eine Klasse, die IDevice implementiert
            hardwareMock.SetupSequence(x => x.RecruitPerson())
                        .Returns(() => new Person { FirstName = "Tom", LastName = "Ate", Age = 10, Balance = 100 })
                        .Returns(() => new Person { FirstName = "Anna", LastName = "Nass", Age = 10, Balance = 100 })
                        .Returns(() => new Person { FirstName = "Peter", LastName = "Silie", Age = 10, Balance = 100 })
                        .Returns(() => new Person { FirstName = "Martha", LastName = "Pfahl", Age = 10, Balance = 100 });


            Core core = new Core(hardwareMock.Object);

            var result = core.RecruitPersonForDepartment(5);

            Assert.Equal(5, result.Count());

            hardwareMock.Verify(x => x.RecruitPerson(), Times.Exactly(5));
        }

        [Fact]
        public void RecruitPersonForDepartment_with_invalid_Argument_throws_ArgumentException()
        {
            var hardwareMock = new Mock<IDevice>(); // erfindet er eine Klasse, die IDevice implementiert
            Core core = new Core(hardwareMock.Object);

            Assert.Throws<ArgumentException>(() => core.RecruitPersonForDepartment(-5));

            hardwareMock.Verify(x => x.RecruitPerson(), Times.Never);
        }

        //class DLLWrapper
        //{
        //    public DLLWrapper()
        //    {
        //        // DLL laden und comObject befüllen
        //    }
        //    private dynamic comObject; // <--- DLL

        //    public bool MachWas()
        //    {
        //        return comObject.FunktionAusDLL1();
        //    }
        //    public bool MachWas2()
        //    {
        //        return comObject.FunktionAusDLL2();
        //    }
        //}
    }
}
