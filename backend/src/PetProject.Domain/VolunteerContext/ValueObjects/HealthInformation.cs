using CSharpFunctionalExtensions;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class HealthInformation
    {
        private HealthInformation(string value) => Value = value;
        public string Value { get; }        
        public static Result<HealthInformation> Create(string healthInformation)
        {
            if (string.IsNullOrWhiteSpace(healthInformation))
                return Result.Failure<HealthInformation>("HealthInformation cant'be empty!");

            var validhealthInformation = new HealthInformation(healthInformation);

            return Result.Success(validhealthInformation);
        }
    }
}