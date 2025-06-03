using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace PetProject.Domain.Shared.ValueObjects
{


    public class Phone
    {
        private const string PhoneRegexPattern =
            @"^[\+]?[(]?[0-9]{1,4}[)]?[-\s\.]?[0-9]{1,4}[-\s\.]?[0-9]{1,9}$";

        private Phone(string value) => Value = value;

        public string Value { get; }

        public static Result<Phone> Create(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return Result.Failure<Phone>("Phone number cannot be empty!");

            if (!Regex.IsMatch(phone, PhoneRegexPattern))
                return Result.Failure<Phone>($"Invalid phone number format: {phone}");

            return Result.Success(new Phone(phone));
        }
    }
}