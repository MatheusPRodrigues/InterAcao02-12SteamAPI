using Steam.API.Data;
using Steam.API.Repositories;
using Steam.API.Repositories.Interfaces;
using Steam.API.Services;
using Steam.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient("steam-search", client =>
    client.BaseAddress = new Uri("https://store.steampowered.com/api/storesearch/")
);

builder.Services.AddHttpClient("steam-review", client =>
    client.BaseAddress = new Uri("https://store.steampowered.com/appreviews/")
);

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<ISteamService, SteamService>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
