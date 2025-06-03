using CSharpFunctionalExtensions;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class Height
    {
        private Height(int value) => Value = value;
        public int Value { get; }
        public static Result<Height> Create(int height)
        {
            if (height < 0)
                return Result.Failure<Height>("Height cant'be less than 0!");

            var validHeight = new Height(height);

            return Result.Success(validHeight);
        }
    }
}