using CSharpFunctionalExtensions;
using PetProject.Domain.Shared;
using PetProject.Domain.Shared.ValueObjects;
using PetProject.Domain.VolunteerContext.Enums;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Domain.VolunteerContext.Entities
{
    public class Pet : SoftDeletableEntity<PetId>
    {
        private readonly List<Requisite> _requisites = [];

        //ef  core
        private Pet(PetId id): base(id) { }

        public Pet(PetId id,
            Name name,
            Description description,
            PetCharacteristics characteristics,
            HealthInformation healthInformation, 
            Address address,
            Phone phone,
            DateOnly birthDate,
            HelpStatus helpStatus, 
            DateOnly dateCreation, 
            SpeciesAndBreed speciesAndBreed) : this(id)
        {
            Id = id;
            Name = name;
            Description = description;
            Characteristics = characteristics;
            HealthInformation = healthInformation;
            Address = address;
            Phone = phone;
            BirthDate = birthDate;
            HelpStatus = helpStatus;
            DateCreation = dateCreation;
            SpeciesAndBreed = speciesAndBreed;
        }

        public Name Name { get; private set; } = null!;

        public Description Description { get; private set; } = null!;

        public PetCharacteristics Characteristics { get; private set; } = null!;

        public HealthInformation HealthInformation { get; private set; } = null!;

        public Address Address { get; private set; } = null!;

        public Phone Phone { get; private set; } = null!;

        public DateOnly BirthDate { get; private set; }

        public HelpStatus HelpStatus { get; private set; }

        public IReadOnlyList<Requisite> Requisites => _requisites;

        public DateOnly DateCreation { get; private set; }

        public SpeciesAndBreed SpeciesAndBreed { get; private set; } = null!;

        public Result AddRequisite(Requisite requisite)
        {
            if (_requisites.Contains(requisite))
                return Result.Failure("Requisite already exists in the volunteer's list.");

            _requisites.Add(requisite);

            return Result.Success();
        }
    }
}
