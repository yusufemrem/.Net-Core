using BusinessLayer.Concrete;
using DtoLayer.RoleAssign;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleAssignController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleAssignController(UserManager<AppUser> userManager ,RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet("Index")]
        public ActionResult Index()
        {
            var values = _userManager.Users.ToList();
            return Ok(values);
        }

        [HttpGet("RoleName")]
        public IActionResult RoleName()
        {
            var user = _roleManager.Roles.ToList();
            return Ok(user);
        }


        [HttpGet("AssignRole/{id}")]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return NotFound($"Kullanıcı bulunamadı: {id}");
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            return Ok(new { UserId = id, UserRoles = userRoles });
        }

        [HttpPost("AssignRole/{id}/{name}")]
        public async  Task<IActionResult> AssignRole(int id, string name)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return NotFound($"Kullanıcı bulunamadı: {id}");
            }

            var roleExist = await _roleManager.RoleExistsAsync(name);
            if (!roleExist)
            {
                return NotFound($"Rol bulunamadı: {name}");
            }

            // Kullanıcıya rolü atama
            await _userManager.AddToRoleAsync(user, name);

            return Ok($"Kullanıcıya rol '{name}' başarıyla atandı.");
        }
    }
}
