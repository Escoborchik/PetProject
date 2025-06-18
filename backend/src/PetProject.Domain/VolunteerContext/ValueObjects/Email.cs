using CSharpFunctionalExtensions;
using PetProject.Domain.Shared;
using System.Text.RegularExpressions;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class Email
    {
        private const string REGEX = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        private Email(string email) => Value = email;        

        public string Value { get; }

        public static Result<Email,Error> Create(string email)
        {
            Regex regex = new(REGEX);

            if (regex.IsMatch(email) == false)
                return Errors.General.ValueIsInvalid(nameof(Email));

            return new Email(email);
        }
    }
}