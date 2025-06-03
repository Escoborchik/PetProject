using CSharpFunctionalExtensions;

namespace PetProject.Domain.Shared.ValueObjects
{
    public class Description
    {
        private Description(string value) => Value = value;
        public string Value { get; }
        public static Result<Description> Create(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return Result.Failure<Description>("Description cant'be empty!");

            var validDescription = new Description(description);

            return Result.Success(validDescription);
        }
    }
}