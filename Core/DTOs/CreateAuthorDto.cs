namespace Core.DTOs
{
    // Create Author DTO
    public class CreateAuthorDto
    {
        public string FullName { get; set; }
        public string? Pseudonym { get; set; }
        public string UserId { get; set; }
    }

}
