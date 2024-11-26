using Data.Entities;

namespace Data.Entities
{
    public class Category : BaseEntity
    {
  
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<News>? News { get; set; }
    }
}
