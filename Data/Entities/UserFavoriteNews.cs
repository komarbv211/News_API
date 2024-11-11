
namespace Data.Entities
{
    public class UserFavoriteNews 
    {
        public string UserId { get; set; }
        public int NewsId { get; set; }
        public User? User { get; set; }
        public News? News { get; set; } 
    }

}
