using MongoDB.Driver;
using Steam.API.Data;
using Steam.API.Repositories.Interfaces;
using Steam.Models;

namespace Steam.API.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IMongoCollection<ReviewPersistence> _reviewCollection;

        public ReviewRepository(AppDbContext appDbContext)
        {
            _reviewCollection = appDbContext.GetConnection()
                .GetCollection<ReviewPersistence>("Reviews");
        }

        public async Task AddReviewsAsync(ReviewPersistence review)
        {
           if (GetReviewByGameIdAsync(review.GameId).Result is null)
                await _reviewCollection.InsertOneAsync(review);
        }

        public async Task<ReviewPersistence> GetReviewByGameIdAsync(int gameId)
        {
            return await _reviewCollection.FindAsync(r => r.GameId == gameId).Result.FirstOrDefaultAsync();
        }
    }
}
