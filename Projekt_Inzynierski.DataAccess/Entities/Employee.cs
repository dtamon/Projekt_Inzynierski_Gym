namespace Projekt_Inzynierski.DataAccess.Entities
{
    public class Employee : Person
    {
        public DateTime EmployedFrom { get; set; }
        public DateTime? EmployedTo { get; set; }
        public int Salary { get; set; }

        public Employee() { }
    }
}
