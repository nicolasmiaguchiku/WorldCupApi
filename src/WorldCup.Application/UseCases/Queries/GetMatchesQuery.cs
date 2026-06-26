using LiteBus.Queries.Abstractions;
using WorldCup.Domain.Models;

namespace WorldCup.Application.UseCases.Queries;

public record GetMatchesQuery : IQuery<Result<MatchesResponse>>;