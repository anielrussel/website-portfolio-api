using Microsoft.AspNetCore.Mvc;
using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;
using WebsitePortfolioApi.Services.Interfaces;

namespace WebsitePortfolioApi.Controllers
{
    [Route("api/project-skill")]
    [ApiController]
    public class ProjectSkillController(IProjectSkillService projectSkillService) : ControllerBase
    {
        protected readonly IProjectSkillService _projectSkillService = projectSkillService;

        [HttpGet]
        public async Task<ActionResult<List<ProjectSkill>>> GetProjectSkills()
        {
            var result = await _projectSkillService.GetProjectSkills();
           
            return Ok(result);
        }
    }
}
