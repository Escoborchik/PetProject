using Microsoft.AspNetCore.Mvc;
using PetProject.API.Extensions;
using PetProject.API.Response;
using PetProject.Application.Volunteers.CreateVolunteer;
using PetProject.Contracts.Requests.Volunteer;

namespace PetProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteersController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(
        [FromServices] CreateVolunteerHandler handler,
        [FromBody] CreateVolunteerRequest request,
        CancellationToken cancellationToken)
        {
            var command = new CreateVolunteerCommand(
                request.FullName,
                request.Email,
                request.Description,
                request.YearsOfExperience,
                request.Phone,
                request.Requisites,
                request.SocialNetworks
            );            

            var result = await handler.Execute(command, cancellationToken);  
            
            if (result.IsFailure)
                return result.Error.ToResponse();       

            return Ok(Envelope.Ok(result.Value));
        }
    }
}
