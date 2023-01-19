using Projekt_Inzynierski.DataAccess.Entities;

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
