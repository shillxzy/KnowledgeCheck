using KnowledgeCheck.BLL.DTOs.Auth;
using KnowledgeCheck.BLL.Services.Interfaces;
using KnowledgeCheck.DAL.Entities;
using KnowledgeCheck.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthService(
            IUserRepository userRepository,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _userRepository.GetByUsernameAsync(loginRequestDto.UserName);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid username or password.");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginRequestDto.Password, false);
            if (!result.Succeeded)
                throw new UnauthorizedAccessException("Invalid username or password.");

            return new LoginResponseDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role 
            };
        }

        public async Task<RefreshTokenResponseDto> RefreshTokenAsync(string ipAddress)
        {
            return await Task.FromResult<RefreshTokenResponseDto>(null);
        }

        public async Task<bool> RegisterAsync(string username, string email, string password)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(username);
            if (existingUser != null)
                return false;

            var user = new User
            {
                UserName = username,
                Email = email,
                Role = "User"
            };

            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }

        public async Task<bool> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));
            if (user == null)
                return false;

            var result = await _userManager.ConfirmEmailAsync(user, token);
            return result.Succeeded;
        }

        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return false;

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return true;
        }

        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return false;

            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return result.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
