using Data.Entities;
using Ardalis.Specification;

namespace Core.Specifications
{
    public class StatisticsSpecification : Specification<Statistics>
    {
        public StatisticsSpecification(int? newsId = null, string? ipAddress = null)
        {
            if (newsId.HasValue)
            {
                Query.Where(s => s.NewsId == newsId.Value);
            }

            if (!string.IsNullOrWhiteSpace(ipAddress))
            {
                Query.Where(s => s.IpAddress == ipAddress);
            }

            Query.OrderByDescending(s => s.VisitTime);
        }
    }
}
