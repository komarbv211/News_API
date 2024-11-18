using Microsoft.AspNetCore.Http;

namespace Core.DTOs
{
    public class UpdateNewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FullText { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public IFormFile? Images { get; set; }
    }

}
