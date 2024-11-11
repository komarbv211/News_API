using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Data.Entities;

namespace Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _repository;
        private readonly IMapper _mapper;

        public CommentService(IRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByNewsIdAsync(int newsId)
        {
            var comments = await _repository.Get(
                filter: c => c.NewsId == newsId // Filter by NewsId
            );

            // Використовуємо AutoMapper для перетворення коментарів у CommentDto
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

        public async Task<CommentDto> GetCommentByIdAsync(int id)
        {
            var comment = await _repository.GetByID(id);
            if (comment == null) return null;

            // Використовуємо AutoMapper для перетворення коментаря у CommentDto
            return _mapper.Map<CommentDto>(comment);
        }

        public async Task CreateCommentAsync(CommentDto commentDto)
        {
            // Використовуємо AutoMapper для перетворення CommentDto на Comment
            var comment = _mapper.Map<Comment>(commentDto);
            await _repository.Insert(comment);
            await _repository.Save();
        }

        public async Task UpdateCommentAsync(int id, CommentDto commentDto)
        {
            var comment = await _repository.GetByID(id);
            if (comment != null)
            {
                // Оновлюємо коментар, використовуючи AutoMapper
                _mapper.Map(commentDto, comment);
                await _repository.Update(comment);
                await _repository.Save();
            }
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = await _repository.GetByID(id);
            if (comment != null)
            {
                await _repository.Delete(comment);
                await _repository.Save();
            }
        }
    }
}
