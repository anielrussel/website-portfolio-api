using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;

namespace WebsitePortfolioApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(LoginRequestDto request);
        Task<LoginResponseDto?> LoginAsync(LoginRequestDto request);
        Task<LoginResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);
    }
}
