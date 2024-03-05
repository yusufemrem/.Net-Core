using DtoLayer.AddRoleDto;
using DtoLayer.UpdateRoleDto;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return Ok(values);
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(AddRoleDto addRoleDto)
        {
            AppRole role = new AppRole
            {
                Name = addRoleDto.Name
            };
            var result = await _roleManager.CreateAsync(role);
      
            return Ok(result);
        }

        [HttpDelete("DeleteRole/{id}")]
        public IActionResult DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x=> x.Id == id);
            _roleManager.DeleteAsync(values);
            return Ok();    
        }

        [HttpGet("UpdateRole/{id}")]
        public IActionResult UpdateRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x=>x.Id == id);
            UpdateRoleDto updateRoleDto = new UpdateRoleDto()
            {
                Id = value.Id,
                Name = value.Name,
            };
            return Ok(updateRoleDto);
        }
        [HttpPost("UpdateRole")]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            var value = _roleManager.Roles.FirstOrDefault(x=> x.Id == updateRoleDto.Id);
            value.Name = updateRoleDto.Name;
            await _roleManager.UpdateAsync(value);
            return Ok(value);    
        }
        //[HttpPost]
        //public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
        //{
        //    var value = _roleManager.Roles.FirstOrDefault(x => x.Id == updateRoleViewModel.RoleID);
        //    value.Name = updateRoleViewModel.RoleName;
        //    await _roleManager.UpdateAsync(value);
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public IActionResult UpdateRole(int id)
        //{
        //    var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
        //    UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel()
        //    {
        //        RoleID = value.Id,
        //        RoleName = value.Name
        //    };
        //    return View(updateRoleViewModel);
        //}
    }
}
