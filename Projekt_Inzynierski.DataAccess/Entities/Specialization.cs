using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Entities
{
    public class Specialization
    {
        public int Id { get; set; }
        public string SpecName { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }

        public Specialization() { }
    }
}
