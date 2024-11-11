using Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
    public class User : IdentityUser
    {
        public DateTime? Birthdate { get; set; }
        public string? Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public ICollection<RefreshToken>? RefreshTokens { get; set; }
        public ICollection<UserFavoriteNews>? FavoriteNews { get; set; }

    }
}
