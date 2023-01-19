namespace Projekt_Inzynierski.Core.DTOs
{
    public class EmployeeViewDto
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
    }
}
