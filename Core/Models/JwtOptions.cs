
namespace Core.Models
{
    public class JwtOptions
    {
        public string Key { get; set; }
        public int Lifetime { get; set; }
        public string Issuer { get; set; }
        public int RefreshTokenLifetimeInDays { get; set; }
    }
}