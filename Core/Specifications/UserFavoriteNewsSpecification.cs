using Data.Entities;
using Ardalis.Specification;

namespace Core.Specifications
{
    public class UserFavoriteNewsSpecification : Specification<UserFavoriteNews>
    {
        public UserFavoriteNewsSpecification(string userId, bool includeNews = false)
        {
            Query.Where(ufn => ufn.UserId == userId);

            if (includeNews)
            {
                Query.Include(ufn => ufn.News);
            }
        }
    }
}
