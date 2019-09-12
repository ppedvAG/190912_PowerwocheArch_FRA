using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null) // C#7
                return false;
            if (obj is Person == false)
                return false;

            Person p2 = (Person)obj;

            if (this == p2) // == -> Referenzvergleich
                return true;
            else // Wertevergleich
            {
                if (this.Vorname == p2.Vorname &&
                    this.Nachname == p2.Nachname &&
                    this.Alter == p2.Alter &&
                    this.Kontostand == p2.Kontostand)
                    return true;
                else
                    return false;
            }
        }

    }
}
