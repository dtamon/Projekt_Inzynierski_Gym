using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.DataAccess.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task CreateEmployeeAsync(EmployeeAccountDto employeeDto);
        public Task UpdateEmployeeAsync(EmployeeViewDto employeeDto, int id);
        public Task DeleteEmployeeAsync(int id);
        Task<ICollection<EmployeeViewDto>> GetAllEmployeesAsync(SearchQuery query);
        Task<EmployeeViewDto?> GetEmployeeByIdAsync(int id);
    }
}
