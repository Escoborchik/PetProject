using CSharpFunctionalExtensions;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class Address
    {
        private Address(string city, string street, int house)
        {
            City = city;
            Street = street;
            House = house;
        }
        public string City { get; }        
        public string Street { get; }        
        public int House { get; }        

        public static Result<Address> Create(string city, string street, string house)
        {
            if (string.IsNullOrWhiteSpace(city))
                return Result.Failure<Address>("Address cant'be empty!");

            if (string.IsNullOrWhiteSpace(street))
                return Result.Failure<Address>("Address cant'be empty!");

            if (string.IsNullOrWhiteSpace(house))
                return Result.Failure<Address>("Address cant'be empty!");

            if (!int.TryParse(house, out int houseNumber))
                return Result.Failure<Address>("House is not a digit!");

            var validAddress = new Address(city,street, houseNumber);

            return Result.Success(validAddress);
        }
    }
}