using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Data.Entities;

namespace Core.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IRepository<Statistics> _repository;
        private readonly IMapper _mapper;

        public StatisticsService(IRepository<Statistics> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StatisticsDto>> GetAllAsync()
        {
            var statistics = await _repository.GetAll();
            return _mapper.Map<IEnumerable<StatisticsDto>>(statistics);
        }

        public async Task<StatisticsDto> GetByIdAsync(int id)
        {
            var stat = await _repository.GetByID(id);
            return _mapper.Map<StatisticsDto>(stat);
        }

        public async Task CreateAsync(StatisticsDto dto)
        {
            var stat = _mapper.Map<Statistics>(dto);
            await _repository.Insert(stat);
            await _repository.Save();
        }
    }
}
