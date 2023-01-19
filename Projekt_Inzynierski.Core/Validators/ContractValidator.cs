using FluentValidation;
using Projekt_Inzynierski.Core.DTOs;

namespace Projekt_Inzynierski.Core.Validators
{
    public class ContractValidator : AbstractValidator<ContractDto>
    {
        public ContractValidator()
        {
            RuleFor(x => x.Months)
                .NotEmpty().WithMessage("Liczba miesięcy trwania umowy jest wymagana")
                .GreaterThan(0).WithMessage("Wartośc musi być większa od 0");

            RuleFor(x => x.MonthlyCost)
                .NotEmpty().WithMessage("Koszt miesięczny jest wymagany")
                .GreaterThan(0).WithMessage("Wartośc musi być większa od 0");
        }
    }
}
