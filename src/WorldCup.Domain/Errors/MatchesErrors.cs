using WorldCup.Domain.Models;

namespace WorldCup.Domain.Errors
{
    public static class MatchesErrors
    {
        public static string TechnicalMessage { get; set; } = string.Empty;

        public static Error GetMatchesError => new(
            "Matches.AllMatchesError",
            $"An Error occurred while trying get all matches: {TechnicalMessage}"
            );

        public static void SetTechnicalMessage(string technicalMessage)
        {
            TechnicalMessage = technicalMessage;
        }
    }
}