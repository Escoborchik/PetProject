using CSharpFunctionalExtensions;
using PetProject.Domain.Shared;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class PetColor
    {
        private PetColor(string value) => Value = value;

        public string Value { get; }        

        public static Result<PetColor,Error> Create(string petColor)
        {
            if (string.IsNullOrWhiteSpace(petColor))
                return Errors.General.ValueIsInvalid(nameof(PetColor));

            return new PetColor(petColor);
        }
    }
}
