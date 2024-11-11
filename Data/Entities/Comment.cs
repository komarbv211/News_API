using Data.Entities;

namespace Data.Entities
{
    public class Comment : BaseEntity
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }

        public Comment(int newsId, string userName, string content)
        {
            NewsId = newsId;
            UserName = userName;
            Content = content;
            DatePosted = DateTime.Now;
        }
    }
}
