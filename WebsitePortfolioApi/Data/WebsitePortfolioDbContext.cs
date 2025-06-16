using Microsoft.EntityFrameworkCore;
using WebsitePortfolioApi.Entities;

namespace WebsitePortfolioApi.Data
{
    public class WebsitePortfolioDbContext(DbContextOptions<WebsitePortfolioDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Profile> Profiles => Set<Profile>();
        public DbSet<SocialLink> SocialLinks => Set<SocialLink>();
        public DbSet<Skill> Skills => Set<Skill>();
    }
}
