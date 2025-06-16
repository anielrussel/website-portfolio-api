using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;
using WebsitePortfolioApi.Services.Interfaces;

namespace WebsitePortfolioApi.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillController(ISkillService skillService) : ControllerBase
    {
        protected readonly ISkillService _skillService = skillService;

        [HttpPost]
        public async Task<ActionResult<Skill>> CreateSkill(SkillRequestDto request)
        {
            var result = await _skillService.CreateSkillAsync(request);
            if (result is null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetSkillById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<ActionResult<Skill>> GetSkills()
        {
            var result = await _skillService.GetSkillsAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkillById(int id)
        {
            var result = await _skillService.GetSkillByIdAsync(id);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Skill>> UpdateSkill(int id, SkillRequestDto request)
        {
            var result = await _skillService.UpdateSkillAsync(id, request);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Skill>> DeleteSkill(int id)
        {
            var result = await _skillService.DeleteSkillAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
