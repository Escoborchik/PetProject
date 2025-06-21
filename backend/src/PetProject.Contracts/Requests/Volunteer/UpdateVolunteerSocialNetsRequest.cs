using PetProject.Contracts.DTO;

namespace PetProject.Contracts.Requests.Volunteer
{
    public record class UpdateVolunteerSocialNetsRequest(
        IEnumerable<SocialNetworksDto> SocialNetworks
        );
    
}
