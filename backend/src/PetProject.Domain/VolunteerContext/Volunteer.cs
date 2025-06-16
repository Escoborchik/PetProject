using CSharpFunctionalExtensions;
using PetProject.Domain.Shared.ValueObjects;
using PetProject.Domain.VolunteerContext.Entities;
using PetProject.Domain.VolunteerContext.Enums;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Domain.VolunteerContext
{
    public class Volunteer : Entity<VolunteerId>
    {
        private readonly List<SocialNetwork> _socialNetworks = [];

        private readonly List<Pet> _pets = [];

        private readonly List<Requisite> _requisites = [];

        //ef  core
        private Volunteer() { }

        public Volunteer(
            VolunteerId id,
            FullName fullName,
            VolunteerContacts contacts,
            Description description,
            int experienceYears,
            Phone phone)
        {            
            Id = id;
            FullName = fullName;
            Contacts = contacts;
            Description = description;
            ExperienceYears = experienceYears;                       
        }          

        public FullName FullName { get; private set; } = null!;

        public VolunteerContacts Contacts { get; private set; } = null!;

        public Description Description { get; private set; } = null!;

        public int ExperienceYears { get; private set; }

        public IReadOnlyList<Requisite> Requisites => _requisites;

        public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;

        public IReadOnlyList<Pet> Pets => _pets;

        private int GetPetsCountByStatus(HelpStatus status) => Pets.Count(p => p.HelpStatus == status);

        public Result AddSocialNetwork(SocialNetwork socialNetwork)
        {
            if (_socialNetworks.Contains(socialNetwork))
                return Result.Failure("Social network already exists in the volunteer's list.");

            _socialNetworks.Add(socialNetwork);

            return Result.Success();
        }

        public Result AddRequisite(Requisite requisite)
        {
            if (_requisites.Contains(requisite))
                return Result.Failure("Requisite already exists in the volunteer's list.");

            _requisites.Add(requisite);

            return Result.Success();
        }

        public Result AddPet(Pet pet)
        {
            if (_pets.Contains(pet))
                return Result.Failure("Pet already exists in the volunteer's list.");

            _pets.Add(pet);

            return Result.Success();
        }

        public int GetPetsFoundHome()
        {
            return GetPetsCountByStatus(HelpStatus.FoundHome);
        }

        public int GetPetLookingForHome()
        {
            return GetPetsCountByStatus(HelpStatus.LookingHome);
        }

        public int GetPetsNeedsHelp()
        {
            return GetPetsCountByStatus(HelpStatus.NeedHelp);
        }         
    }
}
