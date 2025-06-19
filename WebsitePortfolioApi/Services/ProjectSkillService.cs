using Microsoft.EntityFrameworkCore;
using WebsitePortfolioApi.Data;
using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;
using WebsitePortfolioApi.Services.Interfaces;

namespace WebsitePortfolioApi.Services
{
    public class ProjectSkillService(WebsitePortfolioDbContext context) : IProjectSkillService
    {
        protected readonly WebsitePortfolioDbContext _context = context;

        public async Task<List<ProjectSkill>?> GetProjectSkills()
        {
            var result = await _context.ProjectSkills
                .Include(ps => ps.Project)
                .Include(ps => ps.Skill)
                .ToListAsync();

            if (result == null || !result.Any())
            {
                return new List<ProjectSkill>();
            }

            return Task.FromResult(result).Result;
        }
    }
}
