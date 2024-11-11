using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Data.Entities;

namespace Core.Services
{
    public class UserFavoriteNewsService : IUserFavoriteNewsService
    {
        private readonly IRepository<UserFavoriteNews> _repository;
        private readonly IMapper _mapper;

        public UserFavoriteNewsService(IRepository<UserFavoriteNews> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserFavoriteNewsDto>> GetByUserIdAsync(string userId)
        {
            var favorites = await _repository.Get(f => f.UserId == userId);
            return _mapper.Map<IEnumerable<UserFavoriteNewsDto>>(favorites);
        }

        public async Task AddToFavoritesAsync(UserFavoriteNewsDto dto)
        {
            var favorite = _mapper.Map<UserFavoriteNews>(dto);
            await _repository.Insert(favorite);
            await _repository.Save();
        }

        public async Task RemoveFromFavoritesAsync(string userId, int newsId)
        {
            var favorite = await _repository.Get(f => f.UserId == userId && f.NewsId == newsId);
            if (favorite != null)
            {
                await _repository.Delete(favorite);
                await _repository.Save();
            }
        }
    }
}
