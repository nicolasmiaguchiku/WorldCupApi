using Newtonsoft.Json;

namespace WorldCup.Domain.Models;

public class MatchesResponse
{
    public List<Match>? Games { get; set; }
}

public class Match
{
    [JsonProperty("_id")]
    public string? Id { get; set; }

    [JsonProperty("id")]
    public string? MatchId { get; set; }

    [JsonProperty("home_team_id")]
    public string? HomeTeamId { get; set; }

    [JsonProperty("away_team_id")]
    public string? AwayTeamId { get; set; }

    [JsonProperty("home_score")]
    public string? HomeScore { get; set; }

    [JsonProperty("away_score")]
    public string? AwayScore { get; set; }

    [JsonProperty("home_scorers")]
    public string? HomeScorers { get; set; }

    [JsonProperty("away_scorers")]
    public string? AwayScorers { get; set; }

    [JsonProperty("group")]
    public string? Group { get; set; }

    [JsonProperty("matchday")]
    public string? Matchday { get; set; }

    [JsonProperty("local_date")]
    public string? LocalDate { get; set; }

    [JsonProperty("persian_date")]
    public string? PersianDate { get; set; }

    [JsonProperty("stadium_id")]
    public string? StadiumId { get; set; }

    public string? Finished { get; set; }

    [JsonProperty("time_elapsed")]
    public string? TimeElapsed { get; set; }

    public string Type { get; set; }

    [JsonProperty("home_team_name_en")]
    public string? HomeTeamNameEn { get; set; }

    [JsonProperty("home_team_name_fa")]
    public string? HomeTeamNameFa { get; set; }

    [JsonProperty("away_team_name_en")]
    public string AwayTeamNameEn { get; set; }

    [JsonProperty("away_team_name_fa")]
    public string? AwayTeamNameFa { get; set; }
}
