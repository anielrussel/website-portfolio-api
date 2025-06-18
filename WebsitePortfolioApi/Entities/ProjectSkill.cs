using System.Text.Json.Serialization;

namespace WebsitePortfolioApi.Entities
{
    public class ProjectSkill
    {
        public int SkillId { get; set; }
        [JsonIgnore]
        public int ProjectId { get; set; }
       


        [JsonIgnore]
        public virtual Project Project { get; set; } = default!;
        [JsonIgnore]
        public virtual Skill Skill { get; set; } = default!;
    }
}
