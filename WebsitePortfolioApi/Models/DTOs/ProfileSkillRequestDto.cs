namespace WebsitePortfolioApi.Models.DTOs
{
    public class ProfileSkillRequestDto
    {
        public int ProfileId { get; set; }
        public List<int> AddedSkillIds { get; set; } = new();
        public List<int> DeletedSkillIds { get; set; } = new();
    }
}
