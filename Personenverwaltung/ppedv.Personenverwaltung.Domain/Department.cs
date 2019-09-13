using System.Collections.Generic;

namespace ppedv.Personenverwaltung.Domain
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Person Head { get; set; } // ansonsten null
        public virtual HashSet<Person> Members { get; set; } = new HashSet<Person>();
    }


}
