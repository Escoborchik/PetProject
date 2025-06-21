using PetProject.Contracts.DTO;

namespace PetProject.Application.Volunteers.UpdateKeyInfo
{
    public record class UpdateVolunteerKeyInfoCommand(
        Guid VolunteerId,
        FullNameDto FullName,
        string Email,
        string Description,
        int YearsOfExperience,
        string Phone
    );

}
