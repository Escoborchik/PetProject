using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetProject.Domain.Shared;
using PetProject.Domain.SpeciesContext.Entities;
using PetProject.Domain.SpeciesContext.ValueObjects;

namespace PetProject.Infrastructure.Configurations
{
    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.ToTable("breeds");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasConversion(
                id => id.Value,
                value => BreedId.Create(value))
                .HasColumnName("id");

            builder.ComplexProperty(b => b.Name, nb =>
            {
                nb.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(Constants.MIN_TEXT_LENGTH)
                .HasColumnName("name");
                
            });
        }
    }
}
