using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using PetProject.Application.Extensions;
using PetProject.Domain.Shared;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Application.Volunteers.UpdateSocialNets
{
    public class UpdateVolunteerSocialNetsHandler
    {
        private readonly IVolunteersRepository _volunteersRepository;
        private readonly IValidator<UpdateVolunteerSocialNetsCommand> _validator;
        private readonly ILogger<UpdateVolunteerSocialNetsHandler> _logger;
        public UpdateVolunteerSocialNetsHandler(IVolunteersRepository volunteersRepository,
            IValidator<UpdateVolunteerSocialNetsCommand> validator,
            ILogger<UpdateVolunteerSocialNetsHandler> logger)
        {
            _volunteersRepository = volunteersRepository;
            _validator = validator;
            _logger = logger;
        }
        public async Task<Result<Guid, ErrorList>> Execute(
        UpdateVolunteerSocialNetsCommand command,
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

            var socialNetworks = new List<SocialNetwork>();

            foreach (var network in command.SocialNetworks)
            {
                var socialNetworkName = Name.Create(network.Name).Value;

                var socialNetworkLink = Link.Create(network.Link).Value;

                var socialNetwork = new SocialNetwork(socialNetworkLink, socialNetworkName);

                socialNetworks.Add(socialNetwork);
            }

            existingVolunteer.Value.UpdateSocialNetworks(socialNetworks);

            await _volunteersRepository.Save(existingVolunteer.Value, cancellationToken);

            _logger.LogInformation("Updated volunteer with id {volunteerId}", volunteerId.Value);

            return volunteerId.Value;
        }
    }
}
