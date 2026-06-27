using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WorldCup.Application.UseCases.Queries;
using WorldCup.Domain.Models;

namespace WorldCup.Api.Controllers;

[ApiController]
[Route("api/v1")]
public class WeatherForecastController(IQueryMediator queryMediator) : ControllerBase
{
    [HttpGet("games")]
    public async Task<IActionResult> GetMatchesAsync(CancellationToken cancellationToken)
    {
        Result<MatchesResponse> result = await queryMediator.QueryAsync(new GetMatchesQuery(), cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Data);
    }
}