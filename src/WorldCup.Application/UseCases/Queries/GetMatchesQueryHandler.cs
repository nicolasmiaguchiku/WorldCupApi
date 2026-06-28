using LiteBus.Queries.Abstractions;
using WorldCup.Domain.Interface.Services;
using WorldCup.Domain.Models;

namespace WorldCup.Application.UseCases.Queries
{
    public record GetMatchesQueryHandler(IWorldCupServices WorldCupServices, IMemoryCacheService MemoryCacheService) : IQueryHandler<GetMatchesQuery, Result<MatchesResponse>>
    {
        public async Task<Result<MatchesResponse>> HandleAsync(GetMatchesQuery message, CancellationToken cancellationToken = default)
        {
            Result<MatchesResponse>? matches;

            matches = MemoryCacheService.Get<Result<MatchesResponse>>("matchesList");

            if (matches is not null)
            {
                return Result<MatchesResponse>.Success(matches.Data);
            }

            matches = await WorldCupServices.GetListMatchAsync(cancellationToken);

            return matches;
        }
    }
}