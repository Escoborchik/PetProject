using CSharpFunctionalExtensions;
using PetProject.Domain.Shared.ValueObjects;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class HealthInformation
    {
        public HealthInformation(Description description, bool isNeutered, bool isVaccinated)
        {
            Description = description;
            IsNeutered = isNeutered;
            IsVaccinated = isVaccinated;
        }

        public Description Description { get; }

        public bool IsNeutered { get; }

        public bool IsVaccinated { get; }

    }
}