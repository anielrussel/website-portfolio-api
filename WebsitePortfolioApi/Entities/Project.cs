using System.Text.Json.Serialization;

namespace WebsitePortfolioApi.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string? Url { get; set; }
        public string? RepoLink { get; set; }
        public int ProfileId { get; set; }

        [JsonIgnore]
        public Profile? Profile { get; set; }
        public List<ProjectSkill> ProjectSkills { get; set; } = new();
    }
}
