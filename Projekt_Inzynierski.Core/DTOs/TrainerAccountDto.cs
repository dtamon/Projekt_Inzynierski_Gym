namespace Projekt_Inzynierski.Core.DTOs
{
    public class TrainerAccountDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNr { get; set; }
        public string Email { get; set; }
        public string Pesel { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; } = "Trainer";
        public DateTime EmployedFrom { get; set; }
        public DateTime? EmployedTo { get; set; }
        public int Salary { get; set; }
        public List<int> SpecializationIds { get; set; } = new List<int>();
        public ICollection<SpecializationDto> Specializations { get; set; } = new List<SpecializationDto>();
        public ICollection<int> GroupTrainingIds { get; set; } = new List<int>();
        public ICollection<GroupTrainingDto> GroupTrainings { get; set; } = new List<GroupTrainingDto>();
    }
}
