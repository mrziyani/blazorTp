using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace WebAPI.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly PostService _postService;

        public CommentController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet("commentsById/{postId}")]
        public async Task<IActionResult> GetCommentsByPostId(int postId)
        {
            var comments = await _postService.GetCommentsByPostIdAsync(postId);
            return Ok(comments);
        }

        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment([FromBody] Comment comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }

            var createdComment = await _postService.CreateCommentAsync(comment);
            return CreatedAtAction(nameof(GetCommentsByPostId), new { postId = createdComment.PostId }, createdComment);
        }
    }

}
