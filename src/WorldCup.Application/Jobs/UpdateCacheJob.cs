using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WorldCup.Domain.Interface.Services;
using WorldCup.Domain.Models;

namespace WorldCup.Application.Jobs
{
    public class UpdateCacheJob(IServiceScopeFactory scopeFactory, ILogger<UpdateCacheJob> logger) : BackgroundService
    {
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(2);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await RefreshCacheAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Erro ao atualizar cache de matches");
                }

                await Task.Delay(_interval, stoppingToken);
            }
        }

        private async Task RefreshCacheAsync(CancellationToken cancellationToken)
        {

            AsyncServiceScope scope = scopeFactory.CreateAsyncScope();
            IWorldCupServices? matchesService = scope.ServiceProvider.GetRequiredService<IWorldCupServices>();

            Result<MatchesResponse> result = await matchesService.GetListMatchAsync(cancellationToken);

            if (result.IsFailure)
            {
                logger.LogWarning("Falha ao atualizar cache: {Error}", result.Error);
            }
            else
            {
                logger.LogInformation("Cache de matches atualizado com sucesso");
            }
        }
    }
}