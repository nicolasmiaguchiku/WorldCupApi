using LiteBus.Queries.Abstractions;
using WorldCup.Domain.Interface.Services;
using WorldCup.Domain.Models;

namespace WorldCup.Application.UseCases.Queries
{
    public record GetMatchesQueryHandler(IWorldCupServices WorldCupServices) : IQueryHandler<GetMatchesQuery, Result<MatchesResponse>>
    {
        public async Task<Result<MatchesResponse>> HandleAsync(GetMatchesQuery message, CancellationToken cancellationToken = default)
        {
            Result<MatchesResponse> matches = await WorldCupServices.GetListMatchAsync(cancellationToken);

            return matches;
        }
    }
}