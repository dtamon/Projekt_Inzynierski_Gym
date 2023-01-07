using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.DTOs
{
    public class TrainerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNr { get; set; }
        public string Email { get; set; }
        public string Pesel { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime EmployedFrom { get; set; }
        public DateTime EmployedTo { get; set; }
        public int Salary { get; set; }
        public List<int> SpecializationIds { get; set; } = new List<int>();
        public ICollection<SpecializationDto> Specializations { get; set; } = new List<SpecializationDto>();
        public ICollection<int> GroupTrainingIds { get; set; } = new List<int>();
    }
}
