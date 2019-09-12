using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBankkonto
{
    public class Bankkonto
    {
        private decimal value;

        public Bankkonto()
        {
        }

        public Bankkonto(decimal value)
        {
            this.value = value;
        }

        public decimal Kontostand { get; set; }

        public void Einzahlen(decimal value)
        {
            throw new NotImplementedException();
        }

        public void Abheben(decimal value)
        {
            throw new NotImplementedException();
        }
    }
}
