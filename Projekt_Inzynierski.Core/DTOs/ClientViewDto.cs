namespace Projekt_Inzynierski.Core.DTOs
{
    public class ClientViewDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNr { get; set; }
        public string Email { get; set; }
        public string Pesel { get; set; }
        public int ContractId { get; set; }
        public int? ContractMonths { get; set; }
        public int? ContractMonthlyCost { get; set; }
        public DateTime ContractStart { get; set; }
        public DateTime ContractEnd { get; set; }
        public virtual ICollection<VisitDto> Visits { get; set; } = new List<VisitDto>();
    }
}
