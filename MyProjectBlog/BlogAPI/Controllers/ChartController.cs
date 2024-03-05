using BlogAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        [HttpGet("CategoryChart")]
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();

            list.Add(new CategoryClass
            {
                categoryname = "Teknoloji",
                categorycount = 10,
            });
            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 14,
            });
            list.Add(new CategoryClass
            {
                categoryname = "Film Dizi",
                categorycount = 5,
            });
            return new JsonResult(new { jsonlist = list });
        }
    }
}
