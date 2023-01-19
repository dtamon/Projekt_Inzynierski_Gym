using FluentValidation;
using Projekt_Inzynierski.Core.DTOs;

namespace Projekt_Inzynierski.Core.Validators
{
    public class VisitValidator : AbstractValidator<VisitDto>
    {
        public VisitValidator()
        {
            RuleFor(x => x.ClientId)
                .NotEmpty().WithMessage("Klient jest wymagany");
        }
    }
}
