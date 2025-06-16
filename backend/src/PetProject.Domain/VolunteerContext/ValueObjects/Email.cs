using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class Email
    {
        private const string REGEX = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        private Email(string email) => Value = email;        

        public string Value { get; }

        public static Result<Email> Create(string email)
        {
            Regex regex = new(REGEX);

            if (regex.IsMatch(email) == false)
                return Result.Failure<Email>($"Specified email address is invalid! : {email}");

            return Result.Success(new Email(email));
        }
    }
}