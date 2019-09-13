using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Personenverwaltung.Domain
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal AnnualIncome { get; set; }
        public virtual HashSet<Department> Departments { get; set; } = new HashSet<Department>();
    }


}
