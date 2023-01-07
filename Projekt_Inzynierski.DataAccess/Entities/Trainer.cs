using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Entities
{
    public class Trainer : Employee
    {
        public virtual ICollection<Specialization> Specializations { get; set; }
        public virtual ICollection<GroupTraining> GroupTrainings { get; set; }

        public Trainer() { }
    }
}
