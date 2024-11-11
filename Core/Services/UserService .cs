using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Data.Entities;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAll();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetByIdAsync(string id)
        {
            var user = await _repository.GetByID(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task CreateUserAsync(UserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            await _repository.Insert(user);
            await _repository.Save();
        }

        public async Task UpdateUserAsync(string id, UserDto dto)
        {
            var user = await _repository.GetByID(id);
            if (user != null)
            {
                _mapper.Map(dto, user);
                await _repository.Update(user);
                await _repository.Save();
            }
        }

        public async Task DeleteUserAsync(string id)
        {
            await _repository.Delete(id);
            await _repository.Save();
        }
    }
}
