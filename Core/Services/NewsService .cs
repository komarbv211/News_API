using Ardalis.Specification;
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
        private readonly IFileService _fileService;


        public NewsService(IRepository<News> repository, IMapper mapper, IFileService fileService)
        {
            _repository = repository;
            _mapper = mapper;
            _fileService = fileService;
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

            if (createNewsDto.Images != null)
                news.Images = await _fileService.SaveProductImage(createNewsDto.Images);
            await _repository.Insert(news);
            await _repository.Save();
        }

        public async Task UpdateNewsAsync(UpdateNewsDto updateNewsDto)
        {
            var news = await _repository.GetByID(updateNewsDto.Id);

            if (news == null)
            {
                throw new KeyNotFoundException($"News with ID {updateNewsDto.Id} not found.");
            }

            string? oldImagePath = news.Images;

            _mapper.Map(updateNewsDto, news);

            if (updateNewsDto.Images != null)
            {
                news.Images = await _fileService.SaveProductImage(updateNewsDto.Images);

                if (!string.IsNullOrEmpty(oldImagePath))
                {
                    await _fileService.DeleteProductImage(oldImagePath);
                }
            }

            await _repository.Update(news);
            await _repository.Save();
        }


        public async Task DeleteNewsAsync(int id)
        {
            var news = await _repository.GetByID(id);
            if (news == null)
            {
                throw new KeyNotFoundException($"News with ID {id} not found.");
            }

            // Видаляємо файл зображення, якщо він існує
            if (!string.IsNullOrEmpty(news.Images))
            {
                await _fileService.DeleteProductImage(news.Images);
            }

            await _repository.Delete(id);
            await _repository.Save();
        }
    }
}
