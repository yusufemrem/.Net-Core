using BusinessLayer.Abstract;
using DtoLayer.Writer;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private IWriterService _writerService;
        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet("getByWriter/{id}")]
        public IActionResult getByWriter(int id)
        {
            var values = _writerService.GetWriterById(id);
            return Ok(values);
        }

        [HttpGet("allWriter")]
        public IActionResult allWriter()
        {
            var values = _writerService.GetList();
            return Ok(values);
        }

        //[HttpPost("AddWriter")]
        //public IActionResult AddWriter(AddWriterDto addWriterDto)
        //{
        //    Writer writer = new Writer
        //    {
        //        WriterID = addWriterDto.WriterID,
        //        WriterName = addWriterDto.WriterName,
        //    };

        //    _writerService.TAdd(writer);
        //    return Ok();
        //}
    }
}
