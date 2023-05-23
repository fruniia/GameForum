namespace GamersParadiseAPI.DAL;

public static class UserThreadManager
{
    public static List<UserThread> UserThreads { get; set; }


    public static async Task<List<UserThread>> GetAllUserThreads()      //Denna ska in i projektet.
    {
        var userThreads = new List<UserThread>();

        if (UserThreads is null)
        {
            UserThreads = new List<UserThread>();            
        }
        UserThreads.AddRange(userThreads);
        return UserThreads;
    }
}
