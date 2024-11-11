using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebNewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _service;

        public StatisticsController(IStatisticsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatisticsDto>>> GetAll()
        {
            var stats = await _service.GetAllAsync();
            return Ok(stats);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatisticsDto>> GetById(int id)
        {
            var stat = await _service.GetByIdAsync(id);
            if (stat == null)
                return NotFound();

            return Ok(stat);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] StatisticsDto dto)
        {
            await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
    }
}
