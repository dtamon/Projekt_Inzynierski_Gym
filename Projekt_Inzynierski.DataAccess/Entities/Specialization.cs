using System.ComponentModel.DataAnnotations;

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
