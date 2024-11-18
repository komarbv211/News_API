using Microsoft.AspNetCore.Http;

namespace Core.DTOs
{
    public class CreateNewsDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FullText { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public IFormFile? Images { get; set; }
    }

}
