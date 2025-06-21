using FluentValidation;
using PetProject.Application.Validators.DtoValidators;

namespace PetProject.Application.Volunteers.UpdateSocialNets
{
    public class UpdateVolunteerSocialNetsCommandValidator : AbstractValidator<UpdateVolunteerSocialNetsCommand>
    {
        public UpdateVolunteerSocialNetsCommandValidator()
        {
            RuleForEach(u => u.SocialNetworks)
                .SetValidator(new SocialNetworkDtoValidator());
        }
    }
}
