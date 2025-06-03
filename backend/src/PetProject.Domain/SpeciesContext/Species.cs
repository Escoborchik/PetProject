using CSharpFunctionalExtensions;
using PetProject.Domain.SpeciesContext.Entities;
using PetProject.Domain.SpeciesContext.ValueObjects;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Domain.SpeciesContext
{
    public class Species
    {
        private readonly List<Breed> _breeds = [];
        private Species(SpeciesId id, Name name)
        {
            Id = id;
            Name = name;            
        }

        public SpeciesId Id { get; private set; }
        public Name Name { get; private set; }
        public IReadOnlyList<Breed> Breeds => _breeds;


        public Result AddBreed(Breed breed)
        {
            if (_breeds.Contains(breed))
                return Result.Failure("Pet already exists in the volunteer's list.");

            _breeds.Add(breed);

            return Result.Success();
        }

        public static Result<Species> Create(SpeciesId id, Name name)
        {
            return Result.Success(new Species(id, name));
        }
    }
}
