using PetProject.Contracts.DTO;

namespace PetProject.Application.Volunteers.UpdateMainInfo
{
    public record class UpdateVolunteerMainInfoCommand(
        Guid VolunteerId,
        FullNameDto FullName,
        string Email,
        string Description,
        int YearsOfExperience,
        string Phone
    );

}
