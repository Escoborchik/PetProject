using FluentValidation;
using PetProject.Application.Validators;
using PetProject.Contracts.DTO;
using PetProject.Domain.Shared;
using PetProject.Domain.Shared.ValueObjects;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Application.Volunteers.CreateVolunteer
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

    public class SocialNetworkDtoValidator : AbstractValidator<SocialNetworksDto>
    {
        public SocialNetworkDtoValidator()
        {
            RuleFor(s => s.Name)
                .MustBeValueObject(Name.Create);

            RuleFor(s => s.Link)
                .MustBeValueObject(Link.Create);
        }
    }
}
