using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Entities
{
    public class Specialization
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string SpecName { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }

        public Specialization() { }
    }
}
