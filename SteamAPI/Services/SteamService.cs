using Steam.API.Repositories.Interfaces;
using Steam.API.Services.Interfaces;
using Steam.Models.ResponseAPI;
using System.Text.Json;

namespace Steam.API.Services
{
    public class SteamService : ISteamService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options = 
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true};

        private readonly IGameRepository _gameRepository;

        public SteamService(HttpClient httpClient, IGameRepository gameRepository)
        {
            _httpClient = httpClient;
            _gameRepository = gameRepository;
        }

        public async Task<Response?> GetGamesAsync(string gameName)
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

            var responseAPI = await _httpClient.GetAsync(parameters);

            var gamesJson = await responseAPI.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<Response>(gamesJson, _options);

            if (response is not null)
                await _gameRepository.AddGamesAsync(response.Items);

            return response;
        }
    }
}
