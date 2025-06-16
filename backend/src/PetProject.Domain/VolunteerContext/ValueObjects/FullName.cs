using CSharpFunctionalExtensions;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class FullName
    {
        private FullName(string firstName, string lastName, string middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string MiddleName { get; }

        public static Result<FullName> Create(string firstName, string lastName, string middleName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return Result.Failure<FullName>("FirstName is null or empty");

            if (string.IsNullOrWhiteSpace(lastName))
                return Result.Failure<FullName>("LastName is null or empty");

            if (string.IsNullOrWhiteSpace(middleName))
                return Result.Failure<FullName>("MiddleName is null or empty");

            return new FullName(firstName, lastName, middleName);
        }
    }
}