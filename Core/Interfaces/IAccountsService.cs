using Azure.Core;
using Core.Dto;
using Core.Dto.DtoAuthorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAccountsService
    {
        Task Register(RegisterDto model);
        Task<UserTokens> Login(LoginDto model);
        Task Logout(string refreshToken);
        Task<UserTokens> RefreshTokens(UserTokens tokens);
        Task RemoveExpiredRefreshTokens();
    }
}
