using ppedv.Personenverwaltung.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Personenverwaltung.Data.EF
{
    public class EFContext : DbContext
    {
        // Minimalkonfiguration
        public EFContext() : this(@"Server=(localdb)\MSSQLLocalDB;Database=Personenverwaltung_Produktion;Trusted_Connection=true;AttachDbFileName=C:\temp\Personenverwaltung.mdf") {}
        public EFContext(string connectionString) : base(connectionString){}

        public DbSet<Person> Person { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Company> Company { get; set; }
    }
}
