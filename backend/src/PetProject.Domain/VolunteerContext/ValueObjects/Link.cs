using CSharpFunctionalExtensions;
using PetProject.Domain.Shared;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class Link
    {
        private Link(string value) => Value = value;

        public string Value { get; }

        public static Result<Link, Error> Create(string link)
        {
            if (string.IsNullOrWhiteSpace(link))
                return Errors.General.ValueIsInvalid(nameof(Link));

            return new Link(link);
        }
    }
}