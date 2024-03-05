using BusinessLayer.Abstract;
using DtoLayer.CommentDto;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("CommentListByBlog/{id}")]
        public IActionResult CommentListByBlog(int id)
        {
            var values = _commentService.GetByList(id);
            return Ok(values);

        }
        [HttpGet("CommentList")]
        public IActionResult CommentList()
        {
            var values = _commentService.GetList();
            return Ok(values);
        }

        [HttpPost("AddComment")]
        public IActionResult AddComment(CreateCommentDto createCommentDto)
        {
            DateTime now = DateTime.Now;
            DateTime dateOnly = now.Date;
            var comment = new Comment
            {
                CommentID = createCommentDto.CommentID,
                CommentUserName = createCommentDto.CommentUserName,
                CommentTitle = createCommentDto.CommentTitle,
                CommentContent = createCommentDto.CommentContent,
                CommentStatus = true,
                CommentDate = DateTime.Now.Date,
                BlogID =createCommentDto.BlogID,
            };

            _commentService.TAdd(comment);
            return Ok();
        }
        [HttpDelete("DeleteComment/{id}")]
        public IActionResult DeleteComment(int id)
        {
            var values = _commentService.TGetById(id);
            _commentService.TDelete(values);
            return Ok(values);
        }
        [HttpGet("UpdateComment/{id}")]
        public IActionResult UpdateComment(int id)
        {
            var values = _commentService.TGetById(id);
            return Ok(values);
        }
        [HttpPost("UpdateComment")]
        public IActionResult UpdateComment(Comment comment)
        {
            
            _commentService.TUpdate(comment);
            return Ok();
        }
    }
}

