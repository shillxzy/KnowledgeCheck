﻿using KnowledgeCheck.BLL.DTOs.User;
using KnowledgeCheck.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<UserResponseDto> GetByIdAsync(int id);
        Task<UserResponseDto> GetByUsernameAsync(string username);
        Task<UserResponseDto> CreateUserAsync(UserCreateDto dto);
        Task UpdateUserAsync(int id, UserUpdateDto dto);
        Task DeleteUserAsync(int id);
        Task<IEnumerable<UserResponseDto>> GetFilteredAsync(UserFilterDto filter);

    }
}
