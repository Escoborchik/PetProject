using PetProject.Domain.Shared.ValueObjects;

namespace PetProject.Domain.VolunteerContext.ValueObjects
{
    public record class VolunteerContacts
    {
        public VolunteerContacts(Email email, Phone phone)
        {
            Email = email;
            Phone = phone;
        }

        public Email Email { get; }
        public Phone Phone { get; }
    }
}
