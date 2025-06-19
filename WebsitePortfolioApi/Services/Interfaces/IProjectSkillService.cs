using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;

namespace WebsitePortfolioApi.Services.Interfaces
{
    public interface IProjectSkillService
    {
        Task<List<ProjectSkill>?> GetProjectSkills();
    }
}
