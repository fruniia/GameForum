using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamersParadiseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private static List<Comment> _comments;

        [HttpGet]
        public async Task<List<Comment>> Get()
        {
            _comments = await CommentManager.GetComments();
            return _comments;
        }

        [HttpGet("{id}")]
        public async Task<Comment> GetOneComment(int id)
        {
            if (_comments is null)
            {
                _comments = await CommentManager.GetComments();
            }
            var comment = _comments.Where(x => x.Id == id).FirstOrDefault();

            return comment;
        }

        [HttpPost]
        public async Task CreateComment([FromBody] Comment comment)
        {
            if (_comments is null)
            {
                _comments = await CommentManager.GetComments();
            }
            //comment.Id = _comments.TakeLast(1).Select(x => x.Id).FirstOrDefault() + 1;
            _comments.Add(comment);
        }

        [HttpPut("{id}")]
        public async Task UpdateComment([FromBody] Comment comment, int id)
        {
            if (_comments is null)
            {
                _comments = await CommentManager.GetComments();
            }

            var existingComment = _comments.Where(x => x.Id == id).FirstOrDefault();
            if (existingComment is not null)
            {
                existingComment.Content = comment.Content;
                existingComment.Score = comment.Score;

            }

        }

        [HttpDelete("{id}")]
        public async Task DeleteComment(int id)
        {
            if (_comments is null)
            {
                _comments = await CommentManager.GetComments();

            }

            
                var deleteComment = _comments.Where(x => x.Id == id).FirstOrDefault();
                if (deleteComment is not null)
                {
                    _comments.Remove(deleteComment);
                }

           
        }
    }
}
