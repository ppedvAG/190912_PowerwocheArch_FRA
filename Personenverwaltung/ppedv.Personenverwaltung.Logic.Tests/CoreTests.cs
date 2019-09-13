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


            Core core = new Core(hardwareMock.Object,null);

            var result = core.RecruitPersonForDepartment(5);

            Assert.Equal(5, result.Count());

            hardwareMock.Verify(x => x.RecruitPerson(), Times.Exactly(5));
        }

        [Fact]
        public void RecruitPersonForDepartment_with_invalid_Argument_throws_ArgumentException()
        {
            var hardwareMock = new Mock<IDevice>(); // erfindet er eine Klasse, die IDevice implementiert
            Core core = new Core(hardwareMock.Object,null);

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

        [Fact]
        public void Core_Can_GetPersonWithHighestBalance()
        {
            var data = new Person[]
                {
                    new Person{FirstName="Tom", LastName="Ate",Age=10,Balance=100},
                    new Person{FirstName="Anna", LastName="Nass",Age=10,Balance=20000000},
                    new Person{FirstName="Peter", LastName="Silie",Age=10,Balance=3000000000},
                };

            var databaseMock = new Mock<IRepository>();
            databaseMock.Setup(x => x.GetAll<Person>())
                .Returns(() => data);

            Core core = new Core(null, databaseMock.Object);

            var result = core.GetPersonWithHighestBalance();
            Assert.Equal(data[2], result);
        }

        [Fact]
        public void Core_Can_RecruitPeopleAndSaveAll()
        {
            int amount = 5;
            var hardwareMock = new Mock<IDevice>();
            var databaseMock = new Mock<IRepository>();

            Core core = new Core(hardwareMock.Object, databaseMock.Object);

            core.RecruitPeopleAndSaveAll(amount);

            // Assert ....

            // Situation 1: Mock für Hardware und Mock für die Datenbank
            // -> UnitTest der Logik-Layer, weil nur der Ablauf der Methode "RecruitPeopleAndSaveAll" getestet wird
            // -> Verify für das Aufrufen der HW und DB Logik

            // Situation 2: Mock für die Datenbank aber mit echer Hardware
            // -> Integrationstest für die Hardware-Ebene
            // -> Mit Verify testen wir, dass die von der echten HW gelieferten Daten zumindest den Add-Befehl der Datenbank triggern

            // Situation 3: Mock für die Hardware aber mit einer echten DB
            // -> Integratinstest für die Datenbanklayer
            // -> Wir testen das Speichern der gefakten daten aus der HW-Mock in der echten Datenbank   
        }
    }
}
