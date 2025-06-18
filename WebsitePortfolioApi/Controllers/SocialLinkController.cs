using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;
using WebsitePortfolioApi.Services.Interfaces;

namespace WebsitePortfolioApi.Controllers
{
    [Route("api/sociallinks")]
    [ApiController]
    [Authorize]
    public class SocialLinkController(ISocialLinkService socialLinkService) : ControllerBase
    {
        protected readonly ISocialLinkService _socialLinkService = socialLinkService;

        [HttpPost]
        public async Task<ActionResult<SocialLink>> CreateSocialLink(SocialLinkRequestDto request)
        {
            var result = await _socialLinkService.CreateSocialLinkAsync(request);

            if (result is null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetSocialLinkById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<ActionResult<List<SocialLink>>> GetSocialLinks()
        {
            var result = await _socialLinkService.GetSocialLinksAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SocialLink>> GetSocialLinkById(int id)
        {
            var result = await _socialLinkService.GetSocialLinkByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SocialLink>> UpdateSocialLink(int id, SocialLinkRequestDto request)
        {
            var result = await _socialLinkService.UpdateSocialLinkAsync(id, request);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SocialLink>> DeleteSocialLink(int id)
        {
            var result = await _socialLinkService.DeleteSocialLinkAsync(id);
            if (result is null)
            {
                return NotFound();
            }

            return result;
        }
    }
}
