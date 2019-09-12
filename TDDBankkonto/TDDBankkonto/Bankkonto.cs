using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBankkonto
{
    public class Bankkonto
    {
        public Bankkonto() :this(100m){}
        public Bankkonto(decimal value)
        {
            if (value < 0)
                throw new ArgumentException("Sie dürfen kein neues Konto mit negativem Kontostand anlegen");
            Kontostand = value;
        }

        public decimal Kontostand { get; protected set; }

        public void Einzahlen(decimal value)
        {
            if (value < 0)
                throw new ArgumentException("Sie dürfen keinen negativen Betrag einzahlen !");
            Kontostand += value;
        }

        public void Abheben(decimal value)
        {
            if (value < 0)
                throw new ArgumentException("Sie dürfen keinen negativen Betrag abheben !");
            if (Kontostand - value < 0)
                throw new InvalidOperationException("Sie dürfen nicht mehr Abheben als Sie besitzen!");

            Kontostand -= value;
        }
    }
}
