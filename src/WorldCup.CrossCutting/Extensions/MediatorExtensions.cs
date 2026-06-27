using LiteBus.Messaging.Extensions.MicrosoftDependencyInjection;
using LiteBus.Queries.Extensions.MicrosoftDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WorldCup.Application.UseCases.Queries;

namespace WorldCup.CrossCutting.Extensions
{
    public static class MediatorExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddLiteBus(litebus =>
            {
                litebus.AddQueryModule(module =>
                {
                    module.RegisterFromAssembly(typeof(GetMatchesQuery).Assembly);
                });

            });

            return services;
        }
    }
}