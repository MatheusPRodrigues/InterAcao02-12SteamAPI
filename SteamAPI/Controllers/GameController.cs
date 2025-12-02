using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Steam.API.Services.Interfaces;
using Steam.Models.ResponseAPI;

namespace Steam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private ISteamService _steamService;
        private ILogger<GameController> _logger;

        public GameController(ISteamService steamService, ILogger<GameController> logger)
        {
            _steamService = steamService;
            _logger = logger;
        }

        [HttpGet("{gameName}")]
        public async Task<ActionResult<ResponseGame>> GetGamesAsync(string gameName)
        {
            try
            {
                var result = await _steamService.GetGamesAsync(gameName);
                if (result is null || result.Total == 0)
                    return NotFound($"{gameName} não pode ser encontrado!");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("InDB")]
        public async Task<ActionResult<List<Game>>> GetAllGamesInDBAsync()
        {
            try
            {
                var result = await _steamService.GetAllGamesInDBAsync();
                if (result is null || result.Count() == 0)
                    return NotFound("Não há jogos cadastrados no Banco! Busque externamente!");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
