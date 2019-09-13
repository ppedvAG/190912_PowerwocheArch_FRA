using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBankkonto
{
    public enum Reichtum { Nichts, Schulden, Arm, Mittelschicht, Reich, Obere1Prozent }

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

        public Reichtum Reichtum
        {
            get
            {
                if (Kontostand == 0)
                    return Reichtum.Nichts;
                else if (Kontostand < 0)
                    return Reichtum.Schulden;
                else if (Kontostand < 1000)
                    return Reichtum.Arm;
                else if (Kontostand < 10_000)
                    return Reichtum.Mittelschicht;
                else if (Kontostand < 100_000)
                    return Reichtum.Reich;
                else
                    return Reichtum.Obere1Prozent;
            }
        }

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
