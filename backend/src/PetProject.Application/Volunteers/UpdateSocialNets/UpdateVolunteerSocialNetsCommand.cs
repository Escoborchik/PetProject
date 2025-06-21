using PetProject.Contracts.DTO;

namespace PetProject.Application.Volunteers.UpdateSocialNets
{
    public record class UpdateVolunteerSocialNetsCommand(
        Guid VolunteerId,
        IEnumerable<SocialNetworksDto> SocialNetworks
        );
}
