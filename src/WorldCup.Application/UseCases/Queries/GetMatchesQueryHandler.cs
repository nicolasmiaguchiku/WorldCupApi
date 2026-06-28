using LiteBus.Queries.Abstractions;
using WorldCup.Domain.Interface.Services;
using WorldCup.Domain.Models;

namespace WorldCup.Application.UseCases.Queries
{
    public record GetMatchesQueryHandler(IWorldCupServices WorldCupServices, IMemoryCacheService MemoryCacheService) : IQueryHandler<GetMatchesQuery, Result<MatchesResponse>>
    {
        public async Task<Result<MatchesResponse>> HandleAsync(GetMatchesQuery message, CancellationToken cancellationToken = default)
        {
            Result<MatchesResponse> matchesService;
            MatchesResponse? matchesCache;

            matchesCache = MemoryCacheService.Get<MatchesResponse>("matchesList");

            if (matchesCache is not null)
            {
                return Result<MatchesResponse>.Success(matchesCache);
            }

            matchesService = await WorldCupServices.GetListMatchAsync(cancellationToken);

            return matchesService;
        }
    }
}