using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pet.Infra.Contexts;
using Pet.Infra.Repositories;
using Pet.Infra.Repositories.Interfaces;

namespace Pet.Infra.IoC
{
    public static class InfraIoC
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<PetContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<DbContext, PetContext>();
            services.AddScoped<IPetRepository, PetRepository>();

            return services;
        }
    }
}
