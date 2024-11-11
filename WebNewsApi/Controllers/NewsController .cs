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

        [HttpGet("{id}")]
        public async Task<ActionResult<NewsDto>> GetNewsById(int id)
        {
            var news = await _newsService.GetNewsByIdAsync(id);
            if (news == null)
                return NotFound();

            return Ok(news);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNews([FromBody] CreateNewsDto createNewsDto)
        {
            await _newsService.CreateNewsAsync(createNewsDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateNews(int id, [FromBody] UpdateNewsDto updateNewsDto)
        {
            if (id != updateNewsDto.Id)
                return BadRequest();

            await _newsService.UpdateNewsAsync(updateNewsDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNews(int id)
        {
            await _newsService.DeleteNewsAsync(id);
            return NoContent();
        }
    }
}
