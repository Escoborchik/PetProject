using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetProject.Domain.Shared;
using PetProject.Domain.Shared.ValueObjects;
using PetProject.Domain.SpeciesContext.ValueObjects;
using PetProject.Domain.VolunteerContext.Entities;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Infrastructure.Configurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("pets");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(
                id => id.Value,
                value => PetId.Create(value))
                .HasColumnName("id");

            builder.ComplexProperty(p => p.Name, nb =>
            {
                nb.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(Constants.MIN_TEXT_LENGTH)
                .HasColumnName("name");

            });

            builder.ComplexProperty(p => p.Description, db =>
            {
                db.Property(d => d.Value)
                .IsRequired()
                .HasMaxLength(Constants.MAX_TEXT_LENGTH)
                .HasColumnName("description");

            });

            builder.ComplexProperty(p => p.Characteristics, cb =>
            {
                cb.Property(c => c.Color)
                .HasConversion(color => color.Value,
                value => PetColor.Create(value).Value)
                .IsRequired()
                .HasMaxLength(Constants.MIN_TEXT_LENGTH)
                .HasColumnName("color");

                cb.Property(p => p.Weight)
                .HasConversion(weight => weight.Value,
                value => Weight.Create(value).Value)
                .IsRequired()
                .HasColumnName("weight");

                cb.Property(p => p.Height)
               .HasConversion(height => height.Value,
               value => Height.Create(value).Value)
               .IsRequired()
               .HasColumnName("height");

            });

            builder.ComplexProperty(p => p.HealthInformation, hb =>
            {
                hb.Property(p => p.Description)
                .HasConversion(description => description.Value,
                value => Description.Create(value).Value)
                .IsRequired()
                .HasMaxLength(Constants.MAX_TEXT_LENGTH)
                .HasColumnName("health_information");

                hb.Property(p => p.IsNeutered)
                .IsRequired()
                .HasColumnName("is_neutered");

                hb.Property(p => p.IsVaccinated)
               .IsRequired()
               .HasColumnName("is_vaccinated");

            });

            builder.ComplexProperty(p => p.Address, ab =>
            {
                ab.Property(p => p.City)
                .IsRequired()
                .HasMaxLength(Constants.MIN_TEXT_LENGTH)
                .HasColumnName("address");

                ab.Property(p => p.Street)
                .IsRequired()
                .HasMaxLength(Constants.MIN_TEXT_LENGTH)
                .HasColumnName("street");

                ab.Property(p => p.House)
                .IsRequired()                
                .HasColumnName("house");

            });
            
            builder.ComplexProperty(p => p.Phone, pb =>
            {
                pb.Property(p => p.Value)
                .IsRequired()
                .HasMaxLength(Constants.MIN_TEXT_LENGTH)
                .HasColumnName("phone");

            });            

            builder.Property(p => p.BirthDate)
                .IsRequired()
                .HasColumnName("birthdate");           

            builder.Property(p => p.HelpStatus)
                .HasConversion<string>()
               .IsRequired()
               .HasColumnName("help_status");

            builder.OwnsMany(p => p.Requisites, rb =>
            {
                rb.ToJson("requisites");

                rb.Property(r => r.Name)
                .HasConversion(
                name => name.Value,
                value => Name.Create(value).Value)
                .IsRequired()
                .HasMaxLength(Constants.MIN_TEXT_LENGTH)
                .HasColumnName("name");

                rb.Property(r => r.InfoOfTransfer)
                .HasConversion(description => description.Value,
                value => Description.Create(value).Value)
                .IsRequired()
                .HasMaxLength(Constants.MAX_TEXT_LENGTH)
                .HasColumnName("info_transfere");

            });

            builder.Property(p => p.DateCreation)
                .IsRequired()
                .HasColumnName("date_creation");

            builder.OwnsOne(p => p.SpeciesAndBreed, sb =>
            {
                sb.Property(s => s.SpeciesId)
                .HasConversion(id => id.Value,
                value => SpeciesId.Create(value))
                .HasColumnName("species_id");

                sb.Property(s => s.BreedId)
                .HasConversion(id => id.Value,
                value => BreedId.Create(value))
                .HasColumnName("breed_id");

            });
                    
        }
    }
}
