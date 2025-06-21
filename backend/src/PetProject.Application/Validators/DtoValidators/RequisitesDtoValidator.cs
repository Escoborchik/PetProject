using FluentValidation;
using PetProject.Application.Validators;
using PetProject.Contracts.DTO;
using PetProject.Domain.Shared.ValueObjects;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Application.Validators.DtoValidators
{
    public class RequisitesDtoValidator : AbstractValidator<RequisitesDto>
    {
        public RequisitesDtoValidator()
        {
            RuleFor(r => r.Name)
                .MustBeValueObject(Name.Create);

            RuleFor(r => r.Description)
                .MustBeValueObject(Description.Create);
        }
    }
}
