﻿using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebNewsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        [HttpGet("GetBy{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound("Author not found!");
            }
            return Ok(author);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDto createAuthorDto)
        {
            await _authorService.CreateAuthorAsync(createAuthorDto);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorDto updateAuthorDto, int Id)
        {
            await _authorService.UpdateAuthorAsync(Id,updateAuthorDto);
            return NoContent();
        }

        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound("Author not found!");
            }

            await _authorService.DeleteAuthorAsync(id);
            return NoContent();
        }

        [HttpGet("GetByUserId/{userId}")]
        public async Task<IActionResult> GetAuthorByUserId(string userId)
        {
            var authors = await _authorService.GetAuthorIdByUserIdAsync(userId);
            if (authors == null)
            {
                return NotFound("No authors found for this user.");
            }
            return Ok(authors);
        }

        [HttpGet("Filter")]
        public async Task<IActionResult> FilterAuthors(
            [FromQuery] string? fullName = null,
            [FromQuery] string? userId = null,
            [FromQuery] bool includeNews = false)
        {
            var authors = await _authorService.FilterAuthorsAsync(fullName, userId, includeNews);
            return Ok(authors);
        }
    }
}
