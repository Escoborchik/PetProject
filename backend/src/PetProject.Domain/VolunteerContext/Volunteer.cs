using CSharpFunctionalExtensions;
using PetProject.Domain.Shared.ValueObjects;
using PetProject.Domain.VolunteerContext.Entities;
using PetProject.Domain.VolunteerContext.Enums;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Domain.VolunteerContext
{
    public class Volunteer : Entity
    {
        private readonly List<SocialNetwork> _socialNetworks = [];

        private readonly List<Pet> _pets = [];

        public Volunteer(
            VolunteerId id,
            FullName fullName,
            Email email,
            Description description,
            int experienceYears,
            Phone phone,
            Requisite requisites)
        {            
            Id = id;
            FullName = fullName;
            Email = email;
            Description = description;
            ExperienceYears = experienceYears;
            Phone = phone;
            Requisites = requisites;
        }

        public VolunteerId Id { get; private set; }

        public FullName FullName { get; private set; }

        public Email Email { get; private set; }

        public Description Description { get; private set; }

        public int ExperienceYears { get; private set; }

        public Phone Phone { get; private set; }

        public Requisite Requisites { get; private set; }

        public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;

        public IReadOnlyList<Pet> AllPets => _pets;

        public IReadOnlyList<Pet> PetsNeedsHelp => GetPetsNeedsHelp();

        public IReadOnlyList<Pet> PetsLookingForHome => GetPetsLookingForHome();

        public IReadOnlyList<Pet> PetsFoundHome => GetPetsFoundHome();

        public Result AddSocialNetwork(SocialNetwork socialNetwork)
        {
            if (_socialNetworks.Contains(socialNetwork))
                return Result.Failure("Social network already exists in the volunteer's list.");

            _socialNetworks.Add(socialNetwork);

            return Result.Success();
        }

        public Result AddPet(Pet pet)
        {
            if (_pets.Contains(pet))
                return Result.Failure("Pet already exists in the volunteer's list.");

            _pets.Add(pet);

            return Result.Success();
        }

        private IReadOnlyList<Pet> GetPetsNeedsHelp()
        {
            return _pets
                .Where(p => p.HelpStatus is HelpStatus.NeedHelp)
                .ToList();
        }

        private IReadOnlyList<Pet> GetPetsLookingForHome()
        {
            return _pets
                .Where(p => p.HelpStatus is HelpStatus.LookingHome)
                .ToList();
        }

        private IReadOnlyList<Pet> GetPetsFoundHome()
        {
            return _pets
                .Where(p => p.HelpStatus is HelpStatus.FoundHome)
                .ToList();
        }
    }
}
