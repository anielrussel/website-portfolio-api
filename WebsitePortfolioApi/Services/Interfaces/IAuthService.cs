using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;

namespace WebsitePortfolioApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(LoginRequest request);
        Task<LoginResponseDto?> LoginAsync(LoginRequest request);
        Task<LoginResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);
    }
}
