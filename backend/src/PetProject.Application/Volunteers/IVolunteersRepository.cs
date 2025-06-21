using CSharpFunctionalExtensions;
using PetProject.Domain.Shared;
using PetProject.Domain.VolunteerContext;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Application.Volunteers
{
    public interface IVolunteersRepository
    {
        Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default);
        Task<Result<Volunteer, Error>> GetByEmail(Email email, CancellationToken cancellationToken = default);
        Task<Result<Volunteer, Error>> GetById(VolunteerId volunteerId, CancellationToken cancellationToken = default);
        Task<Guid> Save(Volunteer existingVolunteer, CancellationToken cancellationToken = default);
        Task<Guid> Delete(Volunteer volunteer, CancellationToken cancellationToken = default);
    }
}