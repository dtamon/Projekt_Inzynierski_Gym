using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.Core.Exceptions;
using Projekt_Inzynierski.Core.Services.Interfaces;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;
using Projekt_Inzynierski.DataAccess.Repositories.Interfaces;
using Projekt_Inzynierski.DataAccess.Repositories.Repositories;

namespace Projekt_Inzynierski.Core.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Employee> _passwordHasher;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IPasswordHasher<Employee> passwordHasher, IPersonRepository personRepository)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _personRepository = personRepository;
        }

        public async Task CreateEmployeeAsync(EmployeeAccountDto employeeDto)
        {
            if (await _personRepository.IsEmailTaken(employeeDto.Id, employeeDto.Email))
                throw new EmailIsTakenException("Email jest zajęty");
            if (await _personRepository.IsPhoneNrTaken(employeeDto.Id, employeeDto.PhoneNr))
                throw new PhoneNrIsTakenException("Numer telefonu jest zajęty");
            if (await _personRepository.IsPeselTaken(employeeDto.Id, employeeDto.Pesel))
                throw new PeselIsTakenException("Pesel jest zajęty");

            employeeDto.EmployedFrom = DateTime.Today;

            var newEmployee = _mapper.Map<Employee>(employeeDto);
            var hashedPassword = _passwordHasher.HashPassword(newEmployee, employeeDto.Password);
            newEmployee.PasswordHash = hashedPassword;

            await _employeeRepository.CreateEmployeeAsync(newEmployee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
                throw new NotFoundException("Employee not found");

            await _employeeRepository.DeleteEmployeeAsync(employee);
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
            if (await _personRepository.IsEmailTaken(employeeDto.Id, employeeDto.Email))
                throw new EmailIsTakenException("Email jest zajęty");
            if (await _personRepository.IsPhoneNrTaken(employeeDto.Id, employeeDto.PhoneNr))
                throw new PhoneNrIsTakenException("Numer telefonu jest zajęty");
            if (await _personRepository.IsPeselTaken(employeeDto.Id, employeeDto.Pesel))
                throw new PeselIsTakenException("Pesel jest zajęty");

            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
                throw new NotFoundException("Employee not found");

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
