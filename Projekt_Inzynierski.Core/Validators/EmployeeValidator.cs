﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        private readonly GymDbContext _dbContext;
        public EmployeeValidator(GymDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Imię jest wymagane")
                .Length(2, 20).WithMessage("Imię musi zawierać od 2 do 20 znaków")
                .Matches("^[A-ZĄĆĘŁŃÓŚŻŹ]+(([',. -][a-zA-ZĄĆĘŁŃÓŚŻŹąćęłńóśżź])?[a-zA-ZĄĆĘŁŃÓŚŻŹąćęłńóśżź]*)*$").WithMessage("Imię nie może zawierać cyfr i musi zaczynać się wielką literą");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Nazwisko jest wymagane")
                .Length(2, 20).WithMessage("Nazwisko musi zawierać od 2 do 20 znaków")
                .Matches("^[A-ZĄĆĘŁŃÓŚŻŹ]+(([',. -][a-zA-ZĄĆĘŁŃÓŚŻŹąćęłńóśżź])?[a-zA-ZĄĆĘŁŃÓŚŻŹąćęłńóśżź]*)*$").WithMessage("Nazwisko nie może zawierać cyfr i musi zaczynać się wielką literą");

            RuleFor(x => x.PhoneNr)
                .NotEmpty().WithMessage("Numer telefonu jest wymagany")
                .Length(9, 9).WithMessage("Numer telefonu musi zawierać 9 cyfr")
                .Matches("^[0-9]*$").WithMessage("Numer telefonu może zawierać tylko cyfry")
                .MustAsync(async (employee, value, c) => await UniqueEmail(employee, value)).WithMessage("Numer telefonu jest już przypisany do innej osoby");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email jest wymagany")
                .EmailAddress().WithMessage("Email ma niepoprawny format")
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Person.Any(s => s.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "Podany Email jest w użyciu");
                    }
                });

            RuleFor(x => x.Pesel)
                .NotEmpty().WithMessage("Pesel jest wymagany")
                .Length(11, 11).WithMessage("Pesel musi zawierać 11 cyfr")
                .Matches("^[0-9]*$").WithMessage("Pesel może zawierać tylko cyfry")
                .Custom((value, context) =>
                {
                    var peselInDb = dbContext.Person.Any(s => s.Pesel == value);
                    if (peselInDb)
                    {
                        context.AddFailure("Pesel", "Podany pesel jest w użyciu");
                    }
                });

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Hasło jest wymagane");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Hasło i potwierdzenie hasła są różne");

            RuleFor(x => x.Salary)
                .NotEmpty().WithMessage("Wynagrodzenie jest wymagane")
                .GreaterThan(0).WithMessage("Wynagrodzenie musi być liczbą dodatnią");
        }

        private async Task<bool> UniqueEmail(EmployeeDto employee ,string phoneNr)
        {
            return !await _dbContext.Person.Where(s => s.Id != employee.Id).AnyAsync(s => s.PhoneNr == phoneNr);
        }
    }
}
