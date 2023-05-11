namespace GamersParadiseAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserThreadController : ControllerBase
{
    private static List<UserThread> _userThreads;

    private static SubCategory _category;

    [HttpGet]
    public async Task<List<UserThread>> GetUserThreads()
    {

        if (_userThreads is null)
        {
            //TODO: Ta bort!
            _userThreads = new List<UserThread>
            {
                new UserThread { Id = 1, Header = "Jag gillar spel", Score = 0, Comments = null, Text = "Jag gillar att spela spel", UserId = 1 },
                new UserThread { Id = 2, Header = "Jag gillar spel 2", Score = 3, Comments = null, Text = "Jag gillar att spela spel 2", UserId = 2 }
            };
        }
        return _userThreads;
    }

    [HttpGet("{id}")]
    public async Task<UserThread> GetOneUserThread(int id)
    {
        if (_userThreads is null)
        {
            await GetUserThreads();
        }
        var userThread = _userThreads.Where(x => x.Id == id).FirstOrDefault();

        return userThread;
    }

    [HttpPost]
    public async Task CreateUserThread([FromBody] UserThread userThread)
    {
        if (_userThreads is null)
        {
            await GetUserThreads();
        }
        userThread.Id = _userThreads.TakeLast(1).Select(x => x.Id).FirstOrDefault() + 1;
        userThread.Comments = null;
        _userThreads.Add(userThread);
    }

    [HttpPut("{id}")]
    public async Task UpdateUserThread([FromBody] UserThread userThread, int id)
    {
        if (_userThreads is null)
        {
            await GetUserThreads();
        }

        var existingThread = _userThreads.Where(x => x.Id == id).FirstOrDefault();
        if (existingThread is not null)
        {
            existingThread.Header = userThread.Header;
            existingThread.Text = userThread.Text;
        }

    }
    [HttpDelete("{id}")]
    public async Task DeleteUserThread(int id)
    {
        if (_userThreads is null)
        {
            await GetUserThreads();
        }

        await GetUserThreads();
        if (id <= _userThreads.Count)
        {
            var deleteUserThread = _userThreads.Where(x => x.Id == id).FirstOrDefault();
            _userThreads.Remove(deleteUserThread);
        }
    }
}
