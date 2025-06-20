﻿using FluentValidation;
using PetProject.Application.Validators;
using PetProject.Domain.Shared;
using PetProject.Domain.Shared.ValueObjects;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Application.Volunteers.UpdateMainInfo
{    
    public class UpdateVolunteerMainInfoCommandValidator : AbstractValidator<UpdateVolunteerMainInfoCommand>
    {
        public UpdateVolunteerMainInfoCommandValidator()
        {
            RuleFor(u => u.VolunteerId)
                .NotEmpty()
                .WithError(Errors.General.ValueIsInvalid("VolunteerId"));

            RuleFor(u => u.FullName)
                .MustBeValueObject(f => FullName.Create(f.FirstName, f.LastName, f.MiddleName));

            RuleFor(u => u.Email)
                .MustBeValueObject(Email.Create);

            RuleFor(u => u.Description)
                .MustBeValueObject(Description.Create);

            RuleFor(u => u.YearsOfExperience)
                .GreaterThan(0)
                .WithError(Errors.General.ValueIsInvalid("YearsOfExperience"));

            RuleFor(u => u.Phone)
                .MustBeValueObject(Phone.Create);            
        }
    }
}
