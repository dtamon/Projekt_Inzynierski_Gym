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

        public async Task<bool> IsEmailTaken(string email)
        {
            return await _context.Person.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> IsPeselTaken(string pesel)
        {
            return await _context.Person.AnyAsync(x => x.Pesel == pesel);
        }

        public async Task<bool> IsPhoneNrTaken(string phoneNr)
        {
            return await _context.Person.AnyAsync(x => x.PhoneNr == phoneNr);
        }
    }
}
