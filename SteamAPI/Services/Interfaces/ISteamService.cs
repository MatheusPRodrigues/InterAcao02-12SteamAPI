using Steam.Models.ResponseAPI;
using Steam.Models.ResponseAPIReviews;

namespace Steam.API.Services.Interfaces
{
    public interface ISteamService
    {
        Task<ResponseGame?> GetGamesAsync(string gameName);
        Task<List<Game>> GetAllGamesInDBAsync();
        Task<ResponseReview?> GetReviewAsync(int gameId);
    }
}
