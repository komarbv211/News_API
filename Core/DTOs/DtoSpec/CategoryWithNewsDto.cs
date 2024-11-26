namespace Core.DTOs.DtoSpec
{
    public class CategoryWithNewsDto
    {
        public IEnumerable<NewsDto>? News { get; set; }

        public CategoryWithNewsDto()
        {
            News = new List<NewsDto>();
        }
    }
}
