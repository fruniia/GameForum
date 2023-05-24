namespace GamersParadiseAPI.DAL;

public class ForumDbContext : DbContext
{
    public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
    {
    }

    public DbSet<MainCategory> MainCategories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<UserThread> UserThreads { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
