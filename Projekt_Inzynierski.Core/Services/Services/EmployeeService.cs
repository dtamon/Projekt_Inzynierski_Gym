using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.Core.Services.Interfaces;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;
using Projekt_Inzynierski.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Employee> _passwordHasher;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IPasswordHasher<Employee> passwordHasher)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task CreateEmployeeAsync(EmployeeAccountDto employeeDto)
        {
            employeeDto.EmployedFrom = DateTime.Today;

            var newEmployee = _mapper.Map<Employee>(employeeDto);
            var hashedPassword = _passwordHasher.HashPassword(newEmployee, employeeDto.Password);
            newEmployee.PasswordHash = hashedPassword;

            await _employeeRepository.CreateEmployeeAsync(newEmployee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee != null)
            {
                await _employeeRepository.DeleteEmployeeAsync(employee);
            }
        }

        public async Task<ICollection<EmployeeViewDto>> GetAllEmployeesAsync(SearchQuery query)
        {
            return _mapper.Map<ICollection<EmployeeViewDto>>(await _employeeRepository.GetAllEmployeesAsync(query));
        }

        public async Task<EmployeeViewDto?> GetEmployeeByIdAsync(int id)
        {
            return _mapper.Map<EmployeeViewDto>(await _employeeRepository.GetEmployeeByIdAsync(id));
        }

        public async Task UpdateEmployeeAsync(EmployeeViewDto employeeDto, int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee != null)
            {
                employee.FirstName = employeeDto.FirstName;
                employee.LastName = employeeDto.LastName;
                employee.PhoneNr = employeeDto.PhoneNr;
                employee.Email = employeeDto.Email;
                employee.Pesel = employeeDto.Pesel;
                employee.EmployedTo = employeeDto.EmployedTo;
                employee.Salary = employeeDto.Salary;

                await _employeeRepository.UpdateEmployeeAsync(employee);
            }
        }
    }
}
