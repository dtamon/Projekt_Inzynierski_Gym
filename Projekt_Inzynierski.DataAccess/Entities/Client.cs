using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Entities
{
    public class Client : Person
    {
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
        public DateTime ContractStart { get; set; }
        public DateTime ContractEnd { get; set; }
        public virtual ICollection<GroupTraining> GroupTrainings { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }

        public Client() { }
    }
}
