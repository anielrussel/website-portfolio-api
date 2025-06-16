namespace WebsitePortfolioApi.Models.DTOs
{
    public class SocialLinkRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Url { get; set; }
        public string? Icon { get; set; }
        public int ProfileId { get; set; }
    }
}
