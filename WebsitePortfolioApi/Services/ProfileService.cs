using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsitePortfolioApi.Data;
using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;
using WebsitePortfolioApi.Services.Interfaces;

namespace WebsitePortfolioApi.Services
{
    public class ProfileService(WebsitePortfolioDbContext context) : IProfileService
    {
        protected readonly WebsitePortfolioDbContext _context = context;

        public async Task<ApiResponse<Profile>> CreateProfileAsync(ProfileRequestDto request)
        {
            var existingProfile = await _context.Profiles.FindAsync(request.UserId);
            if (existingProfile is not null)
            {
                return ApiResponse<Profile>.Conflict("Profile already exists.");
            }
            var profile = new Profile
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                Position = request.Position,
                Image = request.Image,
                Address = request.Address,
                UserId = request.UserId,
                Email = request.Email,
                ContactNo = request.ContactNo,
            };

            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            return ApiResponse<Profile>.Created(profile);
        }
        public async Task<ApiResponse<List<Profile>>> GetProfilesAsync()
        {
            var profiles = await _context.Profiles
                .Include(p => p.SocialLinks)
                .Include(p => p.Skills)
                .Include(p => p.Projects)
                .AsSplitQuery()
                .ToListAsync();

            if (profiles is null || !profiles.Any())
            {
                return ApiResponse<List<Profile>>.NotFound("No profiles found.");
            }


            return ApiResponse<List<Profile>>.SuccessResponse(profiles);
        }
        public async Task<ApiResponse<Profile>> GetProfileByIdAsync(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);

            if (profile is null)
            {
                return ApiResponse<Profile>.NotFound("Profile not found.");
            }

            return ApiResponse<Profile>.SuccessResponse(profile);
        }
        public async Task<ApiResponse<Profile>> UpdateProfileAsync(int id, ProfileRequestDto request)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if ( profile is null)
            {
                return ApiResponse<Profile>.NotFound("Profile not found.");
            }

            profile.FirstName = request.FirstName;
            profile.MiddleName = request.MiddleName;
            profile.LastName = request.LastName;
            profile.Position = request.Position;
            profile.Image = request.Image;
            profile.Address = request.Address;
            profile.UserId = request.UserId;
            profile.Email = request.Email;
            profile.ContactNo = request.ContactNo;

            _context.Profiles.Update(profile);
            await _context.SaveChangesAsync();

            return ApiResponse<Profile>.SuccessResponse(profile, "Profile updated successfully");
        }
        public async Task<ApiResponse<Profile>> DeleteProfileAsync(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);

            if (profile is null)
            {
                return ApiResponse<Profile>.NotFound("Profile not found.");
            }

            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();

            return ApiResponse<Profile>.SuccessResponse(profile, "Profile deleted successfully.");
        }

        public async Task<ApiResponse<ProfileSkillRequestDto>> AddDeleteSkillsAsync(ProfileSkillRequestDto request)
        {
            if (request.AddedSkillIds.Any())
            {
                var existingProfile = await _context.ProfileSkills
                    .Where(p => p.ProfileId == request.ProfileId && request.AddedSkillIds.Contains(p.SkillId))
                    .Select(p => p.SkillId)
                    .ToListAsync();

                var newSkills = request.AddedSkillIds
                    .Except(existingProfile)
                    .Select(skillId => new ProfileSkill
                    {
                        ProfileId = request.ProfileId,
                        SkillId = skillId
                    });

                _context.ProfileSkills.AddRange(newSkills);
            }

            if (request.DeletedSkillIds.Any())
            {
                var existingSkills = await _context.ProfileSkills
                    .Where(p => p.ProfileId == request.ProfileId && request.DeletedSkillIds.Contains(p.SkillId))
                    .ToListAsync();
                _context.ProfileSkills.RemoveRange(existingSkills);
            }

            await _context.SaveChangesAsync();

            return ApiResponse<ProfileSkillRequestDto>.SuccessResponse(request);
        }
    }
}
