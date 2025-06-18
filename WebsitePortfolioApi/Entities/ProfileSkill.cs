namespace WebsitePortfolioApi.Entities
{
    public class ProfileSkill
    {
        public int ProfileId { get; set; }
        public int SkillId { get; set; }

        public Profile Profile { get; set; } = default!;
        public Skill Skill { get; set; } = default!;
    }
}
