namespace GamersParadiseAPI.DAL;

public class UserThreadManager
{
    private readonly ForumDbContext _context;
    public UserThreadManager(ForumDbContext context)
    {
        _context = context;
    }
    public async Task<List<UserThread>> GetUserThreads()
    {
        List<UserThread> userThreads = await _context.UserThreads.ToListAsync();

        return userThreads;
    }
    public async Task<UserThread> GetOneUserThread(int id)
    {
        var userThreads = await GetUserThreads();

        var userThread = userThreads.FirstOrDefault(x => x.Id == id);

        return userThread;
    }
    public async Task AddUserThread(UserThread userThread)
    {
        await _context.UserThreads.AddAsync(userThread);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateUserThread(UserThread userThread, int id)
    {
        var userThreadToUpdate = _context.UserThreads.FirstOrDefault(c => c.Id == id);

        if (userThreadToUpdate != null)
        {
            userThreadToUpdate.Header = userThread.Header;
            userThreadToUpdate.Content = userThread.Content;
            userThreadToUpdate.Reported = userThread.Reported;
        }
        await _context.SaveChangesAsync();
    }
    public async Task DeleteUserThread(int id)
    {
        var deleteUserThread = _context.UserThreads.FirstOrDefault(x => x.Id == id);

        if (deleteUserThread != null)
        {
            _context.UserThreads.Remove(deleteUserThread);
            await _context.SaveChangesAsync();
        }
    }

}
