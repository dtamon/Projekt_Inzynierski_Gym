using System.ComponentModel.DataAnnotations;

namespace Projekt_Inzynierski.DataAccess.Entities
{
    public class Person
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(9)]
        public string PhoneNr { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(11)]
        public string Pesel { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }

        public Person() { }
    }
}
