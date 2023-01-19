namespace Projekt_Inzynierski.Core.DTOs
{
    public class GroupTrainingDto
    {
        public int Id { get; set; }
        public string TrainingType { get; set; }
        public int MaxClients { get; set; }
        public int FreeSpots { get; set; }
        public DateTime StartDate { get; set; }
        public TrainerSimpleDto CreatedByTrainer { get; set; }
        public List<int> ClientIds { get; set; } = new List<int>();
        public List<int> TrainerIds { get; set; } = new List<int>();
        public ICollection<ClientViewDto> Clients { get; set; } = new List<ClientViewDto>();
        public ICollection<TrainerSimpleDto> Trainers { get; set; } = new List<TrainerSimpleDto>();
    }
}
