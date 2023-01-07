using FluentValidation;
using Projekt_Inzynierski.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
