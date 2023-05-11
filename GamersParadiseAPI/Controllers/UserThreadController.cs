namespace GamersParadiseAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserThreadController : ControllerBase
{
	[HttpGet]
	public async Task<IEnumerable<UserThread>> GetUserThread()
	{
		var userThreads = await UserThreadManager.GetAllThreads();
		return userThreads;
	}
}
