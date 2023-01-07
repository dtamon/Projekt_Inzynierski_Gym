using Projekt_Inzynierski.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<ICollection<Employee>> GetAllEmployeesAsync();
        public Task CreateEmployeeAsync(Employee employee);
        public Task<Employee?> GetEmployeeByIdAsync(int id);
        public Task UpdateEmployeeAsync(Employee employee);
        public Task DeleteEmployeeAsync(Employee employee);
    }
}
