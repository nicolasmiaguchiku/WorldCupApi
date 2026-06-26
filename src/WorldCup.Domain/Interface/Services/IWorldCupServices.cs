using WorldCup.Domain.Models;

namespace WorldCup.Domain.Interface.Services;

public interface IWorldCupServices
{
    public Task<Result<MatchesResponse>> GetListMatchAsync(CancellationToken cancellationToken);
}