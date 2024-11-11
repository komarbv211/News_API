using Core.DTOs;

namespace Core.Interfaces
{
    public interface IUserFavoriteNewsService
    {
        Task<IEnumerable<UserFavoriteNewsDto>> GetByUserIdAsync(string userId);
        Task AddToFavoritesAsync(UserFavoriteNewsDto dto);
        Task RemoveFromFavoritesAsync(string userId, int newsId);
    }
}
