using CSharpFunctionalExtensions;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class Address
    {
        private Address(string value) => Value = value;
        public string Value { get; }        
        public static Result<Address> Create(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return Result.Failure<Address>("Address cant'be empty!");

            var validAddress = new Address(address);

            return Result.Success(validAddress);
        }
    }
}