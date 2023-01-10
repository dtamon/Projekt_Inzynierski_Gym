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
        public int MaxClients { get; set; }
        public int FreeSpots { get; set; }
        public DateTime StartDate { get; set; }

        public List<int> ClientIds { get; set; } = new List<int>();
        public List<int> TrainerIds { get; set; } = new List<int>();
        public ICollection<ClientDto> Clients { get; set; } = new List<ClientDto>();
        public ICollection<TrainerDto> Trainers { get; set; } = new List<TrainerDto>();
    }
}
