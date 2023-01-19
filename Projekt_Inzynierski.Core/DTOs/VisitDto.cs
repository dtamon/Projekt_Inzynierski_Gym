namespace Projekt_Inzynierski.Core.DTOs
{
    public class VisitDto
    {
        public int Id { get; set; }
        public DateTime VisitDate { get; set; }
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNr { get; set; }
        public string Email { get; set; }
        public string Pesel { get; set; }
    }
}
