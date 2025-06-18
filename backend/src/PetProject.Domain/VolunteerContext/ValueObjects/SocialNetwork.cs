using CSharpFunctionalExtensions;
using PetProject.Domain.Shared;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class SocialNetwork
    {
        private SocialNetwork(string link, Name name)
        {
            Link = link;
            Name = name;
        }
        public string Link { get; }

        public Name Name { get; }

        public static Result<SocialNetwork, Error> Create(string link, Name name)
        {
            if (string.IsNullOrWhiteSpace(link))
                return Errors.General.ValueIsInvalid(nameof(Link));

            return new SocialNetwork(link, name);
        }
    }
}