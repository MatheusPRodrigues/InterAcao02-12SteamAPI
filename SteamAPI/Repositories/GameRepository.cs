using MongoDB.Driver;
using Steam.API.Data;
using Steam.API.Repositories.Interfaces;
using Steam.Models.ResponseAPI;

namespace Steam.API.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly IMongoCollection<Game> _gameCollection;

        public GameRepository(AppDbContext appDbContext)
        {
            _gameCollection = appDbContext.GetConnection()
                .GetCollection<Game>("Games");
        }

        public async Task AddGamesAsync(List<Game> gameList)
        {
            foreach (var g in gameList)
            {
                if (GetGameByIdAsync(g.Id).Result is null)
                    await _gameCollection.InsertOneAsync(g);
            }
        }

        public async Task<List<Game>> GetAllGamesInDBAsync()
        {
            return await _gameCollection.FindAsync(g => true).Result.ToListAsync();
        }

        public async Task<Game> GetGameByIdAsync(int idGame)
        {
            return await _gameCollection.FindAsync(g => g.Id == idGame).Result.FirstOrDefaultAsync();
        }
    }
}
