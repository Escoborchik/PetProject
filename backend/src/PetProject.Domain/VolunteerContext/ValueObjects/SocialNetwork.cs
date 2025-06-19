using CSharpFunctionalExtensions;
using PetProject.Domain.Shared;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class SocialNetwork
    {
        public SocialNetwork(Link link, Name name)
        {
            Link = link;
            Name = name;
        }
        public Link Link { get; }

        public Name Name { get; }
        
    }
}