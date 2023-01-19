using FluentValidation;
using Projekt_Inzynierski.Core.DTOs;

namespace Projekt_Inzynierski.Core.Validators
{
    public class TrainingEquipmentValidator : AbstractValidator<TrainingEquipmentDto>
    {
        public TrainingEquipmentValidator()
        {
            RuleFor(x => x.SerialNr)
                .NotEmpty().WithMessage("Numer Seryjny jest wymagany")
                .MinimumLength(5).WithMessage("Numer Seryjny musi zawierac minimum 5 znaków");
        }
    }
}
