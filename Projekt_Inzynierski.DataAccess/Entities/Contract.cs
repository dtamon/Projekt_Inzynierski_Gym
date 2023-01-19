namespace Projekt_Inzynierski.DataAccess.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public int Months { get; set; }
        public int MonthlyCost { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public Contract() { }
    }
}
