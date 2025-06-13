using Microsoft.EntityFrameworkCore;
using WebsitePortfolioApi.Entities;

namespace WebsitePortfolioApi.Data
{
    public class WebsitePortfolioDbContext(DbContextOptions<WebsitePortfolioDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
    }
}
