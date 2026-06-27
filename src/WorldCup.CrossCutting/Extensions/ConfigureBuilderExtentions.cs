using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using WorldCup.CrossCutting.Models;

namespace WorldCup.CrossCutting.Extensions
{
    public static class ConfigureBuilderExtentions
    {
        public static Settings GetApplicationSettings(this IConfiguration configuration, IHostEnvironment env)
        {
            Settings settings = configuration.GetSection("Settings").Get<Settings>()!;

            if (!env.IsDevelopment())
            {
                settings.WorldCupSettings.WorldCupUrl = GetOrDefault("WORLD_CUP_URL", settings.WorldCupSettings.WorldCupUrl);
            }

            return settings;
        }

        private static string GetOrDefault(string key, string? fallback)
        {
            string? value = Environment.GetEnvironmentVariable(key);
            return string.IsNullOrEmpty(value) ? fallback ?? "" : value;
        }
    }
}