using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetProject.Application.Volunteers;
using PetProject.Domain.Shared;
using PetProject.Domain.VolunteerContext;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Infrastructure.Repositories
{
    public class VolunteersRepository(ApplicationDbContext dbcontext) : IVolunteersRepository
    {
        private readonly ApplicationDbContext _dbcontext = dbcontext;

        public async Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default)
        {
            await _dbcontext.Volunteers.AddAsync(volunteer, cancellationToken);

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return volunteer.Id;
        }

        public async Task<Result<Volunteer, Error>> GetById(VolunteerId volunteerId, CancellationToken cancellationToken = default)
        {
            var volunteer = await _dbcontext.Volunteers
                .FirstOrDefaultAsync(v => v.Id.Equals(volunteerId), cancellationToken);

            if (volunteer is null)
                return Errors.General.NotFound(volunteerId);

            return volunteer;
        }

        public async Task<Result<Volunteer, Error>> GetByEmail(Email email, CancellationToken cancellationToken = default)
        {
            var volunteer = await _dbcontext.Volunteers
                .FirstOrDefaultAsync(v => v.Contacts.Email.Equals(email), cancellationToken);

            if (volunteer is null)
                return Errors.General.NotFound();

            return volunteer;
        }

        public async Task<Guid> Save(Volunteer volunteer, CancellationToken cancellationToken = default)
        {
            _dbcontext.Volunteers.Attach(volunteer);

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return volunteer.Id;
        }

        public async Task<Guid> Delete(Volunteer volunteer, CancellationToken cancellationToken = default)
        {
            _dbcontext.Volunteers.Remove(volunteer);

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return volunteer.Id;
        }
    }
}
