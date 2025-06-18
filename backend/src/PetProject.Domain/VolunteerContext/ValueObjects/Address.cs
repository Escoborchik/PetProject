using CSharpFunctionalExtensions;
using PetProject.Domain.Shared;

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

        public static Result<Address,Error> Create(string city, string street, string house)
        {
            if (string.IsNullOrWhiteSpace(city))
                return Errors.General.ValueIsInvalid(nameof(City));

            if (string.IsNullOrWhiteSpace(street))
                return Errors.General.ValueIsInvalid(nameof(Street));

            if (string.IsNullOrWhiteSpace(house))
                return Errors.General.ValueIsInvalid(nameof(House));

            if (!int.TryParse(house, out int houseNumber))
                return Errors.General.ValueIsInvalid(nameof(House));

            var validAddress = new Address(city,street, houseNumber);

            return validAddress;
        }
    }
}