using CSharpFunctionalExtensions;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public class Weight
    {
        private Weight(int value) => Value = value;
        public int Value { get; }        

        public static Result<Weight> Create(int weight)
        {
            if (weight < 0)
                return Result.Failure<Weight>("Weight cant'be less than 0!");

            var validWeight = new Weight(weight);

            return Result.Success(validWeight);
        }
    }
}