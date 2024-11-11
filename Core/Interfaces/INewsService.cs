using Core.DTOs;

namespace Core.Interfaces
{
    public interface INewsService
    {
        Task<IEnumerable<NewsDto>> GetAllNewsAsync();
        Task<NewsDto?> GetNewsByIdAsync(int id);
        Task CreateNewsAsync(CreateNewsDto newsDto);
        Task UpdateNewsAsync(UpdateNewsDto newsDto);
        Task DeleteNewsAsync(int id);
    }

}
