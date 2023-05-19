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

            userThreads.Add(new UserThread { Id = 1, Header = "Jag gillar spel", Score = 0, Content = "Jag gillar att spela spel", Date = DateTime.Now });
            userThreads.Add(new UserThread { Id = 2, Header = "Jag gillar spel 2", Score = 3, Content = "Jag gillar att spela spel 2", Date = DateTime.Now });
            
        }
        UserThreads.AddRange(userThreads);
        return UserThreads;
    }
}
