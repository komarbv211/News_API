using Data.Entities;
using Ardalis.Specification;

namespace Core.Specifications
{
    public class CategorySpecification
    { 
        internal class ById : Specification<Category>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.News);
            }
        }

        internal class All : Specification<Category>
        {
            public All()
            {
                Query
                    .Include(x => x.News);
            }
        }

    }
}
