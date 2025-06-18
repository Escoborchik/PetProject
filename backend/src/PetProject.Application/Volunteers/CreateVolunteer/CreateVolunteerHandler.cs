using CSharpFunctionalExtensions;
using PetProject.Domain.Shared.ValueObjects;
using PetProject.Domain.Shared;
using PetProject.Domain.VolunteerContext.ValueObjects;
using PetProject.Domain.VolunteerContext;

namespace PetProject.Application.Volunteers.CreateVolunteer
{
    public class CreateVolunteerHandler
    {
        private readonly IVolunteersRepository _volunteersRepository;

        public CreateVolunteerHandler(IVolunteersRepository volunteersRepository)
        {
            _volunteersRepository = volunteersRepository;
        }
        public async Task<Result<Guid, Error>> Execute(
        CreateVolunteerCommand command, CancellationToken cancellationToken = default)
        {
            var volunteerId = VolunteerId.NewId();

            var fullNameResult = FullName.Create(command.FirstName, command.LastName, command.MiddleName);
            if (fullNameResult.IsFailure)
                return fullNameResult.Error;

            var emailResult = Email.Create(command.Email);
            if (emailResult.IsFailure)
                return emailResult.Error;

            var existingVolunteer = await _volunteersRepository.GetByEmail(emailResult.Value, cancellationToken);

            if (existingVolunteer.IsSuccess)
                return Errors.General.AlreadyExist("volunteer");

            var phoneResult = Phone.Create(command.Phone);
            if (phoneResult.IsFailure)
                return phoneResult.Error;

            var volunteerContacts = new VolunteerContacts(emailResult.Value,phoneResult.Value);

            var descriptionResult = Description.Create(command.Description);
            if (descriptionResult.IsFailure)
                return descriptionResult.Error;

            var yearsOfExperience = command.YearsOfExperience;

            var requisites = new List<Requisite>();

            foreach (var requisite in command.Requisites)
            {
                var requisiteName = Name.Create(requisite.Name);
                if (descriptionResult.IsFailure)
                    return descriptionResult.Error;

                var requisiteDescription = Description.Create(requisite.Description);
                if (descriptionResult.IsFailure)
                    return descriptionResult.Error;

                requisites.Add(new Requisite(requisiteName.Value, requisiteDescription.Value));
            }

            var socialNetworks = new List<SocialNetwork>();

            foreach (var network in command.SocialNetworks)
            {
                var socialNetworkName = Name.Create(network.Name);
                if (descriptionResult.IsFailure)
                    return descriptionResult.Error;

                var socialNetwork = SocialNetwork.Create(network.Link, socialNetworkName.Value);
                if (descriptionResult.IsFailure)
                    return descriptionResult.Error;

                socialNetworks.Add(socialNetwork.Value);
            }           

            var newVolunteer = new Volunteer(
            volunteerId,
            fullNameResult.Value,
            volunteerContacts,
            descriptionResult.Value,
            yearsOfExperience,           
            requisites,
            socialNetworks);

            await _volunteersRepository.Add(newVolunteer, cancellationToken);

            return (Guid)newVolunteer.Id;
        }
    }
}
