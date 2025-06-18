using CSharpFunctionalExtensions;
using PetProject.Domain.Shared;

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

        public static Result<FullName,Error> Create(string firstName, string lastName, string middleName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return Errors.General.ValueIsInvalid(nameof(FirstName));

            if (string.IsNullOrWhiteSpace(lastName))
                return Errors.General.ValueIsInvalid(nameof(LastName));       

            if (string.IsNullOrWhiteSpace(middleName))
                return Errors.General.ValueIsInvalid(nameof(MiddleName));

            return new FullName(firstName, lastName, middleName);
        }
    }
}