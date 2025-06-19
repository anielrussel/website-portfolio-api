using Microsoft.AspNetCore.Mvc;
using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;

namespace WebsitePortfolioApi.Services.Interfaces
{
    public interface IProfileService
    {
        Task<ApiResponse<Profile>> CreateProfileAsync(ProfileRequestDto request);
        Task<ApiResponse<List<Profile>>> GetProfilesAsync();
        Task<ApiResponse<Profile>> GetProfileByIdAsync(int id);
        Task<ApiResponse<Profile>> UpdateProfileAsync(int id, ProfileRequestDto request);
        Task<ApiResponse<Profile>> DeleteProfileAsync(int id);
        Task<ApiResponse<ProfileSkillRequestDto>> AddDeleteSkillsAsync(ProfileSkillRequestDto request);
    }
}
