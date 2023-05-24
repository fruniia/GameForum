using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamersParadiseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentManager _commentManager;

        public CommentController(CommentManager commentManager)
        {
            _commentManager = commentManager;
        }

        [HttpGet]
        public async Task<List<Comment>> Get()
        {
            var comments = await _commentManager.GetComments();
            return comments;
        }

        [HttpGet("{id}")]
        public async Task<Comment> GetOneComment(int id)
        {
            var comment = await _commentManager.GetOneComment(id);
            return comment;
        }

        [HttpPost]
        public async Task CreateComment([FromBody] Comment comment)
        {
            await _commentManager.AddComment(comment);
        }

        [HttpPut("{id}")]
        public async Task UpdateComment([FromBody] Comment comment, int id)
        {
            await _commentManager.UpdateComment(comment, id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteComment(int id)
        {
            await _commentManager.DeleteComment(id);
        }

    }
}
