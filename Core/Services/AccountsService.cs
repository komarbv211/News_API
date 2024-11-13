using AutoMapper;
using Core.Dto;
using Core.Dto.DtoAuthorization;
using Core.Exceptions;
using Core.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Services
{
    public class AccountsService( UserManager<User> userManager,IMapper mapper,
        IJwtService jwtService, IRepository<RefreshToken> refreshTokenR) : IAccountsService
    {
        private readonly UserManager<User> userManager = userManager;
        private readonly IMapper mapper = mapper;
        private readonly IJwtService jwtService = jwtService;
        private readonly IRepository<RefreshToken> refreshTokenR = refreshTokenR;

        public async Task Register(RegisterDto model)
        {
            var user = mapper.Map<User>(model);

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                //string all = string.Join(" ", result.Errors.Select(x => x.Description));
                var error = result.Errors.First();
                throw new HttpException(error.Description, HttpStatusCode.BadRequest);
            }
        }

        public async Task<UserTokens> Login(LoginDto model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
            {
                throw new HttpException("Invalid login or password.", HttpStatusCode.BadRequest);
            }

            var roles = await userManager.GetRolesAsync(user); // Отримуємо ролі користувача
            var claims = jwtService.GetClaims(user).ToList();

            // Додаємо ролі в claims
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return new UserTokens
            {
                AccessToken = jwtService.CreateToken(claims),
                RefreshToken = CreateRefreshToken(user.Id).Token
            };
        }

        public async Task Logout(string refreshToken)
        {
                var record = (await refreshTokenR.Get(x => x.Token == refreshToken)).FirstOrDefault();
                if (record == null) return;

                await refreshTokenR.Delete(record);
                await refreshTokenR.Save();
        }

        public async Task<UserTokens> RefreshTokens(UserTokens userTokens)
        {
            var refrestToken = (await refreshTokenR.Get(x => x.Token == userTokens.RefreshToken)).FirstOrDefault();

            if (refrestToken == null || jwtService.IsRefreshTokenExpired(refrestToken.CreationDate))
                throw new HttpException("Invalid token.", HttpStatusCode.BadRequest);

            var claims = jwtService.GetClaimsFromExpiredToken(userTokens.AccessToken);
            var newAccessToken = jwtService.CreateToken(claims);
            var newRefreshToken = jwtService.CreateRefreshToken();

            // update refresh token in db
            refrestToken.Token = newRefreshToken;
            refrestToken.CreationDate = DateTime.UtcNow;

            await refreshTokenR.Update(refrestToken);
            await refreshTokenR.Save();

            var tokens = new UserTokens()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };

            return tokens;
        }

        public async Task RemoveExpiredRefreshTokens()
        {
            var lastDate = jwtService.GetLastValidRefreshTokenDate();
            var expiredTokens = await refreshTokenR.Get(x => x.CreationDate < lastDate);
            foreach (var i in expiredTokens)
            {
                await refreshTokenR.Delete(i);
            }
            await refreshTokenR.Save();
        }

        private RefreshToken CreateRefreshToken(string userId)
        {
            var refeshToken = jwtService.CreateRefreshToken();
            var refreshTokenEntity = new RefreshToken
            {
                Token = refeshToken,
                UserId = userId,
                CreationDate = DateTime.UtcNow 
            };
            refreshTokenR.Insert(refreshTokenEntity);
            refreshTokenR.Save();
            return refreshTokenEntity;
        }
    }
}
