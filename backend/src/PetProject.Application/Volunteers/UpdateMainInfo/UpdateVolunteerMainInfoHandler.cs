using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using PetProject.Application.Extensions;
using PetProject.Domain.Shared;
using PetProject.Domain.Shared.ValueObjects;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Application.Volunteers.UpdateMainInfo
{
    public class UpdateVolunteerMainInfoHandler
    {
        private readonly IVolunteersRepository _volunteersRepository;
        private readonly IValidator<UpdateVolunteerMainInfoCommand> _validator;
        private readonly ILogger<UpdateVolunteerMainInfoHandler> _logger;
        public UpdateVolunteerMainInfoHandler(IVolunteersRepository volunteersRepository,
            IValidator<UpdateVolunteerMainInfoCommand> validator,
            ILogger<UpdateVolunteerMainInfoHandler> logger)
        {
            _volunteersRepository = volunteersRepository;
            _validator = validator;
            _logger = logger;
        }
        public async Task<Result<Guid, ErrorList>> Execute(
        UpdateVolunteerMainInfoCommand command,
        CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.ToErrorList();
            }

            var volunteerId = VolunteerId.Create(command.VolunteerId);

            var existingVolunteer = await _volunteersRepository.GetById(volunteerId, cancellationToken);

            if (existingVolunteer.IsFailure)
            {
                return Errors.General.NotFound(volunteerId.Value).ToErrorList();
            }
                
            var fullName = FullName.Create(
                command.FullName.FirstName,
                command.FullName.LastName,
                command.FullName.MiddleName).Value;

            var email = Email.Create(command.Email).Value;                        

            var phone = Phone.Create(command.Phone).Value;

            var volunteerContacts = new VolunteerContacts(email, phone);

            var description = Description.Create(command.Description).Value;

            var yearsOfExperience = command.YearsOfExperience;

            existingVolunteer.Value.UpdateMainInfo(
                fullName,
                volunteerContacts,
                description,
                yearsOfExperience);

            await _volunteersRepository.Save(existingVolunteer.Value, cancellationToken);

            _logger.LogInformation("Updated volunteer with id {volunteerId}", volunteerId.Value);

            return volunteerId.Value;
        }
    }
}
