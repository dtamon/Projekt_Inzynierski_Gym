namespace Projekt_Inzynierski.DataAccess.Entities
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime VisitDate { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public Visit() { }
    }
}
