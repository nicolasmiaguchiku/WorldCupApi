using WorldCup.CrossCutting.Extensions;
using WorldCup.CrossCutting.Models;

var builder = WebApplication.CreateBuilder(args);

string? enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{enviroment}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

Settings applicationSettings = builder.Configuration.GetApplicationSettings(builder.Environment);

builder.Services
    .AddServices()
    .AddMediator()
    .AddApiSpecification()
    .AddHttpClients(applicationSettings.WorldCupSettings)
    .AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.UseSpecification();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();