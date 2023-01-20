using Projekt_Inzynierski.DataAccess.Entities;

namespace Projekt_Inzynierski.DataAccess.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        public Task<Person?> GetUserByEmail(string email);
        public Task<bool> IsEmailTaken(int id, string email);
        public Task<bool> IsPhoneNrTaken(int id, string phoneNr);
        public Task<bool> IsPeselTaken(int id, string pesel);
    }
}
