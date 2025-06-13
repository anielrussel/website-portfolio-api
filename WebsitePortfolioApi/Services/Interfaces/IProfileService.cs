using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;

namespace WebsitePortfolioApi.Services.Interfaces
{
    public interface IProfileService
    {
        Task<List<Profile?>> GetProfilesAsync();
        Task<Profile?> GetProfileByIdAsync(int id);
        Task<Profile?> CreateProfileAsync(ProfileRequestDto request);
        Task<Profile?> UpdateProfileAsync(int id, ProfileRequestDto request);
        Task<Profile?> DeleteProfileAsync(int id);
    }
}
