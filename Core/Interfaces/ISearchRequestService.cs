using Core.DTOs;

namespace Core.Interfaces
{
    public interface ISearchRequestService
    {
        Task<IEnumerable<SearchRequestDto>> GetAllAsync();
        Task<SearchRequestDto> GetByIdAsync(int id);
        Task CreateAsync(SearchRequestDto dto);
        Task DeleteAsync(int id);
    }
}
