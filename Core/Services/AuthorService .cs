using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
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
    }
}
