using Core.DTOs;

namespace Core.Interfaces
{
    public interface IStatisticsService
    {
        Task<IEnumerable<StatisticsDto>> GetAllAsync();
        Task<StatisticsDto> GetByIdAsync(int id);
        Task CreateAsync(StatisticsDto dto);
    }
}
