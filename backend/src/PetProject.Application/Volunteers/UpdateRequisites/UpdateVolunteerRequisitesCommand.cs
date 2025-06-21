using PetProject.Contracts.DTO;

namespace PetProject.Application.Volunteers.UpdateRequisites
{    
    public record class UpdateVolunteerRequisitesCommand(
        Guid VolunteerId,
        IEnumerable<RequisitesDto> Requisites
        );
}
