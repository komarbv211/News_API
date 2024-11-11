using Core.DTOs;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(string id);
        Task CreateUserAsync(UserDto dto);
        Task UpdateUserAsync(string id, UserDto dto);
        Task DeleteUserAsync(string id);
    }
}
