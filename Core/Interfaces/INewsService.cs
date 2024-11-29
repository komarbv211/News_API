using Ardalis.Specification;
using Core.DTOs;
using Data.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface INewsService
    {
        Task<IEnumerable<NewsDto>> GetAllNewsAsync();
        Task<NewsDto?> GetNewsByIdAsync(int id);
        Task CreateNewsAsync(CreateNewsDto newsDto);
        Task UpdateNewsAsync(UpdateNewsDto newsDto);
        Task DeleteNewsAsync(int id);
        Task<IEnumerable<NewsDto>> GetNewsBySpecificationAsync(ISpecification<News> specification); 
    }

}
