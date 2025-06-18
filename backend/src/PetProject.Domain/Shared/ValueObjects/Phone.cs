using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace PetProject.Domain.Shared.ValueObjects
{
    public record class Phone
    {
        private const string PhoneRegexPattern =
            @"^[\+]?[(]?[0-9]{1,4}[)]?[-\s\.]?[0-9]{1,4}[-\s\.]?[0-9]{1,9}$";

        private Phone(string value) => Value = value;

        public string Value { get; }

        public static Result<Phone,Error> Create(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return Errors.General.ValueIsInvalid(nameof(Phone));

            if (!Regex.IsMatch(phone, PhoneRegexPattern))
                return Errors.General.ValueIsInvalid(nameof(Phone));

            return new Phone(phone);
        }
    }
}