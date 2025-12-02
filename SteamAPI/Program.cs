using Steam.API.Data;
using Steam.API.Repositories;
using Steam.API.Repositories.Interfaces;
using Steam.API.Services;
using Steam.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient<ISteamService, SteamService>(client =>
    client.BaseAddress = new Uri("https://store.steampowered.com/api/storesearch/")
);

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IGameRepository, GameRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
