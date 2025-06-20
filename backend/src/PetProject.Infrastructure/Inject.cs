﻿using Microsoft.Extensions.DependencyInjection;
using PetProject.Application.Volunteers;
using PetProject.Infrastructure.Repositories;

namespace PetProject.Infrastructure
{
    public static class Inject
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();

            services.AddScoped<IVolunteersRepository,VolunteersRepository>();

            return services;
        }
    }
}
