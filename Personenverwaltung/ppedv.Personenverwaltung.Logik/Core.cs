using ppedv.Personenverwaltung.Domain;
using ppedv.Personenverwaltung.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Personenverwaltung.Logik
{
    public class Core
    {
        public Core(IDevice device, IRepository repo)
        {
            this.device = device;
            this.repo = repo;
        }
        private IDevice device;
        private IRepository repo;

        // In der Software wird die Hardware angesteuert
        public IEnumerable<Person> RecruitPersonForDepartment(int amount)
        {
            if (amount < 0)
                throw new ArgumentException();
            List<Person> newMembers = new List<Person>();
            for (int i = 0; i < amount; i++)
            {
                newMembers.Add(device.RecruitPerson());
            }
            return newMembers;
        }

        // Logik, die auf die DB zugreift:
        public IEnumerable<Person> GetAllPeople()
        {
            return repo.GetAll<Person>();
        }
        public Person GetPersonWithHighestBalance()
        {
            return repo.GetAll<Person>()
                       .OrderByDescending(x => x.Balance)
                       .First();
        }

        // Prozess, der auf DB und auf HW zugreift

        public int SaveRecruitedPerson(IEnumerable<Person> peopleToSave)
        {
            int savedPeople = 0;
            foreach (var item in peopleToSave)
            {
                try
                {
                    repo.Add<Person>(item);
                    savedPeople++;
                }
                catch (Exception)
                {
                    // Person wird nicht gespeichert weil doppelt o.Ä.
                }
            }
            return savedPeople;
        }

        public void RecruitPeopleAndSaveAll(int amount)
        {
            var people = RecruitPersonForDepartment(amount); // Befehl HW
            int totalSaved = SaveRecruitedPerson(people);    // Befehl DB
            if (totalSaved == amount)
                ; // alle gespeichert
            else
                ; // nicht alle gespeichert
        }
    }
}
