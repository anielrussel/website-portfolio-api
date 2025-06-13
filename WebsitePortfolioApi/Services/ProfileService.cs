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

        public async Task<Profile?> CreateProfileAsync(ProfileRequestDto request)
        {
            var existingProfile = await _context.Profiles.FindAsync(request.UserId);
            if (existingProfile is not null)
            {
                return null;
            }
            var profile = new Profile
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                Position = request.Position,
                Image = request.Image,
                Address = request.Address,
                UserId = request.UserId
            };

            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();


            return profile;
        }
        public async Task<List<Profile?>> GetProfilesAsync()
        {
            var profiles = await _context.Profiles.ToListAsync();

        
            return profiles.Count > 0 ? profiles : [];
        }
        public async Task<Profile?> GetProfileByIdAsync(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);

            if (profile is null)
            {
                return null;
            }

            return profile;
        }
        public async Task<Profile?> UpdateProfileAsync(int id, ProfileRequestDto request)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if ( profile is null)
            {
                return null;
            }

            profile.FirstName = request.FirstName;
            profile.MiddleName = request.MiddleName;
            profile.LastName = request.LastName;
            profile.Position = request.Position;
            profile.Image = request.Image;
            profile.Address = request.Address;
            profile.UserId = request.UserId;

            _context.Profiles.Update(profile);
            await _context.SaveChangesAsync();

            return profile;
        }
        public async Task<Profile?> DeleteProfileAsync(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);

            if (profile is null)
            {
                return null;
            }

            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();

            return profile;
        }
    }
}
