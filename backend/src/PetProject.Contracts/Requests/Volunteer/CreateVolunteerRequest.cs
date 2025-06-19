using PetProject.Contracts.DTO;

namespace PetProject.Contracts.Requests.Volunteer
{
    public record CreateVolunteerRequest(
        FullNameDto FullName,
        string Email,
        string Phone,
        string Description,
        int YearsOfExperience,
        IEnumerable<RequisitesDto> Requisites,
        IEnumerable<SocialNetworksDto> SocialNetworks);

}
