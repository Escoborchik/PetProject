using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PetProject.Domain.VolunteerContext;

namespace PetProject.Infrastructure
{
    public class ApplicationDbContext(IConfiguration configuration) : DbContext
    {
        private const string DATABASE = "Database";

        private readonly IConfiguration _configuration = configuration;

        public DbSet<Volunteer> Volunteers => Set<Volunteer>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString(DATABASE));
            optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        private static ILoggerFactory CreateLoggerFactory() => 
            LoggerFactory.Create(builder => builder.AddConsole());
    }
}
