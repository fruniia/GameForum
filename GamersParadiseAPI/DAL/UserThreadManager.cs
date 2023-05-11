namespace GamersParadiseAPI.DAL;
public static class UserThreadManager
{
    public static List<UserThread> UserThreads { get; set; }
    public static async Task<List<UserThread>> GetAllThreads()
	{
		if(UserThreads is null || !UserThreads.Any())
		{
			UserThreads = new();
		}

		return UserThreads;
	}
}
