using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Personenverwaltung.Domain;

namespace ppedv.Personenverwaltung.Data.EF.Tests
{
    [TestClass]
    public class EFContextTests
    {
        const string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Personenverwaltung_Test;Trusted_Connection=true;AttachDbFileName=C:\temp\Personenverwaltung_TestDB.mdf";
        [TestMethod]
        public void EFContext_Can_Create_Context()
        {
            var context = new EFContext(connectionString);
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void EFContext_Can_Create_DB()
        {
            using (var context = new EFContext(connectionString))
            {
                if (context.Database.Exists())
                    context.Database.Delete();

                Assert.IsFalse(context.Database.Exists());
                context.Database.Create();
                Assert.IsTrue(context.Database.Exists());
            }
        }

        // Create/Read/Update/Delete usw...
        // CRUD
        [TestMethod]
        public void EFContext_Can_CRUD_Person()
        {
            Person p = new Person { FirstName = "Tom", LastName = "Ate", Age = 10, Balance = 100 };
            string newLastName = "Atinger";
            // Test: Create
            using(var context = new EFContext(connectionString))
            {
                context.Person.Add(p);
                context.SaveChanges(); 
            }
            // Neuer Kontext: 
            using (var context = new EFContext(connectionString))
            {
                // Check für Create
                var loadedPerson = context.Person.Find(p.ID);
                Assert.AreEqual(p.FirstName, loadedPerson.FirstName); // Korrekt: ObjectGraph

                loadedPerson.LastName = newLastName;
                context.SaveChanges();
            }
            // Neuer Kontext: 
            using (var context = new EFContext(connectionString))
            {
                // Check für Update
                var loadedPerson = context.Person.Find(p.ID);
                Assert.AreEqual(newLastName, loadedPerson.LastName);

                // Delete
                context.Person.Remove(loadedPerson);
                context.SaveChanges();
            }
            // Neuer Kontext: 
            using (var context = new EFContext(connectionString))
            {
                // Check für Update
                var loadedPerson = context.Person.Find(p.ID);
                Assert.IsNull(loadedPerson);
            }
        }
    }
}
