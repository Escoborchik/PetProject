using FluentValidation;
using PetProject.Application.Validators;
using PetProject.Application.Validators.DtoValidators;
using PetProject.Domain.Shared;
using PetProject.Domain.Shared.ValueObjects;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Application.Volunteers.Create
{
    public class CreateVolunteerCommandValidator : AbstractValidator<CreateVolunteerCommand>
    {
        public CreateVolunteerCommandValidator()
        {
            RuleFor(c => c.FullName)
                .MustBeValueObject(f => FullName.Create(f.FirstName, f.LastName, f.MiddleName));

            RuleFor(c => c.Email)
                .MustBeValueObject(Email.Create);

            RuleFor(c => c.Description)
                .MustBeValueObject(Description.Create);

            RuleFor(c => c.YearsOfExperience)
                .GreaterThan(0)
                .WithError(Errors.General.ValueIsInvalid("YearsOfExperience"));

            RuleFor(c => c.Phone)
                .MustBeValueObject(Phone.Create);

            RuleForEach(c => c.Requisites)
            .SetValidator(new RequisitesDtoValidator());

            RuleForEach(c => c.SocialNetworks)
                .SetValidator(new SocialNetworkDtoValidator());
        }
    }
}
