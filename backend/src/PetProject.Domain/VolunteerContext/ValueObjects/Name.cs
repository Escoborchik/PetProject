using CSharpFunctionalExtensions;
using PetProject.Domain.Shared;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class Name
    {
        private Name(string value) => Value = value;

        public string Value { get; }     

        public static Result<Name, Error> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Errors.General.ValueIsInvalid(nameof(Name));

            return new Name(name);
        }
    }
}