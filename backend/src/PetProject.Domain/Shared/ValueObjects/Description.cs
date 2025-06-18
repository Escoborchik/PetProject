using CSharpFunctionalExtensions;

namespace PetProject.Domain.Shared.ValueObjects
{
    public record class Description
    {
        private Description(string value) => Value = value;

        public string Value { get; }

        public static Result<Description,Error> Create(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return Errors.General.ValueIsInvalid(nameof(Description));

            return new Description(description);
        }
    }
}