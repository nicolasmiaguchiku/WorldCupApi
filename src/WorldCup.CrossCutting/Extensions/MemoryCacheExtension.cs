using Microsoft.Extensions.DependencyInjection;
using WorldCup.Domain.Interface.Services;
using WorldCup.Infrastructure.Services;

namespace WorldCup.CrossCutting.Extensions
{
    public static class MemoryCacheExtension
    {
        public static IServiceCollection AddMemoryCacheService(this IServiceCollection services)
        {
            services.AddMemoryCache(options =>
            {
                options.SizeLimit = 1024; // Limite máximo de itens no cache
                options.ExpirationScanFrequency = TimeSpan.FromMinutes(3); // De quanto em quanto tempo limpa itens expirados da memória
            });

            services.AddSingleton<IMemoryCacheService, MemoryCacheService>();

            return services;
        }
    }
}