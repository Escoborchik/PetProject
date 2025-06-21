using PetProject.Contracts.DTO;

namespace PetProject.Contracts.Requests.Volunteer
{
    public record class UpdateVolunteerMainInfoRequest(
        FullNameDto FullName,
        string Email,
        string Description,
        int YearsOfExperience,
        string Phone
    );
}
