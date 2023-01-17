using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.DTOs
{
    public class ClientAccountDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNr { get; set; }
        public string Email { get; set; }
        public string Pesel { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; } = "Client";
        public int ContractId { get; set; }
        public DateTime ContractStart { get; set; }
        public DateTime ContractEnd { get; set; }

    }
}
