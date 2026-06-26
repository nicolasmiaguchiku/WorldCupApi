using Microsoft.Extensions.DependencyInjection;
using WorldCup.Domain.Interface.Services;
using WorldCup.Infrastructure.Services;

namespace WorldCup.CrossCutting.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IWorldCupServices, WorldCupService>();

            return services;
        }
    }
}