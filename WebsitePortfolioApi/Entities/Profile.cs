namespace WebsitePortfolioApi.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string? Address { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public List<SocialLink> SocialLinks { get; set; } = new List<SocialLink>();
        public List<ProfileSkill> Skills { get; set; } = new();
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
