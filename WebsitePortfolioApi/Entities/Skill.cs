namespace WebsitePortfolioApi.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Icon { get; set; }
        public string Category { get; set; } = string.Empty;

        public List<ProfileSkill> ProfileSkills { get; set; } = new();
        public List<ProjectSkill> ProjectSkills { get; set; } = new();
    }
}
