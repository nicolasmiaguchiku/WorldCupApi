using Microsoft.Extensions.DependencyInjection;
using WorldCup.CrossCutting.Models;

namespace WorldCup.CrossCutting.Extensions
{
    public static class HttpClientExtensions
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, WorldCupSettings worldCupSettings)
        {
            services.AddHttpClient("worldcup", client =>
            {
                client.BaseAddress = new Uri(worldCupSettings.WorldCupUrl);
            });

            return services;
        }
    }
}