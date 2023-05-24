namespace GamersParadiseAPI.DAL
{
    public class CommentManager
    {
        private readonly ForumDbContext _context;
        public CommentManager(ForumDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetComments()
        {
            List<Comment> comments = await _context.Comments.ToListAsync();

            return comments;
        }

        public async Task<Comment> GetOneComment(int id)
        {
            var comments = await GetComments();
            var comment = comments.FirstOrDefault(x => x.Id == id);
            return comment;
        }

        public async Task AddComment(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateComment(Comment comment, int id)
        {
            var commentToUpdate = _context.Comments.FirstOrDefault(c => c.Id == id);

            if (commentToUpdate != null)
            {
                commentToUpdate.Content = comment.Content;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComment(int id)
        {
            var deleteComment = _context.Comments.FirstOrDefault(x => x.Id == id);

            if (deleteComment != null)
            {
                _context.Comments.Remove(deleteComment);
                await _context.SaveChangesAsync();
            }
        }

    }
}
