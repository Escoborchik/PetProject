using CSharpFunctionalExtensions;

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
        public static Result<SocialNetwork> Create(string link, Name name)
        {
            if (string.IsNullOrWhiteSpace(link))
                return Result.Failure<SocialNetwork>("Link cannot be null or empty.");

            var validSocialNetwork = new SocialNetwork(link, name);

            return Result.Success(validSocialNetwork);
        }
    }
}