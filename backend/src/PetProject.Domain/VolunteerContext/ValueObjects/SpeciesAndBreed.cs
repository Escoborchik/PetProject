using CSharpFunctionalExtensions;
using PetProject.Domain.SpeciesContext.ValueObjects;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class SpeciesAndBreed
    {
        private SpeciesAndBreed(SpeciesId speciesId, BreedId breedId)
        {
            SpeciesId = speciesId;
            BreedId = breedId;
        }
        public SpeciesId SpeciesId { get; }
        public BreedId BreedId { get; }
        public static Result<SpeciesAndBreed> Create(SpeciesId speciesId, BreedId breedId)
        {
            return Result.Success(new SpeciesAndBreed(speciesId, breedId));
        }
    }


}