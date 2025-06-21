using PetProject.Contracts.DTO;

namespace PetProject.Application.Volunteers.Create
{
    public record class CreateVolunteerCommand(
        FullNameDto FullName,       
        string Email,
        string Description,
        int YearsOfExperience,
        string Phone,
        IEnumerable<RequisitesDto> Requisites,
        IEnumerable<SocialNetworksDto> SocialNetworks
        );
}
