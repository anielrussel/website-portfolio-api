using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;

namespace WebsitePortfolioApi.Services.Interfaces
{
    public interface IProjectSkillService
    {
        Task<List<ProjectSkill>> CreateAndDeleteProjectSkillAsync(ProjectSkillRequestDto request);
        Task<List<ProjectSkill>?> GetProjectSkills();
    }
}
