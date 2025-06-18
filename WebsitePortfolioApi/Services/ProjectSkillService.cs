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

        public async Task<List<ProjectSkill>> CreateAndDeleteProjectSkillAsync(ProjectSkillRequestDto request)
        {
            var projectSkills = new List<ProjectSkill>();

            if (request.AddedSkillIds.Any())
            {
               var existing = await _context.ProjectSkills
              .Where(ps => ps.ProjectId == request.ProjectId && request.AddedSkillIds.Contains(ps.SkillId))
              .Select(ps => ps.SkillId)
              .ToListAsync();

                var newSkills = request.AddedSkillIds
                    .Except(existing)
                    .Select(skillId => new ProjectSkill
                    {
                        ProjectId = request.ProjectId,
                        SkillId = skillId
                    }).ToList();

                _context.ProjectSkills.AddRange(newSkills);
                
            }
          
            if (request.DeletedSkillIds.Any())
            {
                var skillsToDelete = await _context.ProjectSkills
                    .Where(ps => ps.ProjectId == request.ProjectId && request.DeletedSkillIds.Contains(ps.SkillId))
                    .ToListAsync();

                _context.ProjectSkills.RemoveRange(skillsToDelete);
            }

            await _context.SaveChangesAsync();

            return await Task.FromResult(projectSkills);
        }

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
