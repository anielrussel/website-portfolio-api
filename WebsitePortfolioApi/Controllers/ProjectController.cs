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
        public async Task<ActionResult<Project>> CreateProject(ProjectRequestDto request)
        {
            var result = await _projectService.CreateProjectAsync(request);
            if (result is null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetProjectById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetProjects()
        {
            var result = await _projectService.GetProjectsAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
            var result = await _projectService.GetProjectByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, ProjectRequestDto request)
        {
            var result = await _projectService.UpdateProjectAsync(id, request);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            var result = await _projectService.DeleteProjectAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("skills")]
        public async Task<IActionResult> AddDeleteSkills(ProjectSkillRequestDto request)
        {
            var result = await _projectService.AddDeleteSkillsAsync(request);
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
