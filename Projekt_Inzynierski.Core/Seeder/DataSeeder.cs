using Microsoft.AspNetCore.Identity;
using Projekt_Inzynierski.DataAccess.Context;
using Projekt_Inzynierski.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.Seeder
{
    public class DataSeeder
    {
        private readonly GymDbContext _context;
        private readonly IPasswordHasher<Person> _passwordHasher;

        public DataSeeder(GymDbContext context, IPasswordHasher<Person> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public void Seed()
        {
            if (!_context.Database.CanConnect())
                return;
            if (!_context.Person.Any(x => x.Role == "Admin"))
            {
                _context.Person.Add(GetAdmin());
                _context.SaveChanges();
            }
        }

        private Person GetAdmin()
        {   
            var admin = new Person()
            {
                FirstName = "Admin",
                LastName = "Admin",
                PhoneNr = "123456789",
                Email = "admin@admin.com",
                Pesel = "12345678900",
                Role = "Admin"
            };
            var password = "admin";
            var hashedPassword = _passwordHasher.HashPassword(admin, password);
            admin.PasswordHash = hashedPassword;

            return admin;
        }
    }
}
