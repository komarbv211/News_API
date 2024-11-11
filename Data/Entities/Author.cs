using Data.Entities;

namespace Data.Entities
{
    public class Author : BaseEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserId { get; set; }
        public string? Pseudonym { get; set; }
        public ICollection<News> News { get; set; } = new List<News>();
        public User User { get; set; }
    }

}
