using CSharpFunctionalExtensions;
using PetProject.Domain.SpeciesContext.Entities;
using PetProject.Domain.SpeciesContext.ValueObjects;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Domain.SpeciesContext
{
    public class Species
    {
        private readonly List<Breed> _breeds = [];

        //ef  core
        private Species() { }

        public Species(SpeciesId id, Name name)
        {
            Id = id;
            Name = name;            
        }

        public SpeciesId Id { get; private set; } = null!;

        public Name Name { get; private set; } = null!;

        public IReadOnlyList<Breed> Breeds => _breeds;

        public Result AddBreed(Breed breed)
        {
            if (_breeds.Contains(breed))
                return Result.Failure("Pet already exists in the volunteer's list.");

            _breeds.Add(breed);

            return Result.Success();
        }       
    }
}
