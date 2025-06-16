using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;
using WebsitePortfolioApi.Services.Interfaces;

namespace WebsitePortfolioApi.Controllers
{
    [Route("api/profiles")]
    [ApiController]
    //[Authorize]
    public class ProfileController(IProfileService profileService) : ControllerBase
    {
        protected readonly IProfileService _profileService = profileService;

        [HttpPost]
        public async Task<ActionResult<Profile>> CreateProfile(ProfileRequestDto request)
        {
            var result = await _profileService.CreateProfileAsync(request);

            if (result is null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetProfileById), new { id = result.Id}, result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Profile>>> GetProfiles()
        {
            var result = await _profileService.GetProfilesAsync();
                       
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> GetProfileById(int id)
        {
            var result = await _profileService.GetProfileByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Profile>> UpdateProfile(int id, ProfileRequestDto request)
        {
            var result = await _profileService.UpdateProfileAsync(id, request);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Profile>> DeleteProfile(int id)
        {
            var result = await _profileService.DeleteProfileAsync(id);

            if (result is null)
            {
                return NotFound();
            }

            return result;
        }
    }
}
