using PetProject.Domain.SpeciesContext.ValueObjects;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Domain.SpeciesContext.Entities
{
    public class Breed
    {
        //ef  core
        private Breed() { }
        public Breed(BreedId id, Name name)
        {
            Id = id;
            Name = name;
        }
        public BreedId Id { get; private set; } = null!;

        public Name Name { get; private set; } = null!;

                            
    }
}
