using Steam.Models.ResponseAPI;

namespace Steam.API.Repositories.Interfaces
{
    public interface IGameRepository
    {
        public Task AddGamesAsync(List<Game> gameList);
        public Task<Game> GetGameByIdAsync(int idGame);
        public Task<List<Game>> GetAllGamesInDBAsync();
    }
}
