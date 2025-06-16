using Microsoft.EntityFrameworkCore;
using WebsitePortfolioApi.Data;
using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;
using WebsitePortfolioApi.Services.Interfaces;

namespace WebsitePortfolioApi.Services
{
    public class SkillService(WebsitePortfolioDbContext context) : ISkillService
    {
        protected readonly WebsitePortfolioDbContext _context = context;

        public async Task<Skill?> CreateSkillAsync(SkillRequestDto request)
        {
            var skill = new Skill
            {
                Name = request.Name,
                Icon = request.Icon,
                Category = request.Category,
                ProfileId = request.ProfileId
            };

            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();

            return skill;
        }

        public async Task<Skill?> GetSkillByIdAsync(int id)
        {
            var existingSkill = await _context.Skills.FindAsync(id);
            if (existingSkill is null)
            {
                return null;
            }

            return existingSkill;
        }

        public async Task<List<Skill>?> GetSkillsAsync()
        {
            var skills = await _context.Skills.ToListAsync();

            return skills.Count > 0 ? skills : [];
        }

        public async Task<Skill?> UpdateSkillAsync(int id, SkillRequestDto request)
        {
            var existingSkill = await _context.Skills.FindAsync(id);
            if (existingSkill is null)
            {
                return null;
            }

            existingSkill.Name = request.Name;
            existingSkill.Icon = request.Icon;
            existingSkill.Category = request.Category;
            existingSkill.ProfileId = request.ProfileId;

            _context.Skills.Update(existingSkill);
            await _context.SaveChangesAsync();

            return existingSkill;
        }
        public async Task<Skill?> DeleteSkillAsync(int id)
        {
            var existingSkill = await _context.Skills.FindAsync(id);
            if (existingSkill is null)
            {
                return null;
            }

            _context.Skills.Remove(existingSkill);
            await _context.SaveChangesAsync();

            return existingSkill;
        }
    }
}
