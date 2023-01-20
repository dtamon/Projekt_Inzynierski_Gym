using Microsoft.EntityFrameworkCore;
using Projekt_Inzynierski.DataAccess.Context;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Repositories.Interfaces;

namespace Projekt_Inzynierski.DataAccess.Repositories.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly GymDbContext _context;

        public PersonRepository(GymDbContext context)
        {
            _context = context;
        }
        public async Task<Person?> GetUserByEmail(string email)
        {
            return await _context.Person.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> IsEmailTaken(int id, string email)
        {
            return await _context.Person.AnyAsync(x => x.Id != id && x.Email == email);
        }

        public async Task<bool> IsPeselTaken(int id, string pesel)
        {
            return await _context.Person.AnyAsync(x => x.Id != id && x.Pesel == pesel);
        }

        public async Task<bool> IsPhoneNrTaken(int id, string phoneNr)
        {
            return await _context.Person.AnyAsync(x => x.Id != id && x.PhoneNr == phoneNr);
        }
    }
}
