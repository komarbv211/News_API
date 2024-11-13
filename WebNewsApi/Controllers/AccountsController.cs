using Core.Dto;
using Core.Dto.DtoAuthorization;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebNewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            await accountsService.Register(model);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            return Ok(await accountsService.Login(model));
        }
        [HttpPost("refreshTokens")]
        public async Task<IActionResult> RefreshTokens(UserTokens tokens)
        {
            return Ok(await accountsService.RefreshTokens(tokens));
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }
    }
}
