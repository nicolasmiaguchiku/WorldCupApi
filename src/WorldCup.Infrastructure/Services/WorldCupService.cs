using Flurl;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WorldCup.Domain.Errors;
using WorldCup.Domain.Interface.Services;
using WorldCup.Domain.Models;

namespace WorldCup.Infrastructure.Services
{
    public class WorldCupService(IHttpClientFactory httpClientFactory, IMemoryCacheService memoryCacheService) : IWorldCupServices
    {
        public HttpClient httpClient = httpClientFactory.CreateClient("worldcup");

        private static readonly JsonSerializerSettings Settings = new()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
        };

        public async Task<Result<MatchesResponse>> GetListMatchAsync(CancellationToken cancellationToken)
        {
            Url url = httpClient.BaseAddress
                .AppendPathSegment("get")
                .AppendPathSegment("games");

            HttpResponseMessage response = await httpClient.GetAsync(url, cancellationToken);
            string content = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                string message = $"StatusCode {response.StatusCode} - ReasonPhrase {response.ReasonPhrase} - Response {content}";
                MatchesErrors.SetTechnicalMessage(message);

                return Result<MatchesResponse>.Failure(MatchesErrors.GetMatchesError);
            }

            MatchesResponse matches = JsonConvert.DeserializeObject<MatchesResponse>(content)!;

            return Result<MatchesResponse>.Success(matches);
        }
    }
}