using CSharpFunctionalExtensions;
using PetProject.Domain.Shared;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class Height
    {
        private Height(int value) => Value = value;

        public int Value { get; }

        public static Result<Height,Error> Create(int height)
        {
            if (height < 0)
                return Errors.General.ValueIsInvalid(nameof(Height));         

            return new Height(height);
        }
    }
}