using FluentValidation;
using PetProject.Application.Validators;
using PetProject.Domain.Shared;

namespace PetProject.Application.Volunteers.Delete
{
    public class DeleteVolunteerCommandValidator : AbstractValidator<DeleteVolunteerCommand>
    {
        public DeleteVolunteerCommandValidator()
        {
            RuleFor(u => u.VolunteerId)
                .NotEmpty()
                .WithError(Errors.General.ValueIsInvalid("VolunteerId"));
        }
    }
}
