using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Pseudonym { get; set; }
        public string UserId { get; set; }
        public ICollection<NewsDto> News { get; set; } = new List<NewsDto>();
    }

}
