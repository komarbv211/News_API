using Data.Entities;
using Ardalis.Specification;

namespace Core.Specifications
{
    public class SearchRequestSpecification : Specification<SearchRequest>
    {
        public SearchRequestSpecification(string? keyword = null, int? categoryId = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                Query.Where(sr => sr.Keyword.Contains(keyword));
            }

            if (categoryId.HasValue)
            {
                Query.Where(sr => sr.CategoryId == categoryId.Value);
            }

            if (fromDate.HasValue)
            {
                Query.Where(sr => sr.FromDate >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                Query.Where(sr => sr.ToDate <= toDate.Value);
            }

            Query.OrderByDescending(sr => sr.Id);
        }
    }
}
