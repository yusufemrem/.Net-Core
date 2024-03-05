using DtoLayer.LoginUserDto;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpPost("Index")]
        public async Task<IActionResult> Index(LoginUserDto loginUserDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password, false, false);
                if (result.Succeeded)
                {


                    var user = await _userManager.FindByNameAsync(loginUserDto.Username);
                    HttpContext.Session.SetString("UserName", user.UserName);

                    var username = user.UserName;
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }


            return Ok();
        }

        // burada kaldık butona tıklandığında aşağıdaki metota uğryor fakat else düşüyor üstteki metottaki  LoginUserDto alıp aşağıda kullanıp denemelisin.

        [HttpGet("getUserInfo")]
        public IActionResult getUserInfo()
        {
            
            var UserName = HttpContext.Session.GetString("UserName");
            if (!string.IsNullOrEmpty(UserName))
            {
                return Ok(UserName);
            }
            else
            {
                return BadRequest("Kullanıcı oturumu bulunamadı.");
            }

        }

    }
}
