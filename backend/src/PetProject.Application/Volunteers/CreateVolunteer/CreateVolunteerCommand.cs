using PetProject.Contracts.DTO;

namespace PetProject.Application.Volunteers.CreateVolunteer
{
    public record class CreateVolunteerCommand(
        string FirstName,
        string LastName,
        string MiddleName,        
        string Email,
        string Description,
        int YearsOfExperience,
        string Phone,
        IEnumerable<RequisitesDto> Requisites,
        IEnumerable<SocialNetworksDto> SocialNetworks
        );
}
