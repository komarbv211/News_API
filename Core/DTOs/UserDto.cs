namespace Core.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}
