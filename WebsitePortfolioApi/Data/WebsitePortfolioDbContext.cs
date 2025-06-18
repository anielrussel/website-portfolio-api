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
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<ProfileSkill> ProfileSkills => Set<ProfileSkill>();
        public DbSet<ProjectSkill> ProjectSkills => Set<ProjectSkill>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfileSkill>()
                .HasKey(ps => new { ps.ProfileId, ps.SkillId });
            modelBuilder.Entity<ProfileSkill>()
                .HasOne(ps => ps.Profile)
                .WithMany(p => p.Skills)
                .HasForeignKey(ps => ps.ProfileId);
            modelBuilder.Entity<ProfileSkill>()
                .HasOne(ps => ps.Skill)
                .WithMany(s => s.ProfileSkills)
                .HasForeignKey(ps => ps.SkillId);

            
            modelBuilder.Entity<ProjectSkill>()
                .HasKey(ps => new { ps.ProjectId, ps.SkillId });
            modelBuilder.Entity<ProjectSkill>()
                .HasOne(ps => ps.Project)
                .WithMany(p => p.ProjectSkills)
                .HasForeignKey(ps => ps.ProjectId);
            modelBuilder.Entity<ProjectSkill>()
                .HasOne(ps => ps.Skill)
                .WithMany(s => s.ProjectSkills)
                .HasForeignKey(ps => ps.SkillId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
