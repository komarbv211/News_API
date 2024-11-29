using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Core.Specifications;
using Data.Entities;

namespace Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IRepository<Author> authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            // Отримуємо всіх авторів з репозиторію
            var authors = await _authorRepository.Get(
                includeProperties: "News" // Включаємо пов'язані новини
            );

            // Використовуємо AutoMapper для перетворення колекції Author в AuthorDto
            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int id)
        {
            var author = await _authorRepository.GetByID(id);
            if (author == null) return null;

            // Перетворюємо отриманого автора в AuthorDto за допомогою AutoMapper
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task CreateAuthorAsync(CreateAuthorDto authorDto)
        {
            // Мапимо CreateAuthorDto на Author
            var author = _mapper.Map<Author>(authorDto);

            await _authorRepository.Insert(author);
            await _authorRepository.Save();
        }

        public async Task UpdateAuthorAsync(int id, UpdateAuthorDto authorDto)
        {
            var author = await _authorRepository.GetByID(id);
            if (author != null)
            {
                // Мапимо UpdateAuthorDto на Author і оновлюємо його
                _mapper.Map(authorDto, author);
                await _authorRepository.Update(author);
                await _authorRepository.Save();
            }
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _authorRepository.GetByID(id);
            if (author != null)
            {
                await _authorRepository.Delete(author);
                await _authorRepository.Save();
            }
        }
        public async Task<int?> GetAuthorIdByUserIdAsync(string userId)
        {
            // Використовуємо специфікацію для фільтрації авторів по userId
            var authorSpec = new AuthorSpecification(userId: userId);

            // Отримуємо список авторів за специфікацією
            var authors = await _authorRepository.GetListBySpec(authorSpec);

            // Якщо авторів знайдено, повертаємо перший ID
            return authors.FirstOrDefault()?.Id;
        }
        public async Task<IEnumerable<AuthorDto>> FilterAuthorsAsync(string? fullName, string? userId, bool includeNews)
        {
            // Створюємо специфікацію для фільтрації авторів
            var spec = new AuthorSpecification(fullName, userId, includeNews);

            // Отримуємо авторів, застосовуючи специфікацію
            var authors = await _authorRepository.GetListBySpec(spec);

            // Перетворюємо отримані дані в DTO
            var authorDtos = authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                FullName = a.FullName,
                Pseudonym = a.Pseudonym,
                UserId = a.UserId,
                News = _mapper.Map<ICollection<NewsDto>>(a.News)
            });

            return authorDtos;
        }

    }
}
