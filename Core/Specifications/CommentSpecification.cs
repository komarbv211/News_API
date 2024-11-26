using Data.Entities;
using Ardalis.Specification;

namespace Core.Specifications
{
    public class CommentSpecification : Specification<Comment>
    {
        public CommentSpecification(int? newsId = null, string? userName = null)
        {
            if (newsId.HasValue)
            {
                Query.Where(c => c.NewsId == newsId.Value);
            }

            if (!string.IsNullOrWhiteSpace(userName))
            {
                Query.Where(c => c.UserName.Contains(userName));
            }

            Query.OrderByDescending(c => c.DatePosted);
        }
    }
}
