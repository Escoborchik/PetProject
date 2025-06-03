using PetProject.Domain.SpeciesContext.ValueObjects;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Domain.SpeciesContext.Entities
{
    public class Breed
    {
        public BreedId BreedId { get; private set; }
        public Name Name { get; private set; }

        public Breed(BreedId id, Name name)
        {
            BreedId = id;
            Name = name;
        }                      
    }
}
