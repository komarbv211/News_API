namespace Core.DTOs
{
    public class CreateNewsDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; } 
    }

}
