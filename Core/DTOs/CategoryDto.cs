using Data.Entities;
using Core.Interfaces;
namespace Core.DTOs
{
    public class CategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<News> News { get; set; }
    }
}
