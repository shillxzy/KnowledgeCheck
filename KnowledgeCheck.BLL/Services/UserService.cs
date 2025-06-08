using KnowledgeCheck.BLL.DTOs.User;
using KnowledgeCheck.BLL.Exceptions;
using KnowledgeCheck.BLL.Services.Interfaces;
using KnowledgeCheck.DAL.Entities;
using KnowledgeCheck.DAL.Repositories.Interfaces;
using Mapster;

namespace KnowledgeCheck.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var users = await _userRepository.GetAllAsync(cancellationToken);
            return users.Adapt<IEnumerable<UserResponseDto>>();
        }

        public async Task<UserResponseDto> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id)
                       ?? throw new UserNotFoundException();
            return user.Adapt<UserResponseDto>();
        }

        public async Task<UserResponseDto> GetByUsernameAsync(string username)
        {
            var user = await _userRepository.GetByUsernameAsync(username)
                       ?? throw new UserNotFoundException();
            return user.Adapt<UserResponseDto>();
        }

        public async Task<UserResponseDto> CreateUserAsync(UserCreateDto dto)
        {
            // Тут можна додати логіку перевірки унікальності, хешування пароля тощо
            var existingUser = await _userRepository.GetByUsernameAsync(dto.UserName);
            if (existingUser != null)
                throw new UserAlreadyExistsException();

            var user = dto.Adapt<User>();
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return user.Adapt<UserResponseDto>();
        }

        public async Task UpdateUserAsync(int id, UserUpdateDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id)
                       ?? throw new UserNotFoundException();

            dto.Adapt(user);
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id)
                       ?? throw new UserNotFoundException();

            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
