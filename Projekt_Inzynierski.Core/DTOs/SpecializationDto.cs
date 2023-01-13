using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.DTOs
{
    public class SpecializationDto
    {
        public int Id { get; set; }
        public string SpecName { get; set; }
        public virtual ICollection<TrainerSimpleDto> Trainers { get; set; } = new List<TrainerSimpleDto>();
    }
}
