using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public int Months { get; set; }
        public int MonthlyCost { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public Contract() { }
    }
}
