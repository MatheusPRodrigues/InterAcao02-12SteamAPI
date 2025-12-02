using Steam.Models;
using Steam.Models.ResponseAPI;

namespace Steam.API.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        public Task AddReviewsAsync(ReviewPersistence review);
        public Task<ReviewPersistence> GetReviewByGameIdAsync(int gameId);
    }
}
