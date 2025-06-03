using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Domain.Shared.ValueObjects
{
    public record class Requisite
    {
        public Requisite(Name name, Description infoOfTransfer)
        {
            Name = name;
            InfoOfTransfer = infoOfTransfer;
        }
        public Name Name { get; }
        public Description InfoOfTransfer { get; }       
    }
}