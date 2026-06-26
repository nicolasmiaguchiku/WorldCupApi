using WorldCup.CrossCutting.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiSpecification()
    .AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();