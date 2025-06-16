using System.Text.Json.Serialization;

namespace WebsitePortfolioApi.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Icon { get; set; }
        public string Category { get; set; } = string.Empty;
        public int ProfileId { get; set; }

        [JsonIgnore]
        public Profile? Profile { get; set; }
    }
}
