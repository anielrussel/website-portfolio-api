namespace WebsitePortfolioApi.Models.DTOs
{
    public class ProjectSkillRequestDto
    {
        public int ProjectId { get; set; }
        public List<int> AddedSkillIds { get; set; } = new();
        public List<int> DeletedSkillIds { get; set; } = new();
    }
}
