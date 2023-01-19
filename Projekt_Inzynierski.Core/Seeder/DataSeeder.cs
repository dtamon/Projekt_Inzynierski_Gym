using Microsoft.AspNetCore.Identity;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.Core.Services.Interfaces;
using Projekt_Inzynierski.DataAccess.Context;
using Projekt_Inzynierski.DataAccess.Entities;

namespace Projekt_Inzynierski.Core.Seeder
{
    public class DataSeeder
    {
        private readonly GymDbContext _context;
        private readonly IPasswordHasher<Person> _passwordHasher;
        private readonly IClientService _clientService;
        private readonly IEmployeeService _employeeService;
        private readonly ITrainerService _trainerService;

        public DataSeeder(GymDbContext context, IPasswordHasher<Person> passwordHasher, IClientService clientService, IEmployeeService employeeService, ITrainerService trainerService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _clientService = clientService;
            _employeeService = employeeService;
            _trainerService = trainerService;
        }

        public async Task SeedAsync()
        {
            if (!_context.Database.CanConnect())
                return;
            if (!_context.Person.Any(x => x.Role == "Admin"))
            {
                _context.Person.Add(GetAdmin());
                _context.SaveChanges();
            }
            if (!_context.Contract.Any())
            {
                _context.Contract.AddRange(GetContracts());
                _context.SaveChanges();
            }
            if (!_context.Client.Any())
            {
                foreach (var client in GetClients())
                {
                    await _clientService.CreateClientAsync(client);
                }
            }
            if (!_context.Employee.Any())
            {
                foreach (var employee in GetEmployees())
                {
                    await _employeeService.CreateEmployeeAsync(employee);
                }
            }
            if (!_context.Specialization.Any())
            {
                _context.Specialization.AddRange(GetSpecializations());
                _context.SaveChanges();
            }
            if (!_context.Trainer.Any())
            {
                foreach (var trainer in GetTrainers())
                {
                    await _trainerService.CreateTrainerAsync(trainer);
                }
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

        private List<Contract> GetContracts()
        {
            return new List<Contract>()
            {
                new Contract() { Months = 1, MonthlyCost = 65},
                new Contract() { Months = 3, MonthlyCost = 60},
                new Contract() { Months = 6, MonthlyCost = 50}
            };
        }

        private List<ClientAccountDto> GetClients()
        {
            return new List<ClientAccountDto>()
            {
                new ClientAccountDto(){ FirstName = "Client", LastName = "Client", PhoneNr = "987123987", Email = "client@client.com", Pesel = "98712398798", Password = "client", ConfirmPassword = "client", ContractId = 2 }
            };
        }

        private List<EmployeeAccountDto> GetEmployees()
        {
            return new List<EmployeeAccountDto>()
            {
                new EmployeeAccountDto(){ FirstName = "Employee", LastName = "Employee", PhoneNr = "987321654", Email = "employee@employee.com", Pesel = "98732165454", Password = "employee", ConfirmPassword = "employee", Salary=5400 }
            };
        }

        private List<Specialization> GetSpecializations()
        {
            return new List<Specialization>()
            {
                new Specialization() { SpecName = "yoga"},
                new Specialization() { SpecName = "kalistenika"},
                new Specialization() { SpecName = "trening siłowy"}
            };
        }

        private List<TrainerAccountDto> GetTrainers()
        {
            return new List<TrainerAccountDto>()
            {
                new TrainerAccountDto(){ FirstName = "Trainer", LastName = "Trainer", PhoneNr = "987123456", Email = "trainer@trainer.com", Pesel = "98712345612", Password = "trainer", ConfirmPassword = "trainer", Salary=5600, SpecializationIds = new List<int>(new int[] {1, 2, 3 })}
            };
        }
    }
}
