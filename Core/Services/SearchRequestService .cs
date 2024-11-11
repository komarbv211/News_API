using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Data.Entities;

namespace Core.Services
{
    public class SearchRequestService : ISearchRequestService
    {
        private readonly IRepository<SearchRequest> _repository;
        private readonly IMapper _mapper;

        public SearchRequestService(IRepository<SearchRequest> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SearchRequestDto>> GetAllAsync()
        {
            var requests = await _repository.GetAll();
            return _mapper.Map<IEnumerable<SearchRequestDto>>(requests);
        }

        public async Task<SearchRequestDto> GetByIdAsync(int id)
        {
            var request = await _repository.GetByID(id);
            return _mapper.Map<SearchRequestDto>(request);
        }

        public async Task CreateAsync(SearchRequestDto dto)
        {
            var request = _mapper.Map<SearchRequest>(dto);
            await _repository.Insert(request);
            await _repository.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.Delete(id);
            await _repository.Save();
        }
    }
}
