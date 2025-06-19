using System.Text.Json.Serialization;

namespace WebsitePortfolioApi.Entities
{
    public class ProfileSkill
    {
        public int ProfileId { get; set; }
        public int SkillId { get; set; }

        [JsonIgnore]
        public Profile Profile { get; set; } = default!;
        [JsonIgnore]
        public Skill Skill { get; set; } = default!;
    }
}
