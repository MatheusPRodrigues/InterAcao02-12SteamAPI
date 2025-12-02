using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Steam.API.Services.Interfaces;
using Steam.Models.ResponseAPIReviews;

namespace Steam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private ISteamService _steamService;
        private ILogger<GameController> _logger;

        public ReviewController(ISteamService steamService, ILogger<GameController> logger)
        {
            _steamService = steamService;
            _logger = logger;
        }

        [HttpGet("{gameId}")]
        public async Task<ActionResult<ResponseReview>> GetReviewsAsync(int gameId)
        {
            try
            {
                var result = await _steamService.GetReviewAsync(gameId);
                if (result == null)
                    return NotFound();

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
