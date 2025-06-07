using KnowledgeCheck.BLL.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> GetByIdAsync(int id);
        Task<UserResponseDto> GetByUsernameAsync(string username);
        Task<UserResponseDto> CreateUserAsync(UserCreateDto dto);
        Task UpdateUserAsync(int id, UserUpdateDto dto);
        Task DeleteUserAsync(int id);
    }
}
