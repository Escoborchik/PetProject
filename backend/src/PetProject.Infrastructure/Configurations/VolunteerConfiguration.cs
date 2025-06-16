using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetProject.Domain.Shared;
using PetProject.Domain.Shared.ValueObjects;
using PetProject.Domain.VolunteerContext;
using PetProject.Domain.VolunteerContext.ValueObjects;

namespace PetProject.Infrastructure.Configurations
{
    public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
    {       
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.ToTable("volunteers");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasConversion(
                id => id.Value,
                value => VolunteerId.Create(value))
                .HasColumnName("id");            

            builder.ComplexProperty(v => v.FullName, fb =>
            {
                fb.Property(f => f.FirstName)              
                .IsRequired()
                .HasMaxLength(Constants.MIN_TEXT_LENGTH)
                .HasColumnName("first_name");

                fb.Property(f => f.LastName)                
                .IsRequired()
                .HasMaxLength(Constants.MIN_TEXT_LENGTH)
                .HasColumnName("last_name");

                fb.Property(f => f.MiddleName)                
                .IsRequired()
                .HasMaxLength(Constants.MIN_TEXT_LENGTH)
                .HasColumnName("middle_name");
            });         

            builder.ComplexProperty(v => v.Contacts, db =>
            {
                db.Property(c => c.Email)
                .HasConversion(email =>  email.Value,
                value => Email.Create(value).Value)
                .IsRequired()
                .HasMaxLength(Constants.MIN_TEXT_LENGTH)
                .HasColumnName("email");

                db.Property(c => c.Phone)
                .HasConversion(phone => phone.Value,
                value => Phone.Create(value).Value)
                .IsRequired()
                .HasMaxLength(Constants.MIN_TEXT_LENGTH)
                .HasColumnName("phone");

            });

            builder.ComplexProperty(p => p.Description, db =>
            {
                db.Property(d => d.Value)
                .IsRequired()
                .HasMaxLength(Constants.MAX_TEXT_LENGTH)
                .HasColumnName("description");

            });                    

            builder.Property(v => v.ExperienceYears)
                .IsRequired()
                .HasColumnName("experience_years");                                

            builder.OwnsMany(v => v.Requisites, rb =>
            {
                rb.ToJson("requisites");

                rb.Property(r => r.Name)
                .HasConversion(name => name.Value,
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

            builder.OwnsMany(v => v.SocialNetworks, sb =>
            {
                sb.ToJson("social_networks");

                sb.Property(s => s.Link)
                .IsRequired()
                .HasMaxLength(Constants.MAX_TEXT_LENGTH)
                .HasColumnName("link");

                sb.Property(s => s.Name)
                .HasConversion(
                name => name.Value,
                value => Name.Create(value).Value)
                .IsRequired()
                .HasMaxLength(Constants.MIN_TEXT_LENGTH)
                .HasColumnName("name");
            });

            builder.HasMany(v => v.Pets)
                .WithOne()
                .HasForeignKey("volunteer_id")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(v => v.Pets).AutoInclude();

        }
    }
}
