using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using PetProject.Application.Extensions;
using PetProject.Domain.Shared;
using PetProject.Domain.Shared.ValueObjects;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Application.Volunteers.UpdateRequisites
{
    public class UpdateVolunteerRequisitesHandler
    {
        private readonly IVolunteersRepository _volunteersRepository;
        private readonly IValidator<UpdateVolunteerRequisitesCommand> _validator;
        private readonly ILogger<UpdateVolunteerRequisitesHandler> _logger;
        public UpdateVolunteerRequisitesHandler(IVolunteersRepository volunteersRepository,
            IValidator<UpdateVolunteerRequisitesCommand> validator,
            ILogger<UpdateVolunteerRequisitesHandler> logger)
        {
            _volunteersRepository = volunteersRepository;
            _validator = validator;
            _logger = logger;
        }
        public async Task<Result<Guid, ErrorList>> Execute(
        UpdateVolunteerRequisitesCommand command,
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

            var requisites = new List<Requisite>();

            foreach (var requisite in command.Requisites)
            {
                var requisiteName = Name.Create(requisite.Name).Value;

                var requisiteDescription = Description.Create(requisite.Description).Value;

                requisites.Add(new Requisite(requisiteName, requisiteDescription));
            }

            existingVolunteer.Value.UpdateRequisites(requisites);

            await _volunteersRepository.Save(existingVolunteer.Value, cancellationToken);

            _logger.LogInformation("Updated volunteer with id {volunteerId}", volunteerId.Value);

            return volunteerId.Value;
        }
    }
}
