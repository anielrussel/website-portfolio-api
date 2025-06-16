using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;

namespace WebsitePortfolioApi.Services.Interfaces
{
    public interface ISocialLinkService
    {
        Task<SocialLink?> CreateSocialLinkAsync(SocialLinkRequestDto request);
        Task<List<SocialLink>?> GetSocialLinksAsync();
        Task<SocialLink?> GetSocialLinkByIdAsync(int id);
        Task<SocialLink?> UpdateSocialLinkAsync(int id, SocialLinkRequestDto request);
        Task<SocialLink?> DeleteSocialLinkAsync(int id);
    }
}
