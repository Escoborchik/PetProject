using CSharpFunctionalExtensions;
using PetProject.Domain.Shared.ValueObjects;
using PetProject.Domain.VolunteerContext.Enums;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Domain.VolunteerContext.Entities
{
    public class Pet : Entity
    {
        public Pet(PetId id,
            Name name,
            Description description,
            PetColor color,
            HealthInformation healthInformation,
            Address address,
            Weight weight,
            Height height,
            Phone phone,
            bool isNeutered,
            DateOnly birthDate,
            bool isVaccinated,
            HelpStatus helpStatus,
            Requisite requisites,
            DateOnly dateCreation,
            SpeciesAndBreed speciesAndBreed)
        {
            Id = id;
            Name = name;
            Description = description;
            Color = color;
            HealthInformation = healthInformation;
            Address = address;
            Weight = weight;
            Height = height;
            Phone = phone;
            IsNeutered = isNeutered;
            BirthDate = birthDate;
            IsVaccinated = isVaccinated;
            HelpStatus = helpStatus;
            Requisites = requisites;
            DateCreation = dateCreation;
            SpeciesAndBreed = speciesAndBreed;
        }

        public PetId Id { get; private set; }
        public Name Name { get; private set; }
        public Description Description { get; private set; }
        public PetColor Color { get; private set; }
        public HealthInformation HealthInformation { get; private set; }
        public Address Address { get; private set; }
        public Weight Weight { get; private set; }
        public Height Height { get; private set; }
        public Phone Phone { get; private set; }
        public bool IsNeutered { get; private set; }
        public DateOnly BirthDate { get; private set; }
        public bool IsVaccinated { get; private set; }
        public HelpStatus HelpStatus { get; private set; }
        public Requisite Requisites { get; private set; }
        public DateOnly DateCreation { get; private set; }
        public SpeciesAndBreed SpeciesAndBreed { get; private set; }         
    }
}
