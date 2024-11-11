using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class NewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FullText { get; set; }
        public DateTime PublishDate { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string? Images { get; set; }
        public ICollection<CommentDto>? Comments { get; set; }
    }

}
