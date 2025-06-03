using PetProject.Domain.SpeciesContext.ValueObjects;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class SpeciesAndBreed
    {
        public SpeciesAndBreed(SpeciesId speciesId, BreedId breedId)
        {
            SpeciesId = speciesId;
            BreedId = breedId;
        }
        public SpeciesId SpeciesId { get; }
        public BreedId BreedId { get; }        
    }
}