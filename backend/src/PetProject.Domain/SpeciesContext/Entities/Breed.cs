using CSharpFunctionalExtensions;
using PetProject.Domain.SpeciesContext.ValueObjects;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Domain.SpeciesContext.Entities
{
    public class Breed
    {
        public BreedId BreedId { get; set; }
        public Name Name { get; private set; }

        private Breed(BreedId id, Name name)
        {
            BreedId = id;
            Name = name;
        }

        public static Result<Breed> Create(BreedId id, Name name)
        {
            return Result.Success(new Breed(id, name));
        }       
        
    }
}
