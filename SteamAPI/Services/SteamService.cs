using Steam.API.Repositories.Interfaces;
using Steam.API.Services.Interfaces;
using Steam.Models;
using Steam.Models.ResponseAPI;
using Steam.Models.ResponseAPIReviews;
using System.Text.Json;

namespace Steam.API.Services
{
    public class SteamService : ISteamService
    {
        private readonly IHttpClientFactory _factory;
        private readonly JsonSerializerOptions _options = 
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true};

        private readonly IGameRepository _gameRepository;
        private readonly IReviewRepository _reviewRepository;

        public SteamService(
            IHttpClientFactory factory,
            IGameRepository gameRepository,
            IReviewRepository reviewRepository    
        )
        {
            _factory = factory;
            _gameRepository = gameRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task<List<Game>> GetAllGamesInDBAsync()
        {
            return await _gameRepository.GetAllGamesInDBAsync();
        }

        public async Task<ResponseGame?> GetGamesAsync(string gameName)
        {
            // l - Languague
            // cc - Country Code
            const string queryParameters = "&l=portuguese&cc=BR";

            var formatedParameter = gameName
                .Replace("-", "")
                .Replace(".", "")
                .Replace(" ", "")
                .Trim();
            Console.WriteLine(formatedParameter.Trim());
            var parameters = $"?term={formatedParameter}{queryParameters}";

            var responseAPI = await _factory.CreateClient("steam-search").GetAsync(parameters);

            var gamesJson = await responseAPI.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<ResponseGame>(gamesJson, _options);

            if (response is not null)
                await _gameRepository.AddGamesAsync(response.Items);

            return response;
        }

        public async Task<ResponseReview?> GetReviewAsync(int gameId)
        {
            const string queryParameters = "&?json=1&language=all&day_range=30";

            var parameters = $"{gameId}{queryParameters}";

            var responseAPI = await _factory.CreateClient("steam-review").GetAsync(parameters);

            var reviewJson = await responseAPI.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<ResponseReview>(reviewJson, _options);

            if (response is not null)
            {
                var review = new ReviewPersistence(gameId, response.QuerySummary);
                await _reviewRepository.AddReviewsAsync(review);
            }

            return response;
        }
    }
}
