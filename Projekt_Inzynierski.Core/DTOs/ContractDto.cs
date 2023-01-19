namespace Projekt_Inzynierski.Core.DTOs
{
    public class ContractDto
    {
        public int Id { get; set; }
        public int Months { get; set; }
        public int MonthlyCost { get; set; }
        public virtual ICollection<ClientViewDto> Clients { get; set; } = new List<ClientViewDto>();
    }
}
