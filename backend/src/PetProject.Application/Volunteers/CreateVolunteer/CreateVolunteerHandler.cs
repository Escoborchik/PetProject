using CSharpFunctionalExtensions;
using PetProject.Domain.Shared.ValueObjects;
using PetProject.Domain.Shared;
using PetProject.Domain.VolunteerContext.ValueObjects;
using PetProject.Domain.VolunteerContext;
using FluentValidation;
using PetProject.Application.Extensions;

namespace PetProject.Application.Volunteers.CreateVolunteer
{
    public class CreateVolunteerHandler
    {
        private readonly IVolunteersRepository _volunteersRepository;
        private readonly IValidator<CreateVolunteerCommand> _validator;

        public CreateVolunteerHandler(IVolunteersRepository volunteersRepository, IValidator<CreateVolunteerCommand> validator)
        {
            _volunteersRepository = volunteersRepository;
            _validator = validator;
        }
        public async Task<Result<Guid, ErrorList>> Execute(
        CreateVolunteerCommand command, CancellationToken cancellationToken = default)
        {             
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid) 
            {
                return validationResult.ToErrorList();
            }

            var volunteerId = VolunteerId.NewId();

            var fullName = FullName.Create(
                command.FullName.FirstName,
                command.FullName.LastName,
                command.FullName.MiddleName).Value;            

            var email = Email.Create(command.Email).Value;            

            var existingVolunteer = await _volunteersRepository.GetByEmail(email, cancellationToken);

            if (existingVolunteer.IsSuccess)
                return Errors.General.AlreadyExist(email.Value).ToErrorList();

            var phone = Phone.Create(command.Phone).Value;            

            var volunteerContacts = new VolunteerContacts(email,phone);

            var description = Description.Create(command.Description).Value;            

            var yearsOfExperience = command.YearsOfExperience;

            var requisites = new List<Requisite>();

            foreach (var requisite in command.Requisites)
            {
                var requisiteName = Name.Create(requisite.Name).Value;                

                var requisiteDescription = Description.Create(requisite.Description).Value;                

                requisites.Add(new Requisite(requisiteName, requisiteDescription));
            }

            var socialNetworks = new List<SocialNetwork>();

            foreach (var network in command.SocialNetworks)
            {
                var socialNetworkName = Name.Create(network.Name).Value;                

                var socialNetworkLink = Link.Create(network.Link).Value;                

                var socialNetwork = new SocialNetwork(socialNetworkLink, socialNetworkName);                

                socialNetworks.Add(socialNetwork);
            }           

            var newVolunteer = new Volunteer(
            volunteerId,
            fullName,
            volunteerContacts,
            description,
            yearsOfExperience,           
            requisites,
            socialNetworks);

            await _volunteersRepository.Add(newVolunteer, cancellationToken);

            return (Guid)newVolunteer.Id;
        }
    }
}
