using Data.Entities;

namespace Data.Entities
{
    public class News : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FullText { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string? Images { get; set; }
        public Category? Category { get; set; }
        public Author? Author { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<UserFavoriteNews>? FavoriteUsers { get; set; }
    }
}
