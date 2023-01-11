using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.DTOs
{
    public class GroupTrainingDto
    {
        public int Id { get; set; }
        public string TrainingType { get; set; }
        public int MaxClients { get; set; }
        public int FreeSpots { get; set; }
        public DateTime StartDate { get; set; }

        public List<int> ClientIds { get; set; } = new List<int>();
        public List<int> TrainerIds { get; set; } = new List<int>();
        public ICollection<ClientViewDto> Clients { get; set; } = new List<ClientViewDto>();
        public ICollection<string> TrainersNames { get; set; } = new List<string>();
    }
}
