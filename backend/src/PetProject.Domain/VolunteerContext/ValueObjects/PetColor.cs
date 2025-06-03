using CSharpFunctionalExtensions;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public class PetColor
    {
        private PetColor(string value) => Value = value;
        public string Value { get; }        
        public static Result<PetColor> Create(string petColor)
        {
            if (string.IsNullOrWhiteSpace(petColor))
                return Result.Failure<PetColor>("Color cant'be empty!");

            var validPetColor = new PetColor(petColor);

            return Result.Success(validPetColor);
        }
    }
}
