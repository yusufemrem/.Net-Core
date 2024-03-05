using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.Blog;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private IWriterService _writerService;
        public HomeController(IBlogService blogService, ICategoryService categoryService, IWriterService writerService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _writerService = writerService;
        }

        [HttpGet("getBlog")]
        public IActionResult getBlog()
        {
            var values = _blogService.GetList();
            return Ok(values);
        }

        [HttpGet("getByBlog/{id}")]
        public IActionResult getByBlog(int id)
        {
            var values = _blogService.TGetById(id);
            return Ok(values);
        }

        [HttpGet("getByCategories")]
        public IActionResult getByCategories()
        {
            var values = _blogService.GetBlogListWithCategory();
            return Ok(values);
        }

        [HttpPost("addBlog")]
        public IActionResult addBlog(CreateBlogDto createBlogDto)
        {
            //using (var dbContext = new Context())
            //{
            //    // Check if the writer with the given WriterID exists
            //    var existingWriter = dbContext.Writers.FirstOrDefault(x => x.WriterID == createBlogDto.WriterID);

            //    // If the writer does not exist, create a new writer
            //    if (existingWriter == null)
            //    {
            //        // Create a new writer and add it to the Writers table
            //        var newWriter = new Writer
            //        {
            //            // You may need to adjust the properties based on your Writer entity
            //            WriterID = createBlogDto.WriterID,
            //            WriterName = createBlogDto.WriterName,
            //            // Add other writer properties as needed
            //        };
            //        dbContext.Writers.Add(newWriter);
            //        dbContext.SaveChanges(); // Save changes to the database
            //    }
            //}
            DateTime now = DateTime.Now;
            DateTime dateOnly = now.Date;
            Blog blog = new Blog
            {
                BlogID = createBlogDto.BlogID,
                Blo1Title = createBlogDto.Blo1Title,
                BlogContent = createBlogDto.BlogContent,
                BlogCreateDate = DateTime.Now.Date,
                WriterID = 21,
                WriterName = createBlogDto.WriterName,
                AppUserID =4 
            //                // Örnek bir DbContext kullanımı, gerçek uygulamanıza göre değiştirmeniz gerekebilir
            //using (var dbContext = new YourDbContext())
            //            {
            //                // WriterID'yi kullanarak Writer'ın adını çek
            //                var writerName = dbContext.Writers
            //                    .Where(w => w.WriterID == createBlogDto.WriterID)
            //                    .Select(w => w.WriterName)
            //                    .FirstOrDefault();

            //                // Blog nesnesine WriterName'i ekle
            //                Blog blog = new Blog
            //                {
            //                    BlogID = createBlogDto.BlogID,
            //                    BlogTitle = createBlogDto.BlogTitle,
            //                    BlogContent = createBlogDto.BlogContent,
            //                    BlogCreateDate = DateTime.Now.Date,
            //                    WriterID = createBlogDto.WriterID,
            //                    WriterName = writerName  // WriterName'i ekle
            //                };

            //                // Blog'u veritabanına ekle
            //                dbContext.Blogs.Add(blog);
            //                dbContext.SaveChanges();
            //            }
        };
        _blogService.TAdd(blog);
            return Ok();
    }

    [HttpDelete("deleteBlog/{id}")]
    public IActionResult deleteBlog(int id)
    {
        var values = _blogService.TGetById(id);
        _blogService.TDelete(values);
        return Ok();
    }

    [HttpGet("updateBlog/{id}")]
    public IActionResult updateBlog(int id)
    {
        var values = _blogService.TGetById(id);
        return Ok(values);
    }

    [HttpPost("updateBlog")]
    public IActionResult updateBlog(Blog blog)
    {
        blog.WriterID = 21;
        _blogService.TUpdate(blog);
        return Ok(blog);
    }
    //[HttpGet("getNameBlogWriter")]
    //public IActionResult getNameBlogWriter(int id)
    //{
    //    var values = _writerService.TGetById(id);
    //    return Ok(values);
    //}

    //[HttpGet("getByWriter/{id}")]
    //public IActionResult getByWriter(int id)
    //{
    //    var values = _writerService.GetWriterById(id);
    //    return Ok(values);
    //}
}
}
