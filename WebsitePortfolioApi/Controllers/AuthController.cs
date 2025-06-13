using Microsoft.AspNetCore.Mvc;
using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;
using WebsitePortfolioApi.Services.Interfaces;

namespace WebsitePortfolioApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        protected readonly IAuthService _authService = authService;

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(LoginRequestDto request)
        {
            var user = await _authService.RegisterAsync(request);

            if (user is null)
            {
                return BadRequest("Username is already taken");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto request)
        {
            var result = await _authService.LoginAsync(request);

            if (result is null)
            {
                return BadRequest("Invalid username or password");
            }

            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<LoginResponseDto>> RefreshToken(RefreshTokenRequestDto request)
        {
            var result = await _authService.RefreshTokensAsync(request);

            if (result is null || result.Token is null || result.RefreshToken is null)
            {
                return Unauthorized("Invalid or expired refresh token");
            }

            return result;
        }
    }
}
