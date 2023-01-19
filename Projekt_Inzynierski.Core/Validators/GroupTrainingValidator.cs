using FluentValidation;
using Projekt_Inzynierski.Core.DTOs;

namespace Projekt_Inzynierski.Core.Validators
{
    public class GroupTrainingValidator : AbstractValidator<GroupTrainingDto>
    {
        public GroupTrainingValidator() 
        {
            RuleFor(x => x.MaxClients)
                .GreaterThan(0).WithMessage("Maksymalna ilość miejsc musi być większa od 0");

            RuleFor(x => x.StartDate)
                .GreaterThan(DateTime.Now).WithMessage("Data rozpoczęcia musi być przyszła");

        }
    }
}
