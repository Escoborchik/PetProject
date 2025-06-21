using FluentValidation;
using PetProject.Application.Validators.DtoValidators;

namespace PetProject.Application.Volunteers.UpdateRequisites
{
    public class UpdateVolunteerRequisitesCommandValidator : AbstractValidator<UpdateVolunteerRequisitesCommand>
    {
        public UpdateVolunteerRequisitesCommandValidator()
        {
            RuleForEach(u => u.Requisites)
                .SetValidator(new RequisitesDtoValidator());
        }
    }
}
