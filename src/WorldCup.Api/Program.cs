using WorldCup.CrossCutting.Extensions;
using WorldCup.CrossCutting.Models;

var builder = WebApplication.CreateBuilder(args);

var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{enviroment}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

Settings applicationSettings = builder.Configuration.GetApplicationSettings(builder.Environment);

builder.Services
    .AddApiSpecification()
    .AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.UseSpecification();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();