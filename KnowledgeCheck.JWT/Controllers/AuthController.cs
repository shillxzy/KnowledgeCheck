using KnowledgeCheck.BLL.DTOs.Auth;
using KnowledgeCheck.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeCheck.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var result = await _authService.Login(request);
        if (result == null)
            return Unauthorized("Invalid credentials");

        return Ok(result);
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
    {
        var registered = await _authService.RegisterAsync(request.UserName!, request.Email!, request.Password!);
        if (!registered)
            return BadRequest("Registration failed");

        return Ok("User registered successfully");
    }

    [HttpPost("refresh-token")]
    [Authorize]
    public async Task<IActionResult> RefreshToken()
    {
        var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        var tokenResult = await _authService.RefreshTokenAsync(ip);

        return Ok(tokenResult);
    }

    [HttpPost("confirm-email")]
    [AllowAnonymous]
    public async Task<IActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string token)
    {
        var confirmed = await _authService.ConfirmEmailAsync(userId, token);
        if (!confirmed)
            return BadRequest("Email confirmation failed");

        return Ok("Email confirmed");
    }

    [HttpPost("forgot-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestDto request)
    {
        var result = await _authService.ForgotPasswordAsync(request.Email!);
        if (!result)
            return BadRequest("Failed to send password reset link");

        return Ok("Reset link sent");
    }

    [HttpPost("reset-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDto request)
    {
        var result = await _authService.ResetPasswordAsync(request.Email!, request.Token!, request.NewPassword!);
        if (!result)
            return BadRequest("Reset password failed");

        return Ok("Password reset successfully");
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _authService.LogoutAsync();
        return Ok("Logged out");
    }
}
