using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetProject.Domain.Shared;
using PetProject.Domain.SpeciesContext;
using PetProject.Domain.SpeciesContext.ValueObjects;

namespace PetProject.Infrastructure.Configurations
{
    public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
    {
        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.ToTable("species");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasConversion(
                id => id.Value,
                value => SpeciesId.Create(value))
                .HasColumnName("id");

            builder.ComplexProperty(s => s.Name, nb =>
            {
                nb.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(Constants.MIN_TEXT_LENGTH)
                .HasColumnName("name");

            });

            builder.HasMany(s => s.Breeds)
               .WithOne()
               .HasForeignKey("species_id")
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
