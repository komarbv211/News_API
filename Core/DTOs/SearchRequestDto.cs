namespace Core.DTOs
{
    public class SearchRequestDto
    {
        public int Id { get; set; }
        public string Keyword { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
