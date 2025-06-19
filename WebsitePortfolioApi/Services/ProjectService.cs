using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsitePortfolioApi.Data;
using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;
using WebsitePortfolioApi.Services.Interfaces;

namespace WebsitePortfolioApi.Services
{
    public class ProjectService(WebsitePortfolioDbContext context) : IProjectService
    {
        protected readonly WebsitePortfolioDbContext _context = context;

        public async Task<ApiResponse<Project>> CreateProjectAsync(ProjectRequestDto request)
        {
           var project = new Project
           {
               Name = request.Name,
               Description = request.Description,
               Image = request.Image,
               Url = request.Url,
               RepoLink = request.RepoLink,
               ProfileId = request.ProfileId
           };

            _context.Projects.Add(project);
            await  _context.SaveChangesAsync();

            return ApiResponse<Project>.Created(project);
        }

        public async Task<ApiResponse<Project>> GetProjectByIdAsync(int id)
        {
            var existingProject = await _context.Projects.FindAsync(id);
            if (existingProject == null)
            {
                return ApiResponse<Project>.NotFound("Project not found.");
            }

            return ApiResponse<Project>.SuccessResponse(existingProject);
        }

        public async Task<ApiResponse<List<Project>>> GetProjectsAsync()
        {
            var projects = await _context.Projects
                .Include(p => p.ProjectSkills)
                .ToListAsync();
            if (projects is null || !projects.Any())
            {
                return ApiResponse<List<Project>>.NotFound("No projects found.");
            }
            return ApiResponse<List<Project>>.SuccessResponse(projects);
        }

        public async Task<ApiResponse<Project>> UpdateProjectAsync(int id, ProjectRequestDto request)
        {
            var existingProject = await _context.Projects.FindAsync(id);
            if (existingProject == null)
            {
                return ApiResponse<Project>.NotFound("Project not found.");
            }

            existingProject.Name = request.Name;
            existingProject.Description = request.Description;
            existingProject.Image = request.Image;
            existingProject.Url = request.Url;
            existingProject.RepoLink = request.RepoLink;
            existingProject.ProfileId = request.ProfileId;

            _context.Projects.Update(existingProject);
            await _context.SaveChangesAsync();

            return ApiResponse<Project>.SuccessResponse(existingProject, "Project updated successfully");
        }
        public async Task<ApiResponse<Project>> DeleteProjectAsync(int id)
        {
            var existingProject = await _context.Projects.FindAsync(id);
            if (existingProject == null)
            {
                return ApiResponse<Project>.NotFound("Project not found.");
            }

            _context.Projects.Remove(existingProject);
            await _context.SaveChangesAsync();

            return ApiResponse<Project>.SuccessResponse(existingProject, "Project deleted successfully");
        }

        public async Task<ApiResponse<ProjectSkillRequestDto>> AddDeleteSkillsAsync(ProjectSkillRequestDto request)
        {
            var existingProject = await _context.Projects.FindAsync(request.ProjectId);

            if (existingProject == null)
            {
                return ApiResponse<ProjectSkillRequestDto>.NotFound("Project not found.");
            }


            if (request.AddedSkillIds.Any())
            {
                var existingSkills = await _context.ProjectSkills
                    .Where(ps => ps.ProjectId == request.ProjectId && request.AddedSkillIds.Contains(ps.SkillId))
                    .Select(ps => ps.SkillId)
                    .ToListAsync();
                var newSkills = request.AddedSkillIds
                    .Except(existingSkills)
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

            return ApiResponse<ProjectSkillRequestDto>.SuccessResponse(request);
        }
    }
}
