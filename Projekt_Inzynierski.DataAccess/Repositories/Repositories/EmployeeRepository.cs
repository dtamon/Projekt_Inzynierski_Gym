using Microsoft.EntityFrameworkCore;
using Projekt_Inzynierski.DataAccess.Context;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;
using Projekt_Inzynierski.DataAccess.Repositories.Interfaces;

namespace Projekt_Inzynierski.DataAccess.Repositories.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly GymDbContext _context;

        public EmployeeRepository(GymDbContext context)
        {
            _context = context;
        }
        public async Task CreateEmployeeAsync(Employee employee)
        {
            await _context.Employee.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Employee>> GetAllEmployeesAsync(SearchQuery query)
        {
            return await _context.Employee.Where(x => (query.SearchPhrase == null || (x.FirstName.ToLower().Contains(query.SearchPhrase.ToLower())
                                                        || x.LastName.ToLower().Contains(query.SearchPhrase.ToLower())
                                                        || x.Pesel.ToLower().Contains(query.SearchPhrase.ToLower())))
                                                        && x.Role == "Employee")
                .ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employee.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employee.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
