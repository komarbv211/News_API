using Data.Entities;
using Ardalis.Specification;

namespace Core.Specifications
{
    public class NewsSpecification : Specification<News>
    {
        public NewsSpecification(
            string? keyword = null,
            int? categoryId = null,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            bool includeAuthor = false,
            bool includeCategory = false,
            bool includeComments = false)
        {
            // Фільтр за ключовим словом
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                Query.Where(n => n.Title.Contains(keyword) || n.Description.Contains(keyword));
            }

            // Фільтр за категорією
            if (categoryId.HasValue)
            {
                Query.Where(n => n.CategoryId == categoryId.Value);
            }

            // Фільтр за датою публікації (від)
            if (fromDate.HasValue)
            {
                Query.Where(n => n.PublishDate >= fromDate.Value);
            }

            // Фільтр за датою публікації (до)
            if (toDate.HasValue)
            {
                Query.Where(n => n.PublishDate <= toDate.Value);
            }

            // Включення автора
            if (includeAuthor)
            {
                Query.Include(n => n.Author);
            }

            // Включення категорії
            if (includeCategory)
            {
                Query.Include(n => n.Category);
            }

            // Включення коментарів
            if (includeComments)
            {
                Query.Include(n => n.Comments);
            }

            // Сортування за датою публікації (спадання)
            Query.OrderByDescending(n => n.PublishDate);
        }
    }
}
