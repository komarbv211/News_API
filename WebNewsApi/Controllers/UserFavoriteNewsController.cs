using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebNewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFavoriteNewsController : ControllerBase
    {
        private readonly IUserFavoriteNewsService _service;

        public UserFavoriteNewsController(IUserFavoriteNewsService service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<UserFavoriteNewsDto>>> GetByUserId(string userId)
        {
            var favorites = await _service.GetByUserIdAsync(userId);
            return Ok(favorites);
        }

        [HttpPost]
        public async Task<ActionResult> AddToFavorites([FromBody] UserFavoriteNewsDto dto)
        {
            await _service.AddToFavoritesAsync(dto);
            return CreatedAtAction(nameof(GetByUserId), new { userId = dto.UserId }, dto);
        }

        [HttpDelete("{userId}/{newsId}")]
        public async Task<ActionResult> RemoveFromFavorites(string userId, int newsId)
        {
            await _service.RemoveFromFavoritesAsync(userId, newsId);
            return NoContent();
        }
    }
}
