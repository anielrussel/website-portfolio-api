namespace WebsitePortfolioApi.Models.DTOs
{
    public class ProjectRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string? Url { get; set; }
        public string? RepoLink { get; set; }
        public int ProfileId { get; set; }
    }
}
