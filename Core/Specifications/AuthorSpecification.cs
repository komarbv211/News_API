using Data.Entities;
using Ardalis.Specification;

namespace Core.Specifications
{
    public class AuthorSpecification : Specification<Author>
    {
        public AuthorSpecification(string? fullName = null, string? userId = null, bool includeNews = false)
        {
            if (!string.IsNullOrWhiteSpace(fullName))
            {
                Query.Where(a => a.FullName.Contains(fullName) || (a.Pseudonym != null && a.Pseudonym.Contains(fullName)));
            }

            // Фільтрація по userId
            if (!string.IsNullOrEmpty(userId)) 
            {
                Query.Where(a => a.UserId == userId);
            }

            if (includeNews)
            {
                Query.Include(a => a.News);
            }

            Query.OrderBy(a => a.FullName);
        }
    }
}
