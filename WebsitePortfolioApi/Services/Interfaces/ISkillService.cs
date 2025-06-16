using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;

namespace WebsitePortfolioApi.Services.Interfaces
{
    public interface ISkillService
    {
        Task<Skill?> CreateSkillAsync(SkillRequestDto request);
        Task<List<Skill>?> GetSkillsAsync();
        Task<Skill?> GetSkillByIdAsync(int id);
        Task<Skill?> UpdateSkillAsync(int id, SkillRequestDto request);
        Task<Skill?> DeleteSkillAsync(int id);
    }
}
