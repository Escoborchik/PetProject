using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PetProject.Application.Volunteers.Create;
using PetProject.Application.Volunteers.UpdateMainInfo;
using PetProject.Application.Volunteers.UpdateRequisites;
using PetProject.Application.Volunteers.UpdateSocialNets;

namespace PetProject.Application
{
    public static class Inject
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<CreateVolunteerHandler>();

            services.AddScoped<UpdateVolunteerMainInfoHandler>();

            services.AddScoped<UpdateVolunteerRequisitesHandler>();

            services.AddScoped<UpdateVolunteerSocialNetsHandler>();

            services.AddValidatorsFromAssembly(typeof(Inject).Assembly);

            return services;
        }
    }
}
