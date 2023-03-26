using FLASK_COFFEE_API.Areas.Client.Dtos.Auth;
using FLASK_COFFEE_API.Database;
using FLASK_COFFEE_API.Services.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FLASK_COFFEE_API.Areas.Client.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly DataContext _dbContext;
        private readonly IConfiguration _configuration;
        public readonly IUserService _userService;
        public AuthenticationController(DataContext dbContext, IConfiguration configuration, IUserService userService)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _userService = userService;
        }


        [HttpPost("auth/register")]
        public async Task<IActionResult> RegisterAsync()
        {

            return Ok();
        }
        [HttpPost("auth/logout")]
        public async Task<IActionResult> LogoutAsync()
        {

            return Ok();
        }
        [HttpPost("auth/login")]
        public async Task<IActionResult> LoginAsync(LoginDto dto)
        {
            return Ok( await _userService.SignInAsync(dto.Email, dto.Password));
        }


    }
}
