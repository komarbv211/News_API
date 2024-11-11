using Data.Entities;
using System.Security.Claims;

namespace Core.Interfaces
{
    public interface IJwtService
    {
        IEnumerable<Claim> GetClaims(User user);
        string CreateToken(IEnumerable<Claim> claims);
        string CreateRefreshToken();
        IEnumerable<Claim> GetClaimsFromExpiredToken(string token);
        bool IsRefreshTokenExpired(DateTime creationTime);
        DateTime GetLastValidRefreshTokenDate();
    }
}