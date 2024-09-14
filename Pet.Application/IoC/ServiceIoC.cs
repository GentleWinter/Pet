using Microsoft.Extensions.DependencyInjection;
using Pet.Application.Services;
using Pet.Application.Services.Interfaces;

namespace Pet.Application.IoC
{
    public static class ServiceIoC
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPetServices, PetService>();

            return services;
        }
    }
}
