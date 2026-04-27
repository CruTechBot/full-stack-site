using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Comments")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService) : base()
        {
            _commentService = commentService;
        }

        [Authorize]
        [HttpPost("Add")]
        public IActionResult AddComment(StringDTO comment)
        {
            var claimsUser = HttpContext.User;

            int.TryParse(claimsUser.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId);

            _commentService.AddComment(userId, comment.Content);

            return Ok();
        }

        [HttpGet("All")]
        public IActionResult GetAllComments()
        {
            return Ok(_commentService.GetComments().Select(c => new CommentDTO
            {
                Id = c.Id,
                UserId = c.User.Id,
                Name = c.User.Name,
                Comment = c.Text,
                Created = c.CreatedAt
            }));
        }

        [Authorize]
        [HttpPut("Delete")]
        public IActionResult DeleteComment(IntDTO comment)
        {
            var claimsUser = HttpContext.User;

            int.TryParse(claimsUser.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId);

            if (!_commentService.DeleteComment(userId, comment.Content))
            {
                return BadRequest("Failed to delete comment");
            }

            return Ok();
        }
    }
}
