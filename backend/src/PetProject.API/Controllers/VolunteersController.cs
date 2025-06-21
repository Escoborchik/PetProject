using Microsoft.AspNetCore.Mvc;
using PetProject.API.Extensions;
using PetProject.API.Response;
using PetProject.Application.Volunteers.Create;
using PetProject.Application.Volunteers.Delete;
using PetProject.Application.Volunteers.UpdateMainInfo;
using PetProject.Application.Volunteers.UpdateRequisites;
using PetProject.Application.Volunteers.UpdateSocialNets;
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

        [HttpPut("{id:guid}/key-info")]
        public async Task<ActionResult<Guid>> Update(
        [FromRoute] Guid id,
        [FromServices] UpdateVolunteerMainInfoHandler handler,
        [FromBody] UpdateVolunteerMainInfoRequest request,
        CancellationToken cancellationToken)
        {
            var command = new UpdateVolunteerMainInfoCommand(
                id,
                request.FullName,
                request.Email,
                request.Description,
                request.YearsOfExperience,
                request.Phone               
            );

            var result = await handler.Execute(command, cancellationToken);

            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(Envelope.Ok(result.Value));
        }        

        [HttpPut("{id:guid}/requisites")]
        public async Task<ActionResult<Guid>> Update(
        [FromRoute] Guid id,
        [FromServices] UpdateVolunteerRequisitesHandler handler,
        [FromBody] UpdateVolunteerRequisitesRequest request,
        CancellationToken cancellationToken)
        {
            var command = new UpdateVolunteerRequisitesCommand(
                id,
                request.Requisites               
            );

            var result = await handler.Execute(command, cancellationToken);

            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(Envelope.Ok(result.Value));
        }

        [HttpPut("{id:guid}/social-networks")]
        public async Task<ActionResult<Guid>> Update(
        [FromRoute] Guid id,
        [FromServices] UpdateVolunteerSocialNetsHandler handler,
        [FromBody] UpdateVolunteerSocialNetsRequest request,
        CancellationToken cancellationToken)
        {
            var command = new UpdateVolunteerSocialNetsCommand(
                id,
                request.SocialNetworks
            );

            var result = await handler.Execute(command, cancellationToken);

            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(Envelope.Ok(result.Value));
        }

        [HttpDelete("{id:guid}/soft")]
        public async Task<ActionResult<Guid>> Delete(
        [FromRoute] Guid id,
        [FromServices] DeleteSoftVolunteerHandler handler,        
        CancellationToken cancellationToken)
        {
            var command = new DeleteVolunteerCommand(id);

            var result = await handler.Execute(command, cancellationToken);

            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(Envelope.Ok(result.Value));
        }

        [HttpDelete("{id:guid}/hard")]
        public async Task<ActionResult<Guid>> Delete(
        [FromRoute] Guid id,
        [FromServices] DeleteHardVolunteerHandler handler,
        CancellationToken cancellationToken)
        {
            var command = new DeleteVolunteerCommand(id);

            var result = await handler.Execute(command, cancellationToken);

            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(Envelope.Ok(result.Value));
        }
    }
}
