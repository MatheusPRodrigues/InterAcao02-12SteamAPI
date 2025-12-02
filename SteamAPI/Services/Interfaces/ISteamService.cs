using Steam.Models.ResponseAPI;

namespace Steam.API.Services.Interfaces
{
    public interface ISteamService
    {
        Task<Response?> GetGamesAsync(string gameName);
    }
}
