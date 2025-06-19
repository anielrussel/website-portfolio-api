using Microsoft.AspNetCore.Mvc;
using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;

namespace WebsitePortfolioApi.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ApiResponse<Project>> CreateProjectAsync(ProjectRequestDto request);
        Task<ApiResponse<List<Project>>> GetProjectsAsync();
        Task<ApiResponse<Project>> GetProjectByIdAsync(int id);
        Task<ApiResponse<Project>> UpdateProjectAsync(int id, ProjectRequestDto request);
        Task<ApiResponse<Project>> DeleteProjectAsync(int id);
        Task<ApiResponse<ProjectSkillRequestDto>> AddDeleteSkillsAsync(ProjectSkillRequestDto request);
    }
}
