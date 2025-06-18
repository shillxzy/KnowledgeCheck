using KnowledgeCheck.BLL.DTOs.User;
using KnowledgeCheck.BLL.Exceptions;
using KnowledgeCheck.BLL.Services.Interfaces;
using KnowledgeCheck.DAL.Entities;
using KnowledgeCheck.DAL.Repositories.Interfaces;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeCheck.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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



        public async Task<IEnumerable<UserResponseDto>> GetFilteredAsync(UserFilterDto filter)
        {
            var query = _userRepository.GetAllQueryable();

            if (!string.IsNullOrEmpty(filter.Role))
                query = query.Where(u => u.Role == filter.Role);

            if (!string.IsNullOrEmpty(filter.UserName))
                query = query.Where(u => u.UserName.Contains(filter.UserName));

            if (!string.IsNullOrEmpty(filter.Email))
                query = query.Where(u => u.Email.Contains(filter.Email));

            if (!string.IsNullOrEmpty(filter.SortBy))
            {
                bool descending = string.Equals(filter.SortOrder, "desc", StringComparison.OrdinalIgnoreCase);

                // Підтримуємо кілька полів, робимо динамічно
                query = filter.SortBy.ToLower() switch
                {
                    "username" => descending ? query.OrderByDescending(u => u.UserName) : query.OrderBy(u => u.UserName),
                    "email" => descending ? query.OrderByDescending(u => u.Email) : query.OrderBy(u => u.Email),
                    "role" => descending ? query.OrderByDescending(u => u.Role) : query.OrderBy(u => u.Role),
                    _ => query
                };
            }

            var users = await query.ToListAsync();

            return _mapper.Map<IEnumerable<UserResponseDto>>(users);
        }


    }
}
