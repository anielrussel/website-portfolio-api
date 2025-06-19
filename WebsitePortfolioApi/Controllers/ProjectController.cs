using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;
using WebsitePortfolioApi.Services.Interfaces;

namespace WebsitePortfolioApi.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController(IProjectService projectService) : ControllerBase
    {
        protected readonly IProjectService _projectService = projectService;

        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectRequestDto request)
        {
            var result = await _projectService.CreateProjectAsync(request);
           
            return result.ToActionResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var result = await _projectService.GetProjectsAsync();

            return result.ToActionResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var result = await _projectService.GetProjectByIdAsync(id);
           
            return result.ToActionResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, ProjectRequestDto request)
        {
            var result = await _projectService.UpdateProjectAsync(id, request);
          
            return result.ToActionResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _projectService.DeleteProjectAsync(id);
           
            return result.ToActionResult();
        }

        [HttpPost("skills")]
        public async Task<IActionResult> AddDeleteSkills(ProjectSkillRequestDto request)
        {
            var result = await _projectService.AddDeleteSkillsAsync(request);
           
            return result.ToActionResult();
        }
    }
}
