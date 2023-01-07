using FluentValidation;
using Projekt_Inzynierski.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.Validators
{
    public class SpecializationValidator : AbstractValidator<SpecializationDto>
    {
        public SpecializationValidator()
        {
            RuleFor(x => x.SpecName)
                .NotEmpty().WithMessage("Nazwa specjalizacji jest wymagana")
                .Length(2, 20).WithMessage("Nazwa specjalizacji musi zawierac od 2 do 20 znaków");
        }
    }
}
