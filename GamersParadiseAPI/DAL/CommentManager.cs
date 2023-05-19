namespace GamersParadiseAPI.DAL
{
    public class CommentManager
    {
        public static List<Comment> Comments { get; set; }

        public static async Task<List<Comment>> GetComments()
        {
            var comments = new List<Comment>();

            if (Comments is null)
            {
                Comments = new List<Comment>();
                comments.Add(new Comment { Id = 1, Score = 1, Content = "Jag gillar också spel", Date = DateTime.Now});
                comments.Add(new Comment { Id = 2, Score = 2, Content = "Jag gillar också spel 2", Date = DateTime.Now });
            }

            Comments.AddRange(comments);

            return Comments;
        }
    }
}
