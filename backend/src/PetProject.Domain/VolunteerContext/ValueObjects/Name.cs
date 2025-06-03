using CSharpFunctionalExtensions;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public class Name
    {

        private Name(string value) => Value = value;
        public string Value { get; }
     
        public static Result<Name> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Name>("Name cant'be empty!");

            var validName = new Name(name);

            return Result.Success(validName);
        }
    }
}