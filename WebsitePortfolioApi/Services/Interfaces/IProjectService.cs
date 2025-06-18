using Microsoft.AspNetCore.Mvc;
using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;

namespace WebsitePortfolioApi.Services.Interfaces
{
    public interface IProjectService
    {
        Task<Project?> CreateProjectAsync(ProjectRequestDto request);
        Task<List<Project>?> GetProjectsAsync();
        Task<Project?> GetProjectByIdAsync(int id);
        Task<Project?> UpdateProjectAsync(int id, ProjectRequestDto request);
        Task<Project?> DeleteProjectAsync(int id);
        Task<IActionResult> AddDeleteSkillsAsync(ProjectSkillRequestDto request);
    }
}
