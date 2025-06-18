using PetProject.Contracts.DTO;

namespace PetProject.API.Requests.Volunteer
{
    public record CreateVolunteerRequest(
        string FirstName,
        string LastName,
        string MiddleName,        
        string Email,
        string Phone,
        string Description,
        int YearsOfExperience,        
        IEnumerable<RequisitesDto> Requisites,
        IEnumerable<SocialNetworksDto> SocialNetworks);        
}
