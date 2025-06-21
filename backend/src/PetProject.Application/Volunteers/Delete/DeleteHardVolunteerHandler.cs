using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using PetProject.Application.Extensions;
using PetProject.Domain.Shared;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Application.Volunteers.Delete
{
    public class DeleteHardVolunteerHandler
    {
        private readonly IVolunteersRepository _volunteersRepository;
        private readonly IValidator<DeleteVolunteerCommand> _validator;
        private readonly ILogger<DeleteHardVolunteerHandler> _logger;
        public DeleteHardVolunteerHandler(IVolunteersRepository volunteersRepository,
            IValidator<DeleteVolunteerCommand> validator,
            ILogger<DeleteHardVolunteerHandler> logger)
        {
            _volunteersRepository = volunteersRepository;
            _validator = validator;
            _logger = logger;
        }
        public async Task<Result<Guid, ErrorList>> Execute(
        DeleteVolunteerCommand command,
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

            await _volunteersRepository.Delete(existingVolunteer.Value, cancellationToken);

            _logger.LogInformation("Volunteer with id {volunteerId} was deleted", volunteerId.Value);

            return volunteerId.Value;
        }
    }
}
