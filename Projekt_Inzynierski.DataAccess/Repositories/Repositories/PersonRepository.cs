using Microsoft.EntityFrameworkCore;
using Projekt_Inzynierski.DataAccess.Context;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
