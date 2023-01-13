using Projekt_Inzynierski.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        public Task<Person?> GetUserByEmail(string email);
        public Task<bool> IsEmailTaken(string email);
        public Task<bool> IsPhoneNrTaken(string phoneNr);
        public Task<bool> IsPeselTaken(string pesel);
    }
}
