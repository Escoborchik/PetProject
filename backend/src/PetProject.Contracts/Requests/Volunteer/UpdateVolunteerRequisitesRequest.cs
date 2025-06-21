using PetProject.Contracts.DTO;

namespace PetProject.Contracts.Requests.Volunteer
{
    public record class UpdateVolunteerRequisitesRequest(
        IEnumerable<RequisitesDto> Requisites
        );
}
