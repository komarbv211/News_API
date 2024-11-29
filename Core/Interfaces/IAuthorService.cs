using Core.DTOs;

namespace Core.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
        Task<AuthorDto> GetAuthorByIdAsync(int id);
        Task CreateAuthorAsync(CreateAuthorDto authorDto);
        Task UpdateAuthorAsync(int id, UpdateAuthorDto authorDto);
        Task DeleteAuthorAsync(int id);
        Task<int?> GetAuthorIdByUserIdAsync(string userId);
        Task<IEnumerable<AuthorDto>> FilterAuthorsAsync(string? fullName, string? userId, bool includeNews);
    }

}
