using CSharpFunctionalExtensions;
using PetProject.Domain.Shared;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class Weight
    {
        private Weight(int value) => Value = value;

        public int Value { get; }       
        
        public static Result<Weight,Error> Create(int weight)
        {
            if (weight < 0)
                return Errors.General.ValueIsInvalid(nameof(Weight));       

            return new Weight(weight);
        }
    }
}