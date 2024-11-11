using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Data.Entities;

namespace Core.Services
{
    public class NewsService : INewsService
    {
        private readonly IRepository<News> _repository;
        private readonly IMapper _mapper;

        public NewsService(IRepository<News> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NewsDto>> GetAllNewsAsync()
        {
            var newsList = await _repository.GetAll();

            // Використовуємо AutoMapper для перетворення новин у NewsDto
            return _mapper.Map<IEnumerable<NewsDto>>(newsList);
        }

        public async Task<NewsDto?> GetNewsByIdAsync(int id)
        {
            var news = await _repository.GetByID(id);
            if (news == null)
                return null;

            // Використовуємо AutoMapper для перетворення новини у NewsDto
            return _mapper.Map<NewsDto>(news);
        }

        public async Task CreateNewsAsync(CreateNewsDto createNewsDto)
        {
            // Використовуємо AutoMapper для перетворення CreateNewsDto на News
            var news = _mapper.Map<News>(createNewsDto);
            await _repository.Insert(news);
            await _repository.Save();
        }

        public async Task UpdateNewsAsync(UpdateNewsDto updateNewsDto)
        {
            var news = await _repository.GetByID(updateNewsDto.Id);
            if (news != null)
            {
                // Оновлюємо новину, використовуючи AutoMapper
                _mapper.Map(updateNewsDto, news);
                await _repository.Update(news);
                await _repository.Save();
            }
        }

        public async Task DeleteNewsAsync(int id)
        {
            await _repository.Delete(id);
            await _repository.Save();
        }
    }
}
