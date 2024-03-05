using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using JWTIdentity.Models;
using JWTIdentity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IBlogService _blogService;
        public AuthController(IAuthService authService, IBlogService blogService)
        {
            _authService = authService;
            _blogService = blogService;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(LoginUser user)
        {
            return Ok(await _authService.RegisteUser(user));
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login(LoginUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var loginResult = await _authService.Login(user);
            if (loginResult)
            {
                var tokenString = await _authService.GenerateTokenStringAsync(user);
                var username = await _authService.GetUsernameFromToken(tokenString);
                var x = ((ClaimsIdentity)HttpContext.User.Identity).FindFirst(ClaimTypes.NameIdentifier);


                return Ok(new { Token = tokenString, Username = username, id = x });
            }
            return BadRequest();
        }

        //[/A/0uthorize]
        [HttpGet("ValidateToken")]
        public async Task<IActionResult> ValidateToken()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (await _authService.ValidateToken(token))
            {
                var x = ((ClaimsIdentity)HttpContext.User.Identity).FindFirst(ClaimTypes.NameIdentifier);
                var y = ((ClaimsIdentity)HttpContext.User.Identity).FindFirst(ClaimTypes.Email);

                return Ok(new { NameIdentifier = x.Value, Email = y.Value });
            }
            return Unauthorized();
        }
        [Authorize]
        [HttpGet("GetUserBlogs")]
        public async Task<IActionResult> GetUserBlogs()
        {
            var userId = ((ClaimsIdentity)HttpContext.User.Identity).FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var blogs = await _blogService.GetUserBlogs(int.Parse(userId));
            return Ok(blogs);
        }
    }
}
