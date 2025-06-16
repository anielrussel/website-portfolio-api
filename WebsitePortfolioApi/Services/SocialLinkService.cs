using Microsoft.EntityFrameworkCore;
using WebsitePortfolioApi.Data;
using WebsitePortfolioApi.Entities;
using WebsitePortfolioApi.Models.DTOs;
using WebsitePortfolioApi.Services.Interfaces;

namespace WebsitePortfolioApi.Services
{
    public class SocialLinkService(WebsitePortfolioDbContext context) : ISocialLinkService
    {
        protected readonly WebsitePortfolioDbContext _context = context;

        public async Task<SocialLink?> CreateSocialLinkAsync(SocialLinkRequestDto request)
        {
            var existingSocialLink = await _context.SocialLinks.FirstOrDefaultAsync(sl => sl.Name == request.Name);
            if (existingSocialLink is not null)
            {
                return null;
            }

            var socialLink = new SocialLink
            {
                Name = request.Name,
                Url = request.Url,
                Icon = request.Icon,
                ProfileId = request.ProfileId
            };

            _context.SocialLinks.Add(socialLink);
            await _context.SaveChangesAsync();

            return socialLink;
        }

        public async Task<SocialLink?> GetSocialLinkByIdAsync(int id)
        {
            var existingSocialLink = await _context.SocialLinks.FindAsync(id);
            if (existingSocialLink is null)
            {
                return null;
            }

            return existingSocialLink;
        }

        public async Task<List<SocialLink>?> GetSocialLinksAsync()
        {
           var socialLinks = await _context.SocialLinks.ToListAsync();
           
           return socialLinks.Count > 0 ? socialLinks : [];


        }

        public async Task<SocialLink?> UpdateSocialLinkAsync(int id, SocialLinkRequestDto request)
        {
            var existingSocialLink = await _context.SocialLinks.FindAsync(id);
            if (existingSocialLink is null)
            {
                return null;
            }

            existingSocialLink.Name = request.Name;
            existingSocialLink.Url = request.Url;
            existingSocialLink.Icon = request.Icon;
            existingSocialLink.ProfileId = request.ProfileId;

            _context.SocialLinks.Update(existingSocialLink);
            await _context.SaveChangesAsync();

            return existingSocialLink;
        }

        public async Task<SocialLink?> DeleteSocialLinkAsync(int id)
        {
            var existingSocialLink = await _context.SocialLinks.FindAsync(id);
            if (existingSocialLink is null)
            {
                return null;
            }

            _context.SocialLinks.Remove(existingSocialLink);
            await _context.SaveChangesAsync();

            return existingSocialLink;
        }
    }
}
