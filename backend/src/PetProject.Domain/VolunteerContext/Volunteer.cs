using CSharpFunctionalExtensions;
using PetProject.Domain.Shared;
using PetProject.Domain.Shared.ValueObjects;
using PetProject.Domain.VolunteerContext.Entities;
using PetProject.Domain.VolunteerContext.Enums;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Domain.VolunteerContext
{
    public class Volunteer : SoftDeletableEntity<VolunteerId>
    {
        private readonly List<SocialNetwork> _socialNetworks = [];

        private readonly List<Pet> _pets = [];

        private readonly List<Requisite> _requisites = [];

        //ef  core
        private Volunteer(VolunteerId id) : base(id) { }

        public Volunteer(
            VolunteerId id,
            FullName fullName,
            VolunteerContacts contacts,
            Description description,
            int experienceYears,
            IEnumerable<Requisite> requisites,
            IEnumerable<SocialNetwork> socialNetworks) : this(id)
        {
            Id = id;
            FullName = fullName;
            Contacts = contacts;
            Description = description;
            ExperienceYears = experienceYears;
            _requisites = [.. requisites];
            _socialNetworks = [.. socialNetworks];
        }

        public FullName FullName { get; private set; } = null!;

        public VolunteerContacts Contacts { get; private set; } = null!;

        public Description Description { get; private set; } = null!;

        public int ExperienceYears { get; private set; }

        public IReadOnlyList<Requisite> Requisites => _requisites;

        public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;

        public IReadOnlyList<Pet> Pets => _pets;

        private int GetPetsCountByStatus(HelpStatus status) => Pets.Count(p => p.HelpStatus == status);        
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

        public void UpdateMainInfo(
            FullName fullName,
            VolunteerContacts contacts,
            Description description,
            int experienceYears)
        {
            FullName = fullName;
            Contacts = contacts;
            Description = description;
            ExperienceYears = experienceYears;
        }

        public void UpdateSocialNetworks(IEnumerable<SocialNetwork> socialNetworks)
        {            
            _socialNetworks.Clear();
            _socialNetworks.AddRange(socialNetworks);
        }

        public void UpdateRequisites(IEnumerable<Requisite> requisites)
        {            
            _requisites.Clear();
            _requisites.AddRange(requisites);
        }

        public override void Delete()
        {
            base.Delete();
            foreach (var pet in _pets)
            {
                pet.Delete();
            }
        }

        public override void Restore()
        {
            base.Restore();
            foreach (var pet in _pets)
            {
                pet.Restore();
            }
        }
    }
}
