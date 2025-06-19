using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> CreateProfile(ProfileRequestDto request)
        {
            var result = await _profileService.CreateProfileAsync(request);

            return result.ToActionResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetProfiles()
        {
            var result = await _profileService.GetProfilesAsync();

            return result.ToActionResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfileById(int id)
        {
            var result = await _profileService.GetProfileByIdAsync(id);
           
            return result.ToActionResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(int id, ProfileRequestDto request)
        {
            var result = await _profileService.UpdateProfileAsync(id, request);
            
            return  result.ToActionResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var result = await _profileService.DeleteProfileAsync(id);

            return result.ToActionResult();
        }

        [HttpPost("skills")]
        public async Task<IActionResult> AddDeleteSkills(ProfileSkillRequestDto request)
        {
            var result = await _profileService.AddDeleteSkillsAsync(request);
          
            return result.ToActionResult();
        }
    }
}
