namespace Projekt_Inzynierski.Core.DTOs
{
    public class TrainerViewDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNr { get; set; }
        public string Email { get; set; }
        public string Pesel { get; set; }
        public DateTime EmployedFrom { get; set; }
        public DateTime? EmployedTo { get; set; }
        public int Salary { get; set; }
        public List<int> SpecializationIds { get; set; } = new List<int>();
        public ICollection<string> SpecializationNames { get; set; } = new List<string>();
        public ICollection<int> GroupTrainingIds { get; set; } = new List<int>();
        public ICollection<GroupTrainingDto> GroupTrainings { get; set; } = new List<GroupTrainingDto>();
        public ICollection<GroupTrainingDto> CreatedGroupTrainings { get; set; } = new List<GroupTrainingDto>();
    }
}
