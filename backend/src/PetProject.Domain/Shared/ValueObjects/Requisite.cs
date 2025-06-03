using CSharpFunctionalExtensions;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Domain.Shared.ValueObjects
{
    public class Requisite
    {
        private Requisite(Name name, Description infoOfTransfer)
        {
            Name = name;
            InfoOfTransfer = infoOfTransfer;
        }
        public Name Name { get; }
        public Description InfoOfTransfer { get; }
        public static Result<Requisite> Create(Name name, Description infoOfTransfer)
        {
            var requisites = new Requisite(name, infoOfTransfer);

            return Result.Success(requisites);
        }
    }
}