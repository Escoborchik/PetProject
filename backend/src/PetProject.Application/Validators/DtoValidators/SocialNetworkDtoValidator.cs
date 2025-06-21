using FluentValidation;
using PetProject.Application.Validators;
using PetProject.Contracts.DTO;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Application.Validators.DtoValidators
{
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
