namespace Core.DTOs
{
    public class RefreshTokenDto
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserId { get; set; }
    }
}
