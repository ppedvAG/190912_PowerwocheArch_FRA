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
        public Core(IDevice device)
        {
            this.device = device;
        }
        private IDevice device;

        // In der Software wird die Hardware angesteuert
        public IEnumerable<Person> RecruitPersonForDepartment(int amount)
        {
            List<Person> newMembers = new List<Person>();
            for (int i = 0; i < amount; i++)
            {
                newMembers.Add(device.RecruitPerson());
            }
            return newMembers;
        }
    }
}
