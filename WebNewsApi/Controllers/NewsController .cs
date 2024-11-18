using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebNewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<NewsDto>>> GetAllNews()
        {
            var newsList = await _newsService.GetAllNewsAsync();
            return Ok(newsList);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<NewsDto>> GetNewsById(int id)
        {
            var news = await _newsService.GetNewsByIdAsync(id);
            if (news == null)
                return NotFound();

            return Ok(news);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateNews([FromForm] CreateNewsDto createNewsDto)
        {
            await _newsService.CreateNewsAsync(createNewsDto);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateNews([FromForm] UpdateNewsDto updateNewsDto)
        {
            await _newsService.UpdateNewsAsync(updateNewsDto);
            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteNews(int id)
        {
            await _newsService.DeleteNewsAsync(id);
            return NoContent();
        }
    }
}
