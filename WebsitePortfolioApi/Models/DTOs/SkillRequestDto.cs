namespace WebsitePortfolioApi.Models.DTOs
{
    public class SkillRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Icon { get; set; }
        public string Category { get; set; } = string.Empty;
        public int ProfileId { get; set; }
    }
}
