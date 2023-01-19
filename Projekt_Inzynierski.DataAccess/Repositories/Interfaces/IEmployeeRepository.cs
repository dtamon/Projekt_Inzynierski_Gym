using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;

namespace Projekt_Inzynierski.DataAccess.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<ICollection<Employee>> GetAllEmployeesAsync(SearchQuery query);
        public Task CreateEmployeeAsync(Employee employee);
        public Task<Employee?> GetEmployeeByIdAsync(int id);
        public Task UpdateEmployeeAsync(Employee employee);
        public Task DeleteEmployeeAsync(Employee employee);
    }
}
