namespace WebsitePortfolioApi.Models.DTOs
{
    public class LoginResponseDto
    {
        public required string Username { get; set; }
        public required string Token { get; set; }
        public required string RefreshToken { get; set; }
    }
}
